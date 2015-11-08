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
            this.pictureText = new System.Windows.Forms.Label();
            this.autoConstruct = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puzzlesAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.mainPicture.BackColor = System.Drawing.SystemColors.Control;
            this.mainPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPicture.Location = new System.Drawing.Point(921, 12);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(365, 343);
            this.mainPicture.TabIndex = 1;
            this.mainPicture.TabStop = false;
            this.mainPicture.Click += new System.EventHandler(this.mainPicture_Click);
            // 
            // pictureText
            // 
            this.pictureText.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pictureText.ForeColor = System.Drawing.Color.Maroon;
            this.pictureText.Location = new System.Drawing.Point(1033, 30);
            this.pictureText.Name = "pictureText";
            this.pictureText.Size = new System.Drawing.Size(158, 21);
            this.pictureText.TabIndex = 5;
            this.pictureText.Text = "Click here to load image";
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1356, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puzzlesAmountToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // puzzlesAmountToolStripMenuItem
            // 
            this.puzzlesAmountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x7ToolStripMenuItem,
            this.x3ToolStripMenuItem});
            this.puzzlesAmountToolStripMenuItem.Name = "puzzlesAmountToolStripMenuItem";
            this.puzzlesAmountToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.puzzlesAmountToolStripMenuItem.Text = "Puzzles Amount";
            // 
            // x7ToolStripMenuItem
            // 
            this.x7ToolStripMenuItem.Name = "x7ToolStripMenuItem";
            this.x7ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.x7ToolStripMenuItem.Text = "4 x 5";
            this.x7ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
            // 
            // x3ToolStripMenuItem
            // 
            this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            this.x3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.x3ToolStripMenuItem.Text = "3 x 4";
            this.x3ToolStripMenuItem.Click += new System.EventHandler(this.x3ToolStripMenuItem_Click);
            // 
            // FormGameTable
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1356, 482);
            this.Controls.Add(this.pictureText);
            this.Controls.Add(this.mainPicture);
            this.Controls.Add(this.autoConstruct);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1364, 400);
            this.Name = "FormGameTable";
            this.Text = "Puzzles";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox mainPicture;
        private System.Windows.Forms.Button startGame;
        private Button autoConstruct;
        private Label pictureText;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem puzzlesAmountToolStripMenuItem;
        private ToolStripMenuItem x7ToolStripMenuItem;
        private ToolStripMenuItem x3ToolStripMenuItem;
    }
}

