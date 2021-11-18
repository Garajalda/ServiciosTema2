
namespace Ejercicicio7
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fondo = new System.Windows.Forms.PictureBox();
            this.coco = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coco)).BeginInit();
            this.SuspendLayout();
            // 
            // fondo
            // 
            this.fondo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.fondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fondo.Location = new System.Drawing.Point(0, 0);
            this.fondo.Name = "fondo";
            this.fondo.Size = new System.Drawing.Size(632, 403);
            this.fondo.TabIndex = 0;
            this.fondo.TabStop = false;
            // 
            // coco
            // 
            this.coco.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.coco.Image = ((System.Drawing.Image)(resources.GetObject("coco.Image")));
            this.coco.Location = new System.Drawing.Point(0, 405);
            this.coco.Name = "coco";
            this.coco.Size = new System.Drawing.Size(29, 25);
            this.coco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.coco.TabIndex = 1;
            this.coco.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 403);
            this.Controls.Add(this.coco);
            this.Controls.Add(this.fondo);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Pac-Man";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.fondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox fondo;
        private System.Windows.Forms.PictureBox coco;
    }
}

