using Hundir_la_flota;
using Hundir_La_Flota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    internal class Juego
    {
        public Tablero[] Tableros { get; set; }
        public Jugador[] Jugadores { get; set; }

        public Juego()
        {
            Tableros = new Tablero[2];
            Tableros[0] = new Tablero();
            Tableros[1] = new Tablero();
            Tableros[0].Crear();
            Array.Copy(Tableros[0].TableroJuego, Tableros[1].TableroJuego, Tableros[0].TableroJuego.Length);
            Jugadores = new Jugador[2];
            Jugadores[0] = new Jugador();
            Jugadores[1] = new Jugador();
        }

        public void Partida1vs1()
        {
            string texto;
            for (int i = 0; i < Jugadores.Length; i++)
            {
                texto = Program.Centrar2("Jugador " + (i + 1) + " introduce tu nombre");
                Console.WriteLine(texto);
                Jugadores[i].Name = Console.ReadLine();
                Tableros[i].MostrarTablero();
                Tableros[i].TableroJuego = Jugadores[i].ColocarBarcos(Tableros[i]);
            }

            bool finPartida = false;
            while (finPartida == false)
            {
                for (int i = 0; i < Jugadores.Length; i++)
                {
                    Tableros[i].TableroJuego = Jugadores[i].Disparo(Tableros[i].TableroJuego, Jugadores[i]);
                }
                for (int i = 0; i < Jugadores.Length; i++)
                {
                    finPartida = Turno();
                }
            }

            if (Jugadores[0].Derrota == true)
            {
                Program.Centrar("Enorabuena " + Jugadores[1].Name + " has ganado la partida");
            }
            else if (Jugadores[1].Derrota == true)
            {
                Program.Centrar("Enorabuena " + Jugadores[0].Name + " has ganado la partida");
            }
        }



        public bool Turno()
        {
            bool finPartida = true;

            for (int i = 0; i < Jugadores.Length; i++)
            {
                foreach (Barco barcos in Jugadores[i].ListaBarcos)
                {
                    if (barcos.Hundido == false)
                    {
                        finPartida = false;
                    }
                    if (finPartida == false)
                        if (finPartida == true)
                        {
                            Jugadores[i].Derrota = true;
                            i++;
                        }
                }
            }

            return finPartida;
        }


    }
}
