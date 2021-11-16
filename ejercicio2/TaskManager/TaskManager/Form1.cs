using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        private Process[] procesos;
        public Form1()
        {
            InitializeComponent();
            
        }

       

        public int comprobaciones(string dato)
        {
            int datoVal = 0;
            try
            {
                datoVal = int.Parse(dato);
            }
            catch (System.FormatException)
            {
                //nose
            }
            catch (System.OverflowException)
            {
                //nose
            }
            return datoVal;
        }

        public string textoAdaptado(string textoProceso)
        {
            string textoAdaptado = "";
            if (textoProceso.Length > 15)
            {
                for (int i = 0; i < 15; i++)
                {
                    textoAdaptado += "" + textoProceso[i];


                }
                textoAdaptado += "...";
            }
            else
            {
                textoAdaptado = textoProceso;
            }

            return textoAdaptado;
        }

        public string devuelveArrayProcesos()
        {
            procesos = Process.GetProcesses();
            string procesoObtenido = "";
            Array.ForEach(procesos, proceso => {



                    procesoObtenido += string.Format("|{0,-10}|{1,-30}|{2,0}\r\n", proceso.Id,
                    textoAdaptado(proceso.ProcessName),
                    proceso.MainWindowTitle);


            });

            return procesoObtenido;
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            textBox1.Text += devuelveArrayProcesos();

            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            if (textBox2.Text != "" || textBox2.Text != null)
            {
                Process idProcesos = Process.GetProcessById(comprobaciones(textBox2.Text));
            
                textBox1.Text = "";


                textBox1.Text += "[PROGRAMA]";
                textBox1.Text += string.Format("\r\nID: {0,-10}\r\nNombre: {1,-30}\r\nTitulo: {2,0}\r\n", idProcesos.Id,
                        textoAdaptado(idProcesos.ProcessName),
                        textoAdaptado(idProcesos.MainWindowTitle));

                textBox1.Text += "[MODULES]";
                try
                {
                    foreach (ProcessModule module in idProcesos.Modules)
                    {
                        textBox1.Text += string.Format("\r\n\r\nFileName: {0}\r\nModuleName: {1}\r\n",module.FileName,module.ModuleName);
                    }

                    textBox1.Text += "[HILOS]";
                    foreach (ProcessThread hilo in idProcesos.Threads)
                    {
                        textBox1.Text += string.Format("\r\n\r\nTiempo comienzo: {0}\n\rID: {1}\r\n", hilo.StartTime,hilo.Id);
                    }

                }
                catch (Win32Exception)
                {
                    textBox1.Text = "error grave";
                }

            }
            


        }

       


        private void button3_Click(object sender, EventArgs e)
        {
            int numero;
            bool NoError = int.TryParse(textBox2.Text, out numero);

            if (NoError)
            {
                try
                {

                    Process idProcesos = Process.GetProcessById(numero);
                    idProcesos.CloseMainWindow();
                }
                catch (InvalidOperationException)
                {

                }
                catch (PlatformNotSupportedException)
                {

                }
                catch (ArgumentException)
                {

                }
                

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int numero;
            bool NoError = int.TryParse(textBox2.Text,out numero);

            if (NoError)
            {
                try
                {
                    Process idProcesos = Process.GetProcessById(numero);
                    idProcesos.Kill();

                }
                catch (System.NotSupportedException)
                {

                }
                catch (InvalidOperationException)
                {

                }
                catch (ArgumentException)
                {

                }

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string programa = textBox2.Text;
            try
            {
                Process.Start(programa);

            }
            catch (System.InvalidOperationException)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string busqueda = textBox2.Text;

            

            Process[] procesosObtenidos = Array.FindAll(procesos, proceso => proceso.ProcessName.StartsWith(busqueda));
            Array.ForEach(procesosObtenidos, procesoObtenido => {
                textBox1.Text += string.Format("\r\n{0}",procesoObtenido.ProcessName);
            });
        }
    }
}
