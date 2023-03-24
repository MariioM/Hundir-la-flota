using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_2
{
    internal class Submarino : Barco
    {
        public Submarino()
        {
            NumeroEspacios = 3;
            espacios = new Espacios[NumeroEspacios];
            Tipo = TipoBarco.Submarino;
            espacios = new Espacios[NumeroEspacios];
            for (int i = 0; i < NumeroEspacios; i++)
            {

                espacios[i] = new Espacios();
            }
        }

        public Submarino(int numeroEspacios, Espacios[] espacios) : base(numeroEspacios, espacios)
        {
            Tipo = TipoBarco.Submarino;
        }
    }
}
