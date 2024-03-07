namespace Poker_Game
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.TestBox = new System.Windows.Forms.PictureBox();
            this.betButton = new System.Windows.Forms.PictureBox();
            this.checkButton = new System.Windows.Forms.PictureBox();
            this.foldButton = new System.Windows.Forms.PictureBox();
            this.playerImage1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.playerImage2 = new System.Windows.Forms.PictureBox();
            this.playerImage3 = new System.Windows.Forms.PictureBox();
            this.playerImage4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TestBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.betButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foldButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage4)).BeginInit();
            this.SuspendLayout();
            // 
            // TestBox
            // 
            this.TestBox.BackColor = System.Drawing.Color.Transparent;
            this.TestBox.Image = ((System.Drawing.Image)(resources.GetObject("TestBox.Image")));
            this.TestBox.InitialImage = null;
            this.TestBox.Location = new System.Drawing.Point(897, 326);
            this.TestBox.Name = "TestBox";
            this.TestBox.Size = new System.Drawing.Size(138, 204);
            this.TestBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TestBox.TabIndex = 0;
            this.TestBox.TabStop = false;
            // 
            // betButton
            // 
            this.betButton.BackColor = System.Drawing.Color.Transparent;
            this.betButton.Image = ((System.Drawing.Image)(resources.GetObject("betButton.Image")));
            this.betButton.Location = new System.Drawing.Point(1743, 821);
            this.betButton.Name = "betButton";
            this.betButton.Size = new System.Drawing.Size(150, 150);
            this.betButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.betButton.TabIndex = 2;
            this.betButton.TabStop = false;
            this.betButton.Click += new System.EventHandler(this.betButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.BackColor = System.Drawing.Color.Transparent;
            this.checkButton.Image = ((System.Drawing.Image)(resources.GetObject("checkButton.Image")));
            this.checkButton.Location = new System.Drawing.Point(1572, 821);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(150, 150);
            this.checkButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.checkButton.TabIndex = 3;
            this.checkButton.TabStop = false;
            // 
            // foldButton
            // 
            this.foldButton.BackColor = System.Drawing.Color.Transparent;
            this.foldButton.Image = ((System.Drawing.Image)(resources.GetObject("foldButton.Image")));
            this.foldButton.Location = new System.Drawing.Point(1399, 821);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(150, 150);
            this.foldButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.foldButton.TabIndex = 4;
            this.foldButton.TabStop = false;
            this.foldButton.Click += new System.EventHandler(this.foldButton_Click);
            // 
            // playerImage1
            // 
            this.playerImage1.BackColor = System.Drawing.Color.Transparent;
            this.playerImage1.Image = ((System.Drawing.Image)(resources.GetObject("playerImage1.Image")));
            this.playerImage1.Location = new System.Drawing.Point(885, 810);
            this.playerImage1.Name = "playerImage1";
            this.playerImage1.Size = new System.Drawing.Size(150, 150);
            this.playerImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerImage1.TabIndex = 5;
            this.playerImage1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(935, 740);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 67);
            this.label1.TabIndex = 6;
            this.label1.Text = "0";
            // 
            // playerImage2
            // 
            this.playerImage2.BackColor = System.Drawing.Color.Transparent;
            this.playerImage2.Image = ((System.Drawing.Image)(resources.GetObject("playerImage2.Image")));
            this.playerImage2.Location = new System.Drawing.Point(0, 465);
            this.playerImage2.Name = "playerImage2";
            this.playerImage2.Size = new System.Drawing.Size(150, 150);
            this.playerImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerImage2.TabIndex = 7;
            this.playerImage2.TabStop = false;
            // 
            // playerImage3
            // 
            this.playerImage3.BackColor = System.Drawing.Color.Transparent;
            this.playerImage3.Image = ((System.Drawing.Image)(resources.GetObject("playerImage3.Image")));
            this.playerImage3.Location = new System.Drawing.Point(1753, 465);
            this.playerImage3.Name = "playerImage3";
            this.playerImage3.Size = new System.Drawing.Size(150, 150);
            this.playerImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerImage3.TabIndex = 8;
            this.playerImage3.TabStop = false;
            // 
            // playerImage4
            // 
            this.playerImage4.BackColor = System.Drawing.Color.Transparent;
            this.playerImage4.Image = ((System.Drawing.Image)(resources.GetObject("playerImage4.Image")));
            this.playerImage4.Location = new System.Drawing.Point(876, 2);
            this.playerImage4.Name = "playerImage4";
            this.playerImage4.Size = new System.Drawing.Size(150, 150);
            this.playerImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.playerImage4.TabIndex = 10;
            this.playerImage4.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.playerImage4);
            this.Controls.Add(this.playerImage3);
            this.Controls.Add(this.playerImage2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playerImage1);
            this.Controls.Add(this.foldButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.betButton);
            this.Controls.Add(this.TestBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameForm";
            this.Text = "Poker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.TestBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.betButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foldButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerImage4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox TestBox;
        private PictureBox betButton;
        private PictureBox checkButton;
        private PictureBox foldButton;
        private PictureBox playerImage1;
        private Label label1;
        private PictureBox playerImage2;
        private PictureBox playerImage3;
        private PictureBox playerImage4;
    }
}