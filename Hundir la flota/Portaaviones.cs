using Hundir_La_Flota;
using Hundir_la_flota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hundir_La_Flota.Barco;

namespace Hundir_La_Flota
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
