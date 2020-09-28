using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_A_star
{
    public partial class Form1 : Form
    {
        Tablero tablero;

        public Form1()
        {
            InitializeComponent();

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

        private void button1_Click(object sender, EventArgs e)
        {
            iniciarTablero();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tablero.generarRuta();

            foreach (byte[] i in tablero.Ruta)
            {
                listBox1.Items.Add(i[0] + ", " + i[1]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tablero.iniciarBusqueda();
            
        }
    }
}
