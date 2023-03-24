using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    internal class Espacios
    {
        public int Fila { get; set; }
        public int Columna { get; set; }
        public bool Destruido { get; set; }

        public Espacios()
        {
            Destruido = false;
        }
        public Espacios(int fila, int columna, bool destruido)
        {

            Destruido = destruido;
            Fila = fila;
            Columna = columna;
        }
    }
}
