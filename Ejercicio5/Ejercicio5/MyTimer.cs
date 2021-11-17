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

                    
                if (!ejecutar)
                {
                    Monitor.Wait(l);
                }
                while (ejecutar)
                {
                               
                    increment(); 
                    Thread.Sleep(interval);
                        
                   
                }

                
                

            }
            
        }
        public void run()
        {
            lock (l)
            {
                
                ejecutar = true;
                Monitor.Pulse(l);
                
      
                
            }
            
        }

        public void pause()
        {
            
            lock (l)
            {
                ejecutar = false;

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
