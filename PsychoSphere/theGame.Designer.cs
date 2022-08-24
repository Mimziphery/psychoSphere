
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
            this.Stage = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 20;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // Stage
            // 
            this.Stage.BackColor = System.Drawing.SystemColors.Control;
            this.Stage.Location = new System.Drawing.Point(-2, -1);
            this.Stage.Name = "Stage";
            this.Stage.Size = new System.Drawing.Size(1496, 597);
            this.Stage.TabIndex = 1;
            this.Stage.Paint += new System.Windows.Forms.PaintEventHandler(this.Stage_Paint);
            // 
            // theGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(1493, 589);
            this.Controls.Add(this.Stage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "theGame";
            this.Text = "theGame";
            this.Load += new System.EventHandler(this.theGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.theGame_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.theGame_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerTick;
        private System.Windows.Forms.Panel Stage;
    }
}