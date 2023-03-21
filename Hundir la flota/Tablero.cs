using Hundir_la_flota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    internal class Tablero
    {
        //Atributos
        public string[,] Matriz { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        //Constructores
        public Tablero()
        {
            Filas = 12;
            Columnas = 12;
            Matriz = new string[Filas, Columnas];
        }

        //Métodos
        public Tablero(int filas, int columnas)
        {
            Filas = filas;
            Columnas = columnas;
            Matriz = new string[filas, columnas];

        }

        //Este método rellenará el tablero con todo 0 y llamara a los metodos set tierras y a los métodos poner barcos de cada usuario.
        public void Crear()
        {

            string caracter = " ";
            caracter = string.Concat(Enumerable.Repeat(caracter, 10));
            // Inicializa la Matriz con todo 0;
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    Matriz[i, j] = " ";
                }
            }
            SetTierras();
        }
        public void SetTierras()
        {
            var seed = Environment.TickCount;
            Random rnd = new Random(seed);
            for (int i = 0; i < 14; i++)
            {
                int numeroAleatorio1 = rnd.Next(0, 12);
                int numeroAleatorio2 = rnd.Next(0, 12);
                if (Matriz[numeroAleatorio1, numeroAleatorio2] == "X")
                {
                    i--;
                }
                else
                {
                    Matriz[numeroAleatorio1, numeroAleatorio2] = "X";
                }
            }
            MostrarTablero();
        }

        public void MostrarTablero()
        {
            string caracter = " ";
            char letraFila = 'a';
            caracter = string.Concat(Enumerable.Repeat(caracter, 10));
            Console.Write(caracter + "  ");
            for (int i = 1; i <= Filas; i++)
            {
                if (i <= 10)
                {
                    Console.Write("  {0} ", i);
                }
                else
                {
                    Console.Write(" {0} ", i);

                }
            }

            Console.WriteLine("\n");
            for (int i = 0; i < Filas; i++)
            {
                Console.Write(caracter);
                Console.Write("{0}  ", letraFila);
                letraFila++;
                for (int j = 0; j < Columnas; j++)
                {
                    
                    Console.Write("| {0} ", Matriz[i, j]);
                }
                Console.WriteLine("|\n");
            }
        }

        public void PosicionarBarco(Barco barco)
        {
            string texto1 = "Introduce la fila en la que se encuentra tu barco";
            Program.Centrar(texto1);
            int posicioni = Convert.ToInt32(Console.ReadLine()) - 1;
            string texto2 = "introduce la columna en la que se encuentra ";
            texto2 = Program.Centrar2(texto2);
            Console.WriteLine(texto2);
            int posicionj = Convert.ToInt32(Console.ReadLine()) - 1;

            string menu = "Introduce 1.Para colocar tu barco hacia arriba\n";
            menu = Program.Centrar2(menu);
            string menu2 = "Introduce 2.Para colocar tu barco hacia abajo\n";
            menu2 = Program.Centrar2(menu2);
            string menu3 = "Introduce 3.Para colocar tu barco hacia la izquierda\n";
            menu3 = Program.Centrar2(menu3);
            string menu4 = "Introduce 4.Para colocar tu barco hacia la derecha\n";
            menu4 = Program.Centrar2(menu4);

            menu = menu + menu2 + menu3 + menu4;
            Console.WriteLine(menu);
            int opcion = Convert.ToInt32(Console.ReadLine());
            int numeroEspacios = barco.NumeroEspacios;
            switch (opcion)
            {
                case 1:
                    for (int i = 0; i < numeroEspacios; i++)
                    {
                        if (Matriz[posicioni - i, posicionj] == " ")
                        {
                            Matriz[posicioni - i, posicionj] = "U";
                        }
                        else if (Matriz[posicioni - i, posicionj] == "X")
                        {
                            string texto = "Tu barco pasa por una tierra\n";
                            texto = Program.Centrar2(texto);
                            Console.WriteLine(texto);
                            texto = "Introduce de nuevo las cordenasas y asegutate de no pasar por una tierra";
                            texto = Program.Centrar2(texto);
                            Console.WriteLine(texto);
                            posicioni = Convert.ToInt32(Console.ReadLine());
                            posicionj = Convert.ToInt32(Console.ReadLine());
                            i--;

                        }
                    }
                    MostrarTablero();
                    break;
            }
        }
    }
}