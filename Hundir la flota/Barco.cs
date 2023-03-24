﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hundir_la_flota
{
    abstract class Barco
    {
        //Atributos
        public int NumeroEspacios { get; set; }
        public Espacios[] Espacios { get; set; }
        public bool Hundido { get; set; }
        public TipoBarco Tipo { get; set; }
        public enum TipoBarco
        {
            Patrullero,
            Submarino,
            Destructor,
            Portaaviones
        }

        //Constructores
        public Barco()
        {
            NumeroEspacios = 3;
            Espacios = new Espacios[NumeroEspacios];
        }
        public Barco(int numeroEspacios, Espacios[] espacios)
        {
            NumeroEspacios = numeroEspacios;
            Espacios = espacios;
        }
        //Métodos
        public string[,] PosicionarBarco(string[,] matriz)
        {
            //Declaro las variables y cre un objeto tablero
            bool bucle = true;
            int opcion = 0;
            char filaLetra;
            int filaNumero;
            int posicionj = 0;
            Tablero tablero = new Tablero();
            while (bucle == true)
            {
                string texto1 = "Introduce la fila en la que se encuentra tu barco";
                Program.Centrar(texto1);
                filaLetra = Convert.ToChar(Console.ReadLine());
                filaNumero = tablero.LetraANumero(filaLetra);
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
                string error = "Tu barco se sale del tablero, decide otra vez hacia donde colocarlo";
                error = Program.Centrar2(error);

                if ((opcion == 1 && filaNumero >= NumeroEspacios - 1) || opcion != 1)
                {
                    if ((opcion == 2 && filaNumero <= 11 - NumeroEspacios - 1) || opcion != 2)
                    {
                        if ((opcion == 3 && posicionj >= NumeroEspacios - 1) || opcion != 3)
                        {
                            if ((opcion == 4 && posicionj <= 11 - NumeroEspacios - 1) || opcion != 4)
                            {
                                bucle = false;
                            }
                            else { Console.WriteLine(error); }
                        }
                        else { Console.WriteLine(error); }
                    }
                    else { Console.WriteLine(error); }
                }
                else { Console.WriteLine(error); }

                if (bucle == false)
                {
                    switch (opcion)
                    {
                        case 1:
                            int libre = 1;
                            for (int i = 0; i < NumeroEspacios; i++)
                            {
                                if (matriz[filaNumero - i, posicionj] == "X")
                                {
                                    libre = 2;
                                }
                                else if (matriz[filaNumero - i, posicionj] == Convert.ToChar(1).ToString())
                                {
                                    libre = 2;
                                }
                            }
                            if (libre == 1)
                            {
                                for (int i = 0; i < NumeroEspacios; i++)
                                {

                                    if (matriz[filaNumero - i, posicionj] == " ")
                                    {
                                        matriz[filaNumero - i, posicionj] = Convert.ToChar(1).ToString();
                                    }
                                }
                            }
                            else if (libre == 2)
                            {
                                {
                                    string texto = "Hay un obstáculo para colocar tu barco\n";
                                    texto = Program.Centrar2(texto);
                                    Console.WriteLine(texto);
                                    texto = "Introduce de nuevo las coordenadas y asegurate de no pasar por una tierra o un barco";
                                    texto = Program.Centrar2(texto);
                                    Console.WriteLine(texto);
                                    bucle = true;
                                    Console.ReadKey();
                                }
                            }
                            break;
                    }
                }
            }
            return matriz;
        }
        public void Hundir()
        {
            for (int i = 0; i < NumeroEspacios; i++)
            {

            }
        }
    }
}
