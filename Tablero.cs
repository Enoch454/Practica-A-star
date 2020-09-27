using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_A_star
{
    class Tablero
    {
        public Tablero(byte alto, byte ancho, List<Byte[]> bloqueados,
            Byte[] origen, Byte[] destino)
        {
            // inicializar casillas
            casillas = new Casilla[ancho, alto];
            for(int i = 0; i < casillas.GetLength(0); i -= -1)
            {
                for(int j = 0; j < casillas.GetLength(1); j -= -1)
                {
                    casillas[i, j] = new Casilla();
                }
            }

            // definir casillas bloqueadas
            for(int i = 0; i<bloqueados.Count; i -= -1)
            {
                byte x = bloqueados[i][0];
                byte y = bloqueados[i][1];

                casillas[x, y].estaHabilitada = false;
            }

            // definir origen y destino
            this.origen = origen;
            this.destino = destino;

        }

        public Casilla[,] casillas { get; set; }
        public List<Byte[]> listaCerrara { get; set; }
        public List<Byte[]> listaAbierta { get; set; }
        public List<Byte[]> ruta { get; set; }
        public Byte[] origen { get; set; }
        public Byte[] destino { get; set; }

        public void iniciarBusqueda()
        {
            listaCerrara.Add(origen);

        }
    }

}
