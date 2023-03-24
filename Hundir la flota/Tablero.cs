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
        public string[,] TableroJuego { get; set; }
        public int Filas { get; set; }
        public int Columnas { get; set; }
        //Constructores
        public Tablero()
        {
            Filas = 12;
            Columnas = 12;
            TableroJuego = new string[Filas, Columnas];
        }

        //Métodos
        public Tablero(int filas, int columnas)
        {
            Filas = filas;
            Columnas = columnas;
            TableroJuego = new string[filas, columnas];

        }

        //Este método rellenará el tablero con todo 0 y llamara a los metodos set tierras y a los métodos poner barcos de cada usuario.
        public void Crear()
        {

            string caracter = " ";
            caracter = string.Concat(Enumerable.Repeat(caracter, 10));
            // Inicializa la TableroJuego con todo 0;
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    TableroJuego[i, j] = " ";
                }
            }
            SetTierras();
        }
        public void SetTierras()
        {
            //Creamos un objeto que nos permita sacar un número aleatorio
            var seed = Environment.TickCount;
            Random rnd = new Random(seed);
            for (int i = 0; i < 14; i++)
            {
                //Declaramos dos variables que contendrán los números aleatorios que corresponderán a las coordenadas de las tierras
                int numeroAleatorio1 = rnd.Next(0, 12);
                int numeroAleatorio2 = rnd.Next(0, 12);
                if (TableroJuego[numeroAleatorio1, numeroAleatorio2] == "X")
                {
                    i--;
                }
                else
                {
                    TableroJuego[numeroAleatorio1, numeroAleatorio2] = "X";
                }
            }
            MostrarTablero();
        }

        public void MostrarTablero()
        {
            string caracter = " ";
            char letraFila = 'a';
            //Hacemos que la variable "caracter" se concatene consigo misma 10 veces para centrar el texto.
            caracter = string.Concat(Enumerable.Repeat(caracter, 10));
            Console.Write(caracter + "   ");
            //Enumeramos las columnas del tablero
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
            //Creamos el tablero con dos bucles anidados
            for (int i = 0; i < Filas; i++)
            {
                //Enumeramos las columnas con letras
                Console.Write(caracter);
                Console.Write("{0}  ", letraFila);
                letraFila++;
                for (int j = 0; j < Columnas; j++)
                {
                    
                    Console.Write("| {0} ", TableroJuego[i, j]);
                }
                Console.WriteLine("|\n");
            }
        }

        public int LetraANumero(char fila)
        {

            //Declaro un array que contenga todas las letras que tenga el tablero
            char[] LetraFilas = new char[Filas];
            char letra = 'a';
            int i;
            //Hago un bucle que rellene el array
            for(i = 0; i < Filas; i++)
            {
                LetraFilas[i] = letra;
                letra++;
            }
            //Comparo el input del usuario con el array
            for(i = 0; i < Filas; i++)
            {
                if (LetraFilas[i] == fila)
                {
                    break;
                }
            }
            return i;
        }
    }
}