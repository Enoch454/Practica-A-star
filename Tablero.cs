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
            this.listaAbierta = new List<byte[]>();
            this.listaCerrara = new List<byte[]>();

            // inicializar casillas
            casillas = new Casilla[ancho, alto];
            for (int i = 0; i < casillas.GetLength(0); i -= -1)
            {
                for (int j = 0; j < casillas.GetLength(1); j -= -1)
                {
                    casillas[i, j] = new Casilla();
                }
            }

            // definir casillas bloqueadas
            for (int i = 0; i < bloqueados.Count; i -= -1)
            {
                byte x = bloqueados[i][0];
                byte y = bloqueados[i][1];

                casillas[x, y].estaHabilitada = false;
            }

            // definir origen y destino
            this.origen = origen;
            this.destino = destino;

            // definir distancia de manjatan en las casillas
            for (int i = 0; i < casillas.GetLength(0); i -= -1)
            {
                for (int j = 0; j < casillas.GetLength(1); j -= -1)
                {
                    Byte[] casilla = { (byte)i, (byte)j };
                    casillas[i, j].manhattan = manhattan(casilla);
                }
            }
        }

        public Casilla[,] casillas { get; set; }
        public List<Byte[]> listaCerrara { get; set; }
        public List<Byte[]> listaAbierta { get; set; }
        public Byte[] origen { get; set; }
        public Byte[] destino { get; set; }
        private List<Byte[]> ruta { get; set; }
        public List<Byte[]> Ruta { get { return ruta; } }


        /**
         * en vase a los datos guardados en los apuntadores de
         * cada casilla, se procede a ordenar esta informacion 
         * para definir la ruta optima
         */
        public void generarRuta()
        {
            List<Byte[]> ruta = new List<Byte[]>();
            ruta.Add(destino);
            while (true)
            {
                if (ruta[0].Equals(this.origen))
                {
                    break;
                }
                else
                {
                    Byte[] pasoActual = ruta[0];
                    Byte[] pasoAnterior = casillas[pasoActual[0], pasoActual[1]].puntero;
                    ruta.Insert(0, pasoAnterior);
                }
            }
            this.ruta = ruta;
        }


        public void iniciarBusqueda()
        {
            listaCerrara.Add(origen);

            while (true)
            {
                // si se ha agragado la casilla destino a la lista cerrada
                // entonces podemos dar por concluidad la busqueda
                if (listaCerrara.Last().Equals(destino))
                {
                    break;
                }
                else
                {
                    Byte[] pasoActual = listaCerrara.Last();
                    //calculo de casillas al rededor en sentido a manesillas
                    //del reloj

                    //se estiman cuales serian las coorenadas de las casillas
                    List<Byte[]> casillasPerifericas = new List<byte[]>();
                    Byte[] I = { (byte)(pasoActual[0] - 1), (byte)(pasoActual[1] - 1) };
                    Byte[] II = { (byte)(pasoActual[0]), (byte)(pasoActual[1] - 1) };
                    Byte[] III = { (byte)(pasoActual[0] + 1), (byte)(pasoActual[1] - 1) };
                    Byte[] IV = { (byte)(pasoActual[0] + 1), (byte)(pasoActual[1]) };
                    Byte[] V = { (byte)(pasoActual[0] + 1), (byte)(pasoActual[1] + 1) };
                    Byte[] VI = { (byte)(pasoActual[0]), (byte)(pasoActual[1] + 1) };
                    Byte[] VII = { (byte)(pasoActual[0] - 1), (byte)(pasoActual[1] + 1) };
                    Byte[] VIII = { (byte)(pasoActual[0] - 1), (byte)(pasoActual[1]) };
                    casillasPerifericas.Add(I);
                    casillasPerifericas.Add(II);
                    casillasPerifericas.Add(III);
                    casillasPerifericas.Add(IV);
                    casillasPerifericas.Add(V);
                    casillasPerifericas.Add(VI);
                    casillasPerifericas.Add(VII);
                    casillasPerifericas.Add(VIII);

                    for(int i = 0; i<8; i -= -1)
                    {
                        byte[] c = casillasPerifericas[i];
                        //se aplica condicion para omitir coordenadas fuera de rango
                        bool dentroRango = (c[0] >= 0 && c[0] < casillas.GetLength(0)) &&
                                           (c[1] >= 0 && c[1] < casillas.GetLength(1));
                        //tambien se considera condicion para casillas bloqueadas
                        bool estaHabilitada = casillas[c[0], c[1]].estaHabilitada;
                        if (dentroRango && estaHabilitada)
                        {
                            //procedo a calcular coste y agregar a lista abieta
                            casillas[c[0],c[1]].coste = this.coste(c);
                            listaAbierta.Add(c);
                        }

                    }

                    //procedo a escojer la casilla para la lista cerrara
                    List<int> listaAbiertaValores = new List<int>();
                    foreach(Byte[] i in listaAbierta)
                    {
                        listaAbiertaValores.Add(casillas[i[0], i[1]].funcionAStar);
                    }
                    int min = listaAbiertaValores.Min();
                    int index = listaAbiertaValores.IndexOf(min);
                    listaCerrara.Add(listaAbierta[index]);

                }
            }
        }


        /**
         * @params: destino
         * repesenta la coordenada de la casilla hacia la cual se 
         * quiere calcular el coste.
         * automaticamente se tomara en cuenta la ultima casilla en
         * la lista cerrara como origen.
         */
        public int coste(Byte[] destino)
        {
            Byte[] origen = listaCerrara.Last();
            int costeAcumulado = casillas[origen[0], origen[1]].coste;

            int d_x = (destino[0] - origen[0]) * 10;
            int d_y = (destino[1] - origen[1]) * 10;
            int distancia = (int)(Math.Sqrt(Math.Pow(d_x, 2) + Math.Pow(d_y, 2)));

            return(costeAcumulado + distancia);
        }


        /**
         * @params: casilla
         * calcula la distancia de manhattan desde el destino ya
         * señalado al inicio hasta la casilla indicada como parametro
         */
        public int manhattan(Byte[] casilla)
        {
            int d_x = (this.destino[0] - casilla[0]) * 10;
            int d_y = (this.destino[1] - casilla[1]) * 10;
            return Math.Abs(d_x) + Math.Abs(d_y);
        }
    }

}
