using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {


        static object l = new object();


        static int competicion = 0;

        static bool llega = false;
        static bool hilo = false;

        static void Main(string[] args)
        {
            Thread thread = new Thread(() => {
                while (!llega)
                {
                    lock (l)
                    {

                        if (!llega)
                        {

                            competicion++;

                           Console.WriteLine("Hilo 1 : {0}", competicion);

                            if (competicion == 1000)
                            {
                                llega = true;
                                hilo = true;


                            }

                        }
                        //  Console.ReadKemy();
                    }



                }
            });
            Thread thread1 = new Thread(() => {
                while (!llega)
                {
                    lock (l)
                    {

                        if (!llega)
                        {

                            competicion--;

                            Console.WriteLine("Hilo 2 : {0}", competicion);
                            if (competicion == -1000)
                            {
                                llega = true;
                                hilo = false;

                            }

                        }

                    }

                }
            });

            thread.Start();
            thread1.Start();



           
            
                thread1.Join();
           

            
            Console.WriteLine($"Ha ganado hilo {(hilo?1:2)}");

            Console.ReadKey();
            //si hace hilo.



        }

    }
}
