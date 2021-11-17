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
        

        bool pausar = true;
        
        
        static object l = new object();


        public void foo()
        {
                
                while (true)
                {
                    lock (l)
                    {
                    
                        if (pausar)
                        {
                            Monitor.Wait(l);
                  
                        }

                        increment();
                   
                   
                    }
                        Thread.Sleep(interval);  

                
                

                }
            
        }
        public void run()
        {
          
                lock (l)
                {
                    pausar = false;
                    Monitor.Pulse(l);

                
      
                
                }

            
            
        }

        public void pause()
        {
           

                lock (l)
                {
                    pausar = true;
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
