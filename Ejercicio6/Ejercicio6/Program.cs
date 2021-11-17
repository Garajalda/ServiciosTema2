using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio6
{
    class Program
    {
        static Random rnd = new Random();
        static object l = new object();
        static int contadorComun = 0;
        static bool principio = true;
        
        static bool pausar = false;
        static string ganador = "";
        static bool meta = false;

        
        public static void player1()
        {
            int aleatorio = 0;
    
            while (true)
            {
                


                    lock (l)
                    {
                        if (aleatorio == 5 || aleatorio == 7)
                        {
                            if (pausar)
                            {
                                contadorComun += 5;
                            }
                            else
                            {
                                contadorComun++;

                            }

                            pausar = true;
                        }
                        else
                        {
                                Monitor.Pulse(l);

                        }
                        aleatorio = rnd.Next(1, 11);

                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine("Player1: " + aleatorio + " ");
                        if (contadorComun >= 20)
                        {
                            ganador = "player 1";
                            meta = true;
                        }
                    
                    }
                


                    Thread.Sleep(100 * aleatorio);
            }

            
        }

        public static void player2()
        {
            int aleatorio = 0;
            while (true)
            {
                lock (l)
                {
                    if (aleatorio == 5 || aleatorio == 7)
                    {
                        if (!principio && !pausar)
                        {

                            contadorComun-=5;
                        }
                        else
                        {
                            contadorComun--;
                        }
                        pausar = false;

                    }
                    aleatorio = rnd.Next(1, 11);

                    Console.SetCursorPosition(0, 2);
                    Console.Write("Player2: "+aleatorio+" ");
                    if (contadorComun <= -20)
                    {
                        ganador = "player 2";
                        meta = true;
                    }

                }
                    Thread.Sleep(100 * aleatorio);

            }
        }

        public static void display()
        {
            
            string[] caracter = new string[4];
            caracter[0] = "|";
            caracter[1] = "/";
            caracter[2] = "_";
            caracter[3] = "\\";
            int caracterId = 0;
            while (true)
            {


                
                lock (l)
                {
                    if (pausar)
                    {
                        Monitor.Wait(l);
                        principio = false;
                    }
                    else
                    {
                        Console.SetCursorPosition(0,4);
                        Console.Write(caracter[caracterId]+" Loading...");
                        caracterId++;
                        if (caracterId == caracter.Count())
                        {
                            caracterId = 0;
                        }

                    }

                }
                Thread.Sleep(200);
                
            }
        }

       
        static void Main(string[] args)
        {
            
            

            Thread hiloPlayer1 = new Thread(player1);
            hiloPlayer1.Start();
            hiloPlayer1.IsBackground = true;
            Thread hiloPlayer2 = new Thread(player2);
            hiloPlayer2.Start();
            hiloPlayer2.IsBackground = true;
            Thread hiloDisplay = new Thread(display);
            hiloDisplay.Start();
            hiloDisplay.IsBackground = true;

            
            while (!meta)
            {
                lock (l)
                {
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Contador común: " + contadorComun+" "+"\nGanador: "+ganador);
                    
                }

            }
            Console.ReadKey();




        }
    }
}
