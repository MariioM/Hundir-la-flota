using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practica_2.Barco;

namespace Practica_2
{
    internal class Destructor : Barco
    {
        public Destructor()
        {
            NumeroEspacios = 4;
            espacios = new Espacios[NumeroEspacios];
            Tipo = TipoBarco.Destructor;
            espacios = new Espacios[NumeroEspacios];
            for (int i = 0; i < NumeroEspacios; i++)
            {

                espacios[i] = new Espacios();
            }
        }

        public Destructor(int numeroEspacios, Espacios[] espacios) : base(numeroEspacios, espacios)
        {
            Tipo = TipoBarco.Destructor;
        }
    }
}
