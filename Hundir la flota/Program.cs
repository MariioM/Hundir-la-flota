using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    internal class Program
    {
        //En el main se desarrolla el menu que llamará a diferentes opciones dependiendo de la decisión del usuario.
        static void Main(string[] args)
        {
            string texto = "Pulsa intro para empezar";
            string texto1 = "Introduce 1. Para jugar solo   \n";
            texto1 = Centrar2(texto1);
            string texto2 = "Introduce 2. Para dos jugadores\n";
            texto2 = Centrar2(texto2);
            string texto3 = "Introduce 3. Para cargar partida\n";
            texto3 = Centrar2(texto3);
            string texto4 = "Introduce 4. Para cargar partida\n";
            texto4 = Centrar2(texto4);
            string texto5 = "Introduce 5. Para salir         ";
            texto5 = Centrar2(texto5);
            string opciones = "Introduce una opción\n\n\n";

            Centrar(texto);
            Console.ReadKey();
            Centrar(opciones);
            texto1 = texto1 + texto2 + texto3 + texto4 + texto5;
            Console.WriteLine(texto1);
            int comando = Convert.ToInt32(Console.ReadLine());
            Tablero tablero = new Tablero();
            switch (comando)
            {
                case 1:
                    tablero.Crear();
                    Barco barco = new Barco();
                    tablero.Matriz = barco.PosicionarBarco(tablero.Matriz);
                    tablero.Mostrar();
                    Console.ReadKey();
                    break;
            }


        }
        //Esta función es de pura estetica centrará el texto introducido dará un especio e imprimirá una línea de '*'.
        public static void Centrar(string texto)
        {
            string caracter = "*";
            string caracter2 = " ";
            string caracterR, espacios1, espacios2;

            caracterR = string.Concat(Enumerable.Repeat(caracter, 100));
            int longitudTotal = Console.WindowWidth;
            longitudTotal = (longitudTotal / 2) - 50;
            espacios1 = string.Concat(Enumerable.Repeat(caracter2, longitudTotal));
            int longitudTexto = texto.Length / 2;
            longitudTexto = 50 - longitudTexto;
            espacios2 = string.Concat(Enumerable.Repeat(caracter2, longitudTexto));
            Console.WriteLine(espacios1 + caracterR + "\n\n" + espacios1 + espacios2 + texto + "\n");
        }
        //Esta funcion es parecida a la anterior simplemente centrará el texto introducido.
        public static string Centrar2(string texto2)
        {
            string caracter2 = " ";
            string espacios1, espacios2;
            int longitudTotal = Console.WindowWidth;
            longitudTotal = (longitudTotal / 2) - 50;
            espacios1 = string.Concat(Enumerable.Repeat(caracter2, longitudTotal));
            int longitudTexto = texto2.Length / 2;
            longitudTexto = 50 - longitudTexto;
            espacios2 = string.Concat(Enumerable.Repeat(caracter2, longitudTexto));
            texto2 = espacios1 + espacios2 + texto2;
            return texto2;
        }

    }
}