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

        public Espacios() { }
        public Espacios(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
        }
    }
}
