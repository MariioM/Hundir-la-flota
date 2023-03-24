using Hundir_La_Flota;
using Hundir_la_flota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_La_Flota
{
    internal class Patrullero : Barco
    {
        public Patrullero()
        {
            NumeroEspacios = 2;
            espacios = new Espacios[NumeroEspacios];
            Tipo = TipoBarco.Patrullero;
            espacios = new Espacios[NumeroEspacios];
            for (int i = 0; i < NumeroEspacios; i++)
            {

                espacios[i] = new Espacios();
            }
        }

        public Patrullero(int numeroEspacios, Espacios[] espacios) : base(numeroEspacios, espacios)
        {
            Tipo = TipoBarco.Patrullero;
        }


    }
}
