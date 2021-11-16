using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Program
    {
        

        static void Main(string[] args)
        {
            List<Caballo> caballos = new List<Caballo>();
            
            
            caballos.Add(new Caballo(1));
            caballos.Add(new Caballo(2));
            caballos.Add(new Caballo(3));
            caballos.Add(new Caballo(4));
            caballos.Add(new Caballo(5));
            
            object l = new object();
            Thread[] hiloCaballos = new Thread[caballos.Count];
            int c = 0;

            foreach (Caballo cab in caballos)
            {
                hiloCaballos[c] = new Thread(cab.correr);
                hiloCaballos[c].Start();
                c++;
            }


            //hiloCaballos[c-1].Join();
            lock (Caballo.l)
            {
                Monitor.Wait(Caballo.l);
            }
            Console.ReadKey();
            if (Caballo.llega)
            {

                lock (l)
                {
                   
                    Console.Clear();
                    Console.WriteLine("Ha ganado caballo {0}", Caballo.posicionGanador);

                    Console.ReadLine();

                }
                Console.ReadKey();
            }

            
        }
    }
}
