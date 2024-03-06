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
            button1 = new Button();
            TestBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)TestBox).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            // 
            // TestBox
            // 
            TestBox.BackColor = Color.GreenYellow;
            TestBox.Location = new Point(280, 95);
            TestBox.Name = "TestBox";
            TestBox.Size = new Size(99, 162);
            TestBox.SizeMode = PictureBoxSizeMode.StretchImage;
            TestBox.TabIndex = 0;
            TestBox.TabStop = false;
            // 
            // GameForm
            // 
            AutoSize = true;
            BackColor = Color.Green;
            ClientSize = new Size(1161, 658);
            Controls.Add(TestBox);
            ForeColor = Color.Black;
            Name = "GameForm";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)TestBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private PictureBox TestBox;
    }
}