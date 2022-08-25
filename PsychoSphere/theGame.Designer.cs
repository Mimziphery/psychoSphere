
namespace PsychoSphere
{
    partial class theGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerTick = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 20;
            // 
            // theGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.BackgroundImage = global::PsychoSphere.Properties.Resources.dvizecka_pozadina;
            this.ClientSize = new System.Drawing.Size(1351, 589);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "theGame";
            this.Text = "theGame";
            this.Load += new System.EventHandler(this.theGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.theGame_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerTick;
    }
}