namespace TextAdventureGame
{
    partial class WorldSelectionForm
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
            this.cbTitle = new System.Windows.Forms.ComboBox();
            this.btnMain = new System.Windows.Forms.Button();
            this.lblGreetings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbTitle
            // 
            this.cbTitle.FormattingEnabled = true;
            this.cbTitle.Location = new System.Drawing.Point(12, 81);
            this.cbTitle.Name = "cbTitle";
            this.cbTitle.Size = new System.Drawing.Size(260, 21);
            this.cbTitle.TabIndex = 0;
            // 
            // btnMain
            // 
            this.btnMain.Location = new System.Drawing.Point(12, 109);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(260, 23);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Create Game";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // lblGreetings
            // 
            this.lblGreetings.Location = new System.Drawing.Point(9, 6);
            this.lblGreetings.Name = "lblGreetings";
            this.lblGreetings.Size = new System.Drawing.Size(260, 72);
            this.lblGreetings.TabIndex = 2;
            this.lblGreetings.Text = "lblGreetings";
            // 
            // WorldSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 140);
            this.Controls.Add(this.lblGreetings);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.cbTitle);
            this.Name = "WorldSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Selection";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTitle;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Label lblGreetings;
    }
}