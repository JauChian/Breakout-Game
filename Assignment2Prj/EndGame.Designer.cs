namespace Assignment2Prj
{
    partial class EndGame
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
            this.brnNextLevel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReplay = new System.Windows.Forms.Button();
            this.lblEndGame = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // brnNextLevel
            // 
            this.brnNextLevel.Font = new System.Drawing.Font("Broadway", 18F, System.Drawing.FontStyle.Bold);
            this.brnNextLevel.Location = new System.Drawing.Point(493, 329);
            this.brnNextLevel.Name = "brnNextLevel";
            this.brnNextLevel.Size = new System.Drawing.Size(248, 141);
            this.brnNextLevel.TabIndex = 2;
            this.brnNextLevel.Text = "Next Level";
            this.brnNextLevel.UseVisualStyleBackColor = true;
            this.brnNextLevel.Click += new System.EventHandler(this.brnNextLevel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Broadway", 18F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(875, 329);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(248, 141);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReplay
            // 
            this.btnReplay.Font = new System.Drawing.Font("Broadway", 18F, System.Drawing.FontStyle.Bold);
            this.btnReplay.Location = new System.Drawing.Point(94, 329);
            this.btnReplay.Name = "btnReplay";
            this.btnReplay.Size = new System.Drawing.Size(248, 141);
            this.btnReplay.TabIndex = 4;
            this.btnReplay.Text = "Try Again";
            this.btnReplay.UseVisualStyleBackColor = true;
            this.btnReplay.Click += new System.EventHandler(this.btnReplay_Click);
            // 
            // lblEndGame
            // 
            this.lblEndGame.AutoSize = true;
            this.lblEndGame.Font = new System.Drawing.Font("Broadway", 18F, System.Drawing.FontStyle.Bold);
            this.lblEndGame.Location = new System.Drawing.Point(539, 95);
            this.lblEndGame.Name = "lblEndGame";
            this.lblEndGame.Size = new System.Drawing.Size(28, 41);
            this.lblEndGame.TabIndex = 6;
            this.lblEndGame.Text = " ";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Broadway", 18F, System.Drawing.FontStyle.Bold);
            this.lblResult.Location = new System.Drawing.Point(539, 172);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(28, 41);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = " ";
            // 
            // EndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Assignment2Prj.Properties.Resources.BackgorundEndGame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1194, 690);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblEndGame);
            this.Controls.Add(this.btnReplay);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.brnNextLevel);
            this.Name = "EndGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "End Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button brnNextLevel;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReplay;
        public System.Windows.Forms.Label lblResult;
        public System.Windows.Forms.Label lblEndGame;
    }
}