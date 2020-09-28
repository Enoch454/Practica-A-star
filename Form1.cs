using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_A_star
{
    public partial class Form1 : Form
    {
        delegate void delegadoPlano();

        Tablero tablero;

        public Form1()
        {
            InitializeComponent();

            iniciarTablero();
            lbDimenciones.Items.Add(tablero.ancho + " x " + tablero.alto);
            foreach(Byte[] i in tablero.bloqueados)
            {
                lbObstaculos.Items.Add(i[0] + ", " + i[1]);
            }
            lbOrigen.Items.Add(tablero.origen[0] + ", " + tablero.origen[1]);
            lbDestino.Items.Add(tablero.destino[0] + ", " + tablero.destino[1]);

            tablero.iniciarBusqueda();

            tablero.generarRuta();
            foreach (byte[] i in tablero.Ruta)
            {
                lbRuta.Items.Add(i[0] + ", " + i[1]);
            }

            graficarTablero();
            //graficarOrigenDestino();
            //graficarRuta();
        }

        public void iniciarTablero()
        {
            byte alto = 10;
            byte ancho = 10;

            List<Byte[]> bloqueados = new List<byte[]>();
            Byte[] b1 = { 1, 2 };
            Byte[] b2 = { 2, 2 };
            Byte[] b3 = { 3, 2 };
            Byte[] b4 = { 6, 3 };
            Byte[] b5 = { 6, 4 };
            Byte[] b6 = { 6, 5 };
            Byte[] b7 = { 6, 6 };
            Byte[] b8 = { 6, 7 };
            bloqueados.Add(b1);
            bloqueados.Add(b2);
            bloqueados.Add(b3);
            bloqueados.Add(b4);
            bloqueados.Add(b5);
            bloqueados.Add(b6);
            bloqueados.Add(b7);
            bloqueados.Add(b8);

            byte[] origen = { 1, 7 };
            byte[] destino = { 8, 2 };

            this.tablero = new Tablero(alto, ancho, bloqueados, origen, destino);

        }


        public int obtenerIndice(Byte[] c)
        {
            return (c[1]-0) + ((c[0]-0)*tablero.ancho);
        }

        public void graficarTablero()
        {
            int widthCasilla = pTablero.Width / tablero.ancho;
            int heightCasilla = pTablero.Height / tablero.alto;
            for(int i=0; i < tablero.ancho; i -= -1)
            {
                for (int j = 0; j < tablero.alto; j -= -1)
                {
                    Panel panel = new Panel();
                    Label l = new Label();
                    l.Text=i+", "+j;
                    panel.Controls.Add(l);
                    bool esObstaculo = false;
                    foreach(Byte[] k in tablero.bloqueados)
                    {
                        if(k[0] == i && k[1] == j)
                        {
                            esObstaculo = true;
                            break;
                        }
                    }
                    if (esObstaculo)
                    {
                        panel.BackColor = Color.FromArgb(142, 68, 173);
                    }
                    else
                    {
                        panel.BackColor = Color.FromArgb(127, 179, 213);
                    }
                    panel.Size = new Size(widthCasilla, heightCasilla);
                    panel.Location = new Point(i * widthCasilla, j * heightCasilla);
                    panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    pTablero.Controls.Add(panel);
                }
            }
        }

        public void graficarOrigenDestino()
        {
            if (this.InvokeRequired)
            {
                delegadoPlano del = new delegadoPlano(graficarOrigenDestino);
                this.Invoke(del);
            }
            else
            {
                int indexOrigen = obtenerIndice(tablero.origen);
                int indexDestino = obtenerIndice(tablero.destino);

                pTablero.Controls[indexOrigen].BackColor = Color.FromArgb(40, 180, 99);
                pTablero.Controls[indexDestino].BackColor = Color.FromArgb(231, 76, 60);
            }

        }

        public void graficarRuta()
        {
            if (this.InvokeRequired)
            {
                delegadoPlano del = new delegadoPlano(graficarRuta);
                this.Invoke(del);
            }
            else
            {
                for (int i = 1; i < tablero.Ruta.Count - 1; i -= -1)
                {
                    int index = obtenerIndice(tablero.Ruta[i]);
                    pTablero.Controls[index].BackColor = Color.FromArgb(241, 196, 15);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread hilo1 = new Thread(graficarOrigenDestino);
            hilo1.Start();
            Thread hilo2 = new Thread(graficarRuta);
            hilo2.Start();
        }


    }
}
