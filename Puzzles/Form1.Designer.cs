using System.Windows.Forms;
namespace Puzzles
{
    partial class FormGameTable
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
            this.startGame = new System.Windows.Forms.Button();
            this.mainPicture = new System.Windows.Forms.PictureBox();
            this.autoConstruct = new System.Windows.Forms.Button();
            this.pictureText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // startGame
            // 
            this.startGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startGame.Location = new System.Drawing.Point(28, 435);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(110, 50);
            this.startGame.TabIndex = 2;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Visible = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // mainPicture
            // 
            this.mainPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPicture.Location = new System.Drawing.Point(658, 12);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(350, 350);
            this.mainPicture.TabIndex = 1;
            this.mainPicture.TabStop = false;
            this.mainPicture.Click += new System.EventHandler(this.mainPicture_Click);
            // 
            // autoConstruct
            // 
            this.autoConstruct.Enabled = false;
            this.autoConstruct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autoConstruct.Location = new System.Drawing.Point(748, 420);
            this.autoConstruct.Name = "autoConstruct";
            this.autoConstruct.Size = new System.Drawing.Size(110, 50);
            this.autoConstruct.TabIndex = 4;
            this.autoConstruct.Text = "Autoconstruct";
            this.autoConstruct.UseVisualStyleBackColor = true;
            this.autoConstruct.Click += new System.EventHandler(this.autoConstruct_Click);
            // 
            // pictureText
            // 
            this.pictureText.AutoSize = true;
            this.pictureText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pictureText.ForeColor = System.Drawing.Color.Maroon;
            this.pictureText.Location = new System.Drawing.Point(767, 157);
            this.pictureText.Name = "pictureText";
            this.pictureText.Size = new System.Drawing.Size(152, 16);
            this.pictureText.TabIndex = 5;
            this.pictureText.Text = "Click here to load image";
            this.pictureText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGameTable
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1356, 482);
            this.Controls.Add(this.pictureText);
            this.Controls.Add(this.autoConstruct);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.mainPicture);
            this.MinimumSize = new System.Drawing.Size(1364, 400);
            this.Name = "FormGameTable";
            this.Text = "Puzzles";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox mainPicture;
        private System.Windows.Forms.Button startGame;
        private Button autoConstruct;
        private Label pictureText;
    }
}

