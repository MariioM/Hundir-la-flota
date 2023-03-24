using Hundir_la_flota;
using Hundir_La_Flota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    internal class Jugador
    {
        public string Name { get; set; }
        public string Resultado { get; set; }
        public int NumeroBarcos { get; set; }
        public Barco[] ListaBarcos { get; set; }
        public bool Derrota { get; set; }

        public Jugador()
        {
            NumeroBarcos = 4;
            ListaBarcos = new Barco[NumeroBarcos];
            Patrullero patrullero = new Patrullero();
            ListaBarcos[0] = patrullero;
            Portaaviones poortavion = new Portaaviones();
            ListaBarcos[1] = poortavion;
            Submarino submarino = new Submarino();
            ListaBarcos[2] = submarino;
            Destructor destructor = new Destructor();
            ListaBarcos[3] = destructor;
        }
        public Jugador(string name, string resultado, int numeroListaBarcos, bool derrota)
        {
            NumeroBarcos = numeroListaBarcos;
            Resultado = resultado;
            Name = name;
            Derrota = Derrota;
            NumeroBarcos = 4;
            ListaBarcos = new Barco[NumeroBarcos];
            Patrullero patrullero = new Patrullero();
            ListaBarcos[0] = patrullero;
            Portaaviones poortavion = new Portaaviones();
            ListaBarcos[1] = poortavion;
            Submarino submarino = new Submarino();
            ListaBarcos[2] = submarino;
            Destructor destructor = new Destructor();
            ListaBarcos[3] = destructor;

        }

        public string[,] ColocarBarcos(Tablero tablero)
        {
            foreach (Barco barco in ListaBarcos)
            {
                tablero.TableroJuego = barco.PosicionarBarco(tablero.TableroJuego);
                tablero.MostrarTablero();

            }
            return tablero.TableroJuego;
        }

        public string[,] Disparo(string[,] TableroJuego, Jugador jugador)
        {
            Tablero tablero = new Tablero();
            //Pedimos valores (x,y) del disparo.
            Console.WriteLine(jugador.Name + "Introduzca la coordenada x de tu disparo: ");
            char CoordLetra = Convert.ToChar(Console.ReadLine());
            int CoordNumero = tablero.LetraANumero(CoordLetra);
            Console.WriteLine(jugador.Name + "Introduzca la coordenada y de tu disparo: ");
            int Coordy = Convert.ToInt16(Console.ReadLine()) - 1;
            foreach (Barco barco in ListaBarcos)
            {
                TableroJuego = barco.Hundir(TableroJuego, CoordNumero, Coordy);
            }
            return TableroJuego;
        }
    }
}
