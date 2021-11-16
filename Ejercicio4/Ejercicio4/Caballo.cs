using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Caballo 
   {
        private int posicion;
        
        public Caballo(int posicion)
        {

            this.posicion = posicion;
        }

        public int Posicion
        {
            set
            {

                posicion = value;
            }
            get
            {
                return posicion;
            }
        }

        public static int posicionGanador = 0;

        public static object l = new object();
        public static bool llega = false;
        int x = 0;
        Random rnd = new Random();
        public void correr()
        {
           
            while (!llega)
            {
                lock (l)
                {
                   if (!llega)
                    {
                        
                        x++;

                        
                        Console.SetCursorPosition(x,posicion);

                        Console.Write("  ");
                        Console.Write(" ****");


                        if (x == 50)
                        {
                             

                                Monitor.Pulse(l);
                             
                            llega = true;
                            
                            Console.Write(" ] WIN!");
                            posicionGanador = Posicion;
                            
                        }
                        if (rnd.Next(0, 5) == 2)
                        {
                          Thread.Sleep(rnd.Next(50, 100));
                        }

                    }
                    
                }
                Thread.Sleep(200);
               
            
            }




        }
    }
}
