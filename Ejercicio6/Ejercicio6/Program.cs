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

        public static void player1()
        {
            int aleatorio = 0;
    
            while (true)
            {

                lock (l)
                {

                    aleatorio = rnd.Next(1, 11);
                       
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Player1: "+aleatorio+" ");
                    
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
                    
                    aleatorio = rnd.Next(1, 11);

                    Console.SetCursorPosition(0, 2);
                    Console.Write("Player2: "+aleatorio+" ");

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
                    Console.SetCursorPosition(0,4);
                    Console.Write(caracter[caracterId]+" Loading...");
                    caracterId++;
                    if (caracterId == caracter.Count())
                    {
                        caracterId = 0;
                    }
                    
                }
                Thread.Sleep(200);
                
            }
        }

       
        static void Main(string[] args)
        {
            
            Thread hiloPlayer1 = new Thread(player1);
            hiloPlayer1.Start();
          
            Thread hiloPlayer2 = new Thread(player2);
            hiloPlayer2.Start();

            Thread hiloDisplay = new Thread(display);
            hiloDisplay.Start();
           
        }
    }
}
