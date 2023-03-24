using Hundir_la_flota;
using Hundir_La_Flota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hundir_La_Flota.Barco;

namespace Hundir_La_Flota
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
