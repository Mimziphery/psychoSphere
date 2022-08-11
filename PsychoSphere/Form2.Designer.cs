
namespace PsychoSphere
{
    partial class exitPage
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.yesButton = new System.Windows.Forms.PictureBox();
            this.noButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yesButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noButton)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PsychoSphere.Properties.Resources.are_you_sure;
            this.pictureBox1.Location = new System.Drawing.Point(220, 197);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(357, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // yesButton
            // 
            this.yesButton.BackColor = System.Drawing.Color.Transparent;
            this.yesButton.Image = global::PsychoSphere.Properties.Resources.yes_button;
            this.yesButton.Location = new System.Drawing.Point(220, 338);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(138, 49);
            this.yesButton.TabIndex = 1;
            this.yesButton.TabStop = false;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            this.yesButton.MouseLeave += new System.EventHandler(this.yesButton_MouseLeave);
            this.yesButton.MouseHover += new System.EventHandler(this.yesButton_MouseHover);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.Color.Transparent;
            this.noButton.Image = global::PsychoSphere.Properties.Resources.no_button;
            this.noButton.Location = new System.Drawing.Point(477, 338);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(100, 50);
            this.noButton.TabIndex = 2;
            this.noButton.TabStop = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            this.noButton.MouseLeave += new System.EventHandler(this.noButton_MouseLeave);
            this.noButton.MouseHover += new System.EventHandler(this.noButton_MouseHover);
            // 
            // exitPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PsychoSphere.Properties.Resources.background_01_800x600;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(803, 604);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "exitPage";
            this.Text = "Exit";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yesButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox yesButton;
        private System.Windows.Forms.PictureBox noButton;
    }
}