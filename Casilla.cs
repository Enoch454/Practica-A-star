using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_A_star
{
    class Casilla
    {
        public Casilla()
        {
            estaHabilitada = true;
            //esOrigen = false;
            //esDestino = false;
            coste = 0;
            manhattan = 0;
            puntero = null;

        }

        public bool estaHabilitada { get; set; }
        //public bool esOrigen { get; set; }
        //public bool esDestino { get; set; }
        public int coste { get; set; }
        public int manhattan { get; set; }
        public int funcionAStar { get { return (coste + manhattan); } }
        public byte[] puntero { get; set; }
    }
}
