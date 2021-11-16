using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio5
{
    class MyTimer
    {

        Program.MyDelegate increment;

        public int interval = 0;
        
        bool ejecutar = false;
        
        
        static object l = new object();


        public void foo()
        {
            lock (l)
            {

                    
                    while (ejecutar)
                    {
                        
                        increment();
                        ejecutar = false; 
                        Thread.Sleep(interval);
                        
                    }

                
                

            }
            
        }
        public void run()
        {
            lock (l)
            {
                
                ejecutar = true;
                if (ejecutar)
                {
                    Monitor.Pulse(l);
                     foo();
                }
                else
                {
                    ejecutar = false;
                    Monitor.Wait(l);
                }

               
                
                
                    
                
            }
            
        }

        public void pause()
        {
            
            lock (l)
            {
                ejecutar = false;
                if (!ejecutar)
                {

                    Monitor.Pulse(l);
                }
                else
                {
                    ejecutar = true;
                    Monitor.Wait(l);
                }
               

            }
        }

        
        public MyTimer(Program.MyDelegate d)
        {
            
            increment = d;
            Thread hilo = new Thread(foo);
           
            hilo.Start();
            
            
        }

    }
}
