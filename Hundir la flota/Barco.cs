using Hundir_la_flota;
using Hundir_La_Flota;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_La_Flota
{
    internal class Barco
    {
        public int NumeroEspacios { get; set; }
        public Espacios[] espacios { get; set; }
        public bool Hundido { get; set; }
        public TipoBarco Tipo { get; set; }

        public enum TipoBarco
        {
            Patrullero,
            Submarino,
            Destructor,
            Portaaviones
        }

        public enum Estado
        {
            Flotando,
            Hundido,
            Tocado
        }



        public Barco()
        {
            NumeroEspacios = 2;
            espacios = new Espacios[NumeroEspacios];
            for (int i = 0; i < NumeroEspacios; i++)
            {

                espacios[i] = new Espacios();
                espacios[i].Destruido = false;
            }
        }
        public Barco(int numeroEspacios, Espacios[] espacio)
        {
            espacios = new Espacios[2];
            NumeroEspacios = numeroEspacios;
        }


        public string[,] PosicionarBarco(string[,] TableroJuego)
        {
            bool bucle = true;
            int opcion = 0;
            int posicioni = 0;
            int posicionj = 0;

            while (bucle == true)
            {
                string texto = "Añade tu barco " + Tipo + " que ocupa " + NumeroEspacios + " casillas";
                Program.Centrar(texto);
                string texto1 = "Introduce la fila en la que se encuentra tu barco";
                Program.Centrar(texto1);
                posicioni = Convert.ToInt32(Console.ReadLine()) - 1;
                string texto2 = "introduce la columna en la que se encuentra ";
                texto2 = Program.Centrar2(texto2);
                Console.WriteLine(texto2);
                posicionj = Convert.ToInt32(Console.ReadLine()) - 1;

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
                opcion = Convert.ToInt32(Console.ReadLine());
                bucle = ComprobarTablero(opcion, posicioni, posicionj);
                if (bucle == true)
                {
                    string error = "Tu barco se sale del tablero, decide otra vez hacia donde colocarlo\n";
                    error = Program.Centrar2(error);
                    Console.WriteLine(error);
                }
                else
                {
                    bool libre = ComprobarEspacioLibre(opcion, posicioni, posicionj, TableroJuego);
                    if (libre == true)
                    {
                        DibujarBarco(opcion, TableroJuego, posicioni, posicionj);
                    }
                    else
                    {
                        Error();
                        bucle = true;
                    }
                }
            }
            return TableroJuego;
        }

        public bool ComprobarTablero(int opcion, int posicioni, int posicionj)
        {
            bool bucle;
            if ((opcion == 1 && posicioni >= NumeroEspacios - 1) || opcion != 1)
            {
                if ((opcion == 2 && posicioni <= 11 - NumeroEspacios - 1) || opcion != 2)
                {
                    if ((opcion == 3 && posicionj >= NumeroEspacios - 1) || opcion != 3)
                    {
                        if ((opcion == 4 && posicionj <= 11 - NumeroEspacios - 1) || opcion != 4)
                        {
                            bucle = false;
                        }
                        else { bucle = true; }
                    }
                    else { bucle = true; }
                }
                else { bucle = true; }
            }
            else { bucle = true; }
            return bucle;
        }


        public bool ComprobarEspacioLibre(int opcion, int posicioni, int posicionj, string[,] TableroJuego)
        {
            bool libre = true;
            switch (opcion)
            {
                case 1:
                    for (int i = 0; i < NumeroEspacios; i++)
                    {
                        if (TableroJuego[posicioni - i, posicionj] == "X")
                        {
                            libre = false;
                        }
                        else if (TableroJuego[posicioni - i, posicionj] == Convert.ToChar(1).ToString())
                        {
                            libre = false;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < NumeroEspacios; i++)
                    {
                        if (TableroJuego[posicioni + i, posicionj] == "X")
                        {
                            libre = false;
                        }
                        else if (TableroJuego[posicioni + i, posicionj] == Convert.ToChar(1).ToString())
                        {
                            libre = false;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < NumeroEspacios; i++)
                    {
                        if (TableroJuego[posicioni, posicionj - i] == "X")
                        {
                            libre = false;
                        }
                        else if (TableroJuego[posicioni, posicionj - i] == Convert.ToChar(1).ToString())
                        {
                            libre = false;
                        }
                    }
                    break;
                case 4:
                    for (int i = 0; i < NumeroEspacios; i++)
                    {
                        if (TableroJuego[posicioni, posicionj + i] == "X")
                        {
                            libre = false;
                        }
                        else if (TableroJuego[posicioni, posicionj + i] == Convert.ToChar(1).ToString())
                        {
                            libre = false;
                        }
                    }
                    break;
            }
            return libre;
        }

        public string[,] DibujarBarco(int opcion, string[,] TableroJuego, int posicioni, int posicionj)
        {
            switch (opcion)
            {
                case 1:
                    for (int i = 0; i < NumeroEspacios; i++)
                    {

                        TableroJuego[posicioni - i, posicionj] = Convert.ToChar(1).ToString();
                        espacios[i].Fila = posicioni - i;
                        espacios[i].Columna = posicionj;
                    }
                    break;
                case 2:
                    for (int i = 0; i < NumeroEspacios; i++)
                    {

                        TableroJuego[posicioni + i, posicionj] = Convert.ToChar(1).ToString();
                        espacios[i].Fila = posicioni + i;
                        espacios[i].Columna = posicionj;
                    }
                    break;
                case 3:
                    for (int i = 0; i < NumeroEspacios; i++)
                    {

                        TableroJuego[posicioni, posicionj - i] = Convert.ToChar(1).ToString();
                        espacios[i].Fila = posicioni;
                        espacios[i].Columna = posicionj - i;
                    }
                    break;
                case 4:
                    for (int i = 0; i < NumeroEspacios; i++)
                    {
                        TableroJuego[posicioni, posicionj + i] = Convert.ToChar(1).ToString();
                        espacios[i].Fila = posicioni;
                        espacios[i].Columna = posicionj + i;
                    }
                    break;
            }
            return TableroJuego;
        }

        public void Error()
        {
            string texto = "Hay un obstáculo para colocar tu barco\n";
            texto = Program.Centrar2(texto);
            Console.WriteLine(texto);
            texto = "Introduce de nuevo las coordenadas y asegurate de no pasar por una tierra o un barco";
            texto = Program.Centrar2(texto);
            Console.WriteLine(texto);
            Console.ReadKey();
        }

        public string[,] Hundir(string[,] TableroJuego, int disparoi, int disparoj)
        {
            if (Hundido == false)
            {
                Hundido = true;
                for (int i = 0; i < NumeroEspacios; i++)
                {
                    if (espacios[i].Fila == disparoi && espacios[i].Columna == disparoj)
                    {
                        espacios[i].Destruido = true;
                        TableroJuego = BarcoTocado(TableroJuego, disparoi, disparoj);
                    }

                    if (espacios[i].Destruido == false)
                    {
                        Hundido = false;
                    }
                }
                if (Hundido == true)
                {
                    Console.WriteLine("Hundido");
                    TableroJuego = EliminarBarco(TableroJuego);
                }

            }
            return TableroJuego;
        }

        public string[,] BarcoTocado(string[,] TableroJuego, int disparoi, int disparoj)
        {
            TableroJuego[disparoi, disparoj] = Convert.ToChar(2).ToString();
            return TableroJuego;
        }
        public string[,] EliminarBarco(string[,] TableroJuego)
        {
            for (int i = 0; i < NumeroEspacios; i++)
            {
                TableroJuego[espacios[i].Fila, espacios[i].Columna] = Convert.ToChar(237).ToString();
            }
            return TableroJuego;
        }

        public string[,] Disparo(string[,] TableroJuego)
        {
            //Pedimos valores (x,y) del disparo.
            Console.WriteLine("Introduzca la coordenada x de tu disparo: ");
            int Coordx = Convert.ToInt16(Console.ReadLine()) - 1;
            Console.WriteLine("Introduzca la coordenada y de tu disparo: ");
            int Coordy = Convert.ToInt16(Console.ReadLine()) - 1;
            TableroJuego = Hundir(TableroJuego, Coordx, Coordy);
            return TableroJuego;
        }
    }
}
