using System.Windows.Forms;
namespace Puzzles
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadPicture = new System.Windows.Forms.Button();
            this.brakeImage = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buildPicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loadPicture
            // 
            this.loadPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadPicture.Location = new System.Drawing.Point(900, 435);
            this.loadPicture.Name = "loadPicture";
            this.loadPicture.Size = new System.Drawing.Size(100, 50);
            this.loadPicture.TabIndex = 0;
            this.loadPicture.Text = "Load Image";
            this.loadPicture.UseVisualStyleBackColor = true;
            this.loadPicture.Click += new System.EventHandler(this.loadPicture_Click);
            // 
            // brakeImage
            // 
            this.brakeImage.Enabled = false;
            this.brakeImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.brakeImage.Location = new System.Drawing.Point(28, 435);
            this.brakeImage.Name = "brakeImage";
            this.brakeImage.Size = new System.Drawing.Size(100, 50);
            this.brakeImage.TabIndex = 2;
            this.brakeImage.Text = "Brake Image";
            this.brakeImage.UseVisualStyleBackColor = true;
            this.brakeImage.Click += new System.EventHandler(this.brakeImage_Click);
            // 
            // closeButton
            // 
            this.closeButton.Image = global::Puzzles.Properties.Resources.Delete32;
            this.closeButton.Location = new System.Drawing.Point(968, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(40, 40);
            this.closeButton.TabIndex = 3;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(658, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // buildPicture
            // 
            this.buildPicture.Enabled = false;
            this.buildPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildPicture.Location = new System.Drawing.Point(831, 378);
            this.buildPicture.Name = "buildPicture";
            this.buildPicture.Size = new System.Drawing.Size(100, 50);
            this.buildPicture.TabIndex = 4;
            this.buildPicture.Text = "Build Image";
            this.buildPicture.UseVisualStyleBackColor = true;
            this.buildPicture.Click += new System.EventHandler(this.buildPicture_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1020, 482);
            this.Controls.Add(this.buildPicture);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.brakeImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loadPicture);
            this.Name = "Form1";
            this.Text = "Load Image";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button loadPicture;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button brakeImage;
        private Button closeButton;
        private Button buildPicture;
    }
}

