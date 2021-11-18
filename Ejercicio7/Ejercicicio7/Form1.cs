using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicicio7
{
    public partial class Form1 : Form
    {
        int cocoXLocation = 0;
        int cocoYLocation = 0;
        public Form1()
        {
            InitializeComponent();
           
            coco.Location = new Point(0, fondo.Size.Height - coco.Size.Height);

            cocoXLocation = 0;
            cocoYLocation = fondo.Size.Height - coco.Size.Height;
            
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Right)
            {
              
                if (coco.Location.X <fondo.Size.Width-coco.Size.Width)
                {

                    cocoXLocation += 5;
                }
                coco.Location = new Point(cocoXLocation, cocoYLocation);
                
            }

            if (e.KeyCode == Keys.Left)
            {
                if (coco.Location.X > 0)
                {
                    cocoXLocation -= 5;

                }
                coco.Location = new Point(cocoXLocation,cocoYLocation);
            }

            if (e.KeyCode == Keys.Down)
            {
                if (coco.Location.Y < fondo.Size.Height - coco.Size.Height)
                {
                    cocoYLocation += 5;
                }
                coco.Location = new Point(cocoXLocation,cocoYLocation);
            }

            if (e.KeyCode == Keys.Up)
            {
                if (cocoYLocation > 0)
                {
                    cocoYLocation -= 5;
                }
                coco.Location = new Point(cocoXLocation, cocoYLocation);
            }
        }


        
    }
}
