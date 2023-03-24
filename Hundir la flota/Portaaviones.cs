using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Practica_2.Barco;

namespace Practica_2
{
    internal class Portaaviones : Barco
    {
        public Portaaviones()
        {
            NumeroEspacios = 5;
            espacios = new Espacios[NumeroEspacios];
            Tipo = TipoBarco.Portaaviones;
            espacios = new Espacios[NumeroEspacios];
            for (int i = 0; i < NumeroEspacios; i++)
            {
                espacios[i] = new Espacios();
            }
        }

        public Portaaviones(int numeroEspacios, Espacios[] espacios) : base(numeroEspacios, espacios)
        {
            Tipo = TipoBarco.Portaaviones;
        }
    }
}
