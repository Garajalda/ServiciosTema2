using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio1
{
    class Program
    {


        static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");
        }
        static void f3()
        {
            Console.WriteLine("C");
        }


        public delegate void MyDelegate();
        public static void MenuGenerator(string[] opciones, MyDelegate[] d)
        {

            bool salir = false;
            while (!salir)
            {

                //MENU
                if (opciones.Length == d.Length)
                {

                    Console.WriteLine("Dame opcion: ");
                    int i = 0;
                    Array.ForEach(opciones, (string opcion) => {  
                        Console.WriteLine("{0}: {1}", i+1, opcion);
                        i++;
                    });



                    Console.WriteLine("{0}: Exit", opciones.Length + 1);


                    try
                    {

                        int num = int.Parse(Console.ReadLine());

                        try
                        {
                            d[num - 1]();

                        }
                        catch (System.IndexOutOfRangeException)
                        {

                        }
                        if (opciones.Length == num - 1)
                        {
                            salir = true;
                            Console.WriteLine("Adios.");
                            Console.ReadKey();

                        }





                    }
                    catch (System.OverflowException)
                    {
                        Console.WriteLine("Numero fuera de rango.");
                    }
                    catch (System.FormatException)
                    {

                        Console.WriteLine("Opcion no valida, vuelva a intentarlo.");
                    }
                }
                else
                {
                    salir = true;
                    Console.WriteLine("El numero de opciones no es compatible.");
                    Console.ReadKey();
                }

            }

        }
        static void Main(string[] args)
        {
            
            MenuGenerator(new string[] { "Op1", "Op2", "Op3"},
                          new MyDelegate[] { () => Console.WriteLine("A"), () =>Console.WriteLine("B"), () => Console.WriteLine("C") });
            
          
           




        }
    }


}
