namespace Adventure_Game_Engine
{
    partial class AccessPointForm
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
            this.cbLocN = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDirN = new System.Windows.Forms.Label();
            this.btnMoreN = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbLocNE = new System.Windows.Forms.ComboBox();
            this.btnMoreNE = new System.Windows.Forms.Button();
            this.lblDirNE = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbLocSE = new System.Windows.Forms.ComboBox();
            this.btnMoreSE = new System.Windows.Forms.Button();
            this.lblDirSE = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbLocE = new System.Windows.Forms.ComboBox();
            this.btnMoreE = new System.Windows.Forms.Button();
            this.lblDirE = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbLocNW = new System.Windows.Forms.ComboBox();
            this.btnMoreNW = new System.Windows.Forms.Button();
            this.lblDirNW = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbLocSW = new System.Windows.Forms.ComboBox();
            this.btnMoreSW = new System.Windows.Forms.Button();
            this.lblDirSW = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbLocW = new System.Windows.Forms.ComboBox();
            this.btnMoreW = new System.Windows.Forms.Button();
            this.lblDirW = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbLocS = new System.Windows.Forms.ComboBox();
            this.btnMoreS = new System.Windows.Forms.Button();
            this.lblDirS = new System.Windows.Forms.Label();
            this.cbZoneN = new System.Windows.Forms.ComboBox();
            this.cbZoneNE = new System.Windows.Forms.ComboBox();
            this.cbZoneSE = new System.Windows.Forms.ComboBox();
            this.cbZoneE = new System.Windows.Forms.ComboBox();
            this.cbZoneSW = new System.Windows.Forms.ComboBox();
            this.cbZoneS = new System.Windows.Forms.ComboBox();
            this.cbZoneNW = new System.Windows.Forms.ComboBox();
            this.cbZoneW = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLocN
            // 
            this.cbLocN.FormattingEnabled = true;
            this.cbLocN.Location = new System.Drawing.Point(305, 3);
            this.cbLocN.Name = "cbLocN";
            this.cbLocN.Size = new System.Drawing.Size(259, 21);
            this.cbLocN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 77);
            this.label1.TabIndex = 4;
            this.label1.Text = "TODO : Navigation logic when a door is closed on entry, what it needs to be opene" +
    "d and when it could be closed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Direction";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(339, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select the location linked to that access point or type a new title that will cre" +
    "ate a location,";
            // 
            // lblDirN
            // 
            this.lblDirN.AutoSize = true;
            this.lblDirN.Location = new System.Drawing.Point(15, 6);
            this.lblDirN.Name = "lblDirN";
            this.lblDirN.Size = new System.Drawing.Size(15, 13);
            this.lblDirN.TabIndex = 7;
            this.lblDirN.Text = "N";
            this.lblDirN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMoreN
            // 
            this.btnMoreN.Location = new System.Drawing.Point(572, 2);
            this.btnMoreN.Name = "btnMoreN";
            this.btnMoreN.Size = new System.Drawing.Size(57, 23);
            this.btnMoreN.TabIndex = 2;
            this.btnMoreN.Text = "More...";
            this.btnMoreN.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbLocN);
            this.panel1.Controls.Add(this.btnMoreN);
            this.panel1.Controls.Add(this.lblDirN);
            this.panel1.Controls.Add(this.cbZoneN);
            this.panel1.Location = new System.Drawing.Point(16, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 27);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbLocNE);
            this.panel2.Controls.Add(this.btnMoreNE);
            this.panel2.Controls.Add(this.lblDirNE);
            this.panel2.Controls.Add(this.cbZoneNE);
            this.panel2.Location = new System.Drawing.Point(16, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 27);
            this.panel2.TabIndex = 10;
            // 
            // cbLocNE
            // 
            this.cbLocNE.FormattingEnabled = true;
            this.cbLocNE.Location = new System.Drawing.Point(305, 3);
            this.cbLocNE.Name = "cbLocNE";
            this.cbLocNE.Size = new System.Drawing.Size(259, 21);
            this.cbLocNE.TabIndex = 4;
            // 
            // btnMoreNE
            // 
            this.btnMoreNE.Location = new System.Drawing.Point(572, 2);
            this.btnMoreNE.Name = "btnMoreNE";
            this.btnMoreNE.Size = new System.Drawing.Size(57, 23);
            this.btnMoreNE.TabIndex = 5;
            this.btnMoreNE.Text = "More...";
            this.btnMoreNE.UseVisualStyleBackColor = true;
            // 
            // lblDirNE
            // 
            this.lblDirNE.AutoSize = true;
            this.lblDirNE.Location = new System.Drawing.Point(12, 6);
            this.lblDirNE.Name = "lblDirNE";
            this.lblDirNE.Size = new System.Drawing.Size(22, 13);
            this.lblDirNE.TabIndex = 7;
            this.lblDirNE.Text = "NE";
            this.lblDirNE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbLocSE);
            this.panel3.Controls.Add(this.btnMoreSE);
            this.panel3.Controls.Add(this.lblDirSE);
            this.panel3.Controls.Add(this.cbZoneSE);
            this.panel3.Location = new System.Drawing.Point(16, 143);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 27);
            this.panel3.TabIndex = 12;
            // 
            // cbLocSE
            // 
            this.cbLocSE.FormattingEnabled = true;
            this.cbLocSE.Location = new System.Drawing.Point(305, 3);
            this.cbLocSE.Name = "cbLocSE";
            this.cbLocSE.Size = new System.Drawing.Size(259, 21);
            this.cbLocSE.TabIndex = 10;
            // 
            // btnMoreSE
            // 
            this.btnMoreSE.Location = new System.Drawing.Point(572, 2);
            this.btnMoreSE.Name = "btnMoreSE";
            this.btnMoreSE.Size = new System.Drawing.Size(57, 23);
            this.btnMoreSE.TabIndex = 11;
            this.btnMoreSE.Text = "More...";
            this.btnMoreSE.UseVisualStyleBackColor = true;
            // 
            // lblDirSE
            // 
            this.lblDirSE.AutoSize = true;
            this.lblDirSE.Location = new System.Drawing.Point(12, 6);
            this.lblDirSE.Name = "lblDirSE";
            this.lblDirSE.Size = new System.Drawing.Size(21, 13);
            this.lblDirSE.TabIndex = 7;
            this.lblDirSE.Text = "SE";
            this.lblDirSE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbLocE);
            this.panel4.Controls.Add(this.btnMoreE);
            this.panel4.Controls.Add(this.lblDirE);
            this.panel4.Controls.Add(this.cbZoneE);
            this.panel4.Location = new System.Drawing.Point(16, 116);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(634, 27);
            this.panel4.TabIndex = 11;
            // 
            // cbLocE
            // 
            this.cbLocE.FormattingEnabled = true;
            this.cbLocE.Location = new System.Drawing.Point(305, 3);
            this.cbLocE.Name = "cbLocE";
            this.cbLocE.Size = new System.Drawing.Size(259, 21);
            this.cbLocE.TabIndex = 7;
            // 
            // btnMoreE
            // 
            this.btnMoreE.Location = new System.Drawing.Point(572, 2);
            this.btnMoreE.Name = "btnMoreE";
            this.btnMoreE.Size = new System.Drawing.Size(57, 23);
            this.btnMoreE.TabIndex = 8;
            this.btnMoreE.Text = "More...";
            this.btnMoreE.UseVisualStyleBackColor = true;
            // 
            // lblDirE
            // 
            this.lblDirE.AutoSize = true;
            this.lblDirE.Location = new System.Drawing.Point(15, 6);
            this.lblDirE.Name = "lblDirE";
            this.lblDirE.Size = new System.Drawing.Size(14, 13);
            this.lblDirE.TabIndex = 7;
            this.lblDirE.Text = "E";
            this.lblDirE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbZoneNW);
            this.panel5.Controls.Add(this.cbLocNW);
            this.panel5.Controls.Add(this.btnMoreNW);
            this.panel5.Controls.Add(this.lblDirNW);
            this.panel5.Location = new System.Drawing.Point(16, 251);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(634, 27);
            this.panel5.TabIndex = 16;
            // 
            // cbLocNW
            // 
            this.cbLocNW.FormattingEnabled = true;
            this.cbLocNW.Location = new System.Drawing.Point(305, 3);
            this.cbLocNW.Name = "cbLocNW";
            this.cbLocNW.Size = new System.Drawing.Size(259, 21);
            this.cbLocNW.TabIndex = 22;
            // 
            // btnMoreNW
            // 
            this.btnMoreNW.Location = new System.Drawing.Point(572, 2);
            this.btnMoreNW.Name = "btnMoreNW";
            this.btnMoreNW.Size = new System.Drawing.Size(57, 23);
            this.btnMoreNW.TabIndex = 23;
            this.btnMoreNW.Text = "More...";
            this.btnMoreNW.UseVisualStyleBackColor = true;
            // 
            // lblDirNW
            // 
            this.lblDirNW.AutoSize = true;
            this.lblDirNW.Location = new System.Drawing.Point(12, 6);
            this.lblDirNW.Name = "lblDirNW";
            this.lblDirNW.Size = new System.Drawing.Size(26, 13);
            this.lblDirNW.TabIndex = 7;
            this.lblDirNW.Text = "NW";
            this.lblDirNW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbLocSW);
            this.panel6.Controls.Add(this.btnMoreSW);
            this.panel6.Controls.Add(this.cbZoneSW);
            this.panel6.Controls.Add(this.lblDirSW);
            this.panel6.Location = new System.Drawing.Point(16, 197);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(634, 27);
            this.panel6.TabIndex = 14;
            // 
            // cbLocSW
            // 
            this.cbLocSW.FormattingEnabled = true;
            this.cbLocSW.Location = new System.Drawing.Point(305, 3);
            this.cbLocSW.Name = "cbLocSW";
            this.cbLocSW.Size = new System.Drawing.Size(259, 21);
            this.cbLocSW.TabIndex = 16;
            // 
            // btnMoreSW
            // 
            this.btnMoreSW.Location = new System.Drawing.Point(572, 2);
            this.btnMoreSW.Name = "btnMoreSW";
            this.btnMoreSW.Size = new System.Drawing.Size(57, 23);
            this.btnMoreSW.TabIndex = 17;
            this.btnMoreSW.Text = "More...";
            this.btnMoreSW.UseVisualStyleBackColor = true;
            // 
            // lblDirSW
            // 
            this.lblDirSW.AutoSize = true;
            this.lblDirSW.Location = new System.Drawing.Point(12, 6);
            this.lblDirSW.Name = "lblDirSW";
            this.lblDirSW.Size = new System.Drawing.Size(25, 13);
            this.lblDirSW.TabIndex = 7;
            this.lblDirSW.Text = "SW";
            this.lblDirSW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbLocW);
            this.panel7.Controls.Add(this.cbZoneW);
            this.panel7.Controls.Add(this.btnMoreW);
            this.panel7.Controls.Add(this.lblDirW);
            this.panel7.Location = new System.Drawing.Point(16, 224);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(634, 27);
            this.panel7.TabIndex = 15;
            // 
            // cbLocW
            // 
            this.cbLocW.FormattingEnabled = true;
            this.cbLocW.Location = new System.Drawing.Point(305, 3);
            this.cbLocW.Name = "cbLocW";
            this.cbLocW.Size = new System.Drawing.Size(259, 21);
            this.cbLocW.TabIndex = 19;
            // 
            // btnMoreW
            // 
            this.btnMoreW.Location = new System.Drawing.Point(572, 2);
            this.btnMoreW.Name = "btnMoreW";
            this.btnMoreW.Size = new System.Drawing.Size(57, 23);
            this.btnMoreW.TabIndex = 20;
            this.btnMoreW.Text = "More...";
            this.btnMoreW.UseVisualStyleBackColor = true;
            // 
            // lblDirW
            // 
            this.lblDirW.AutoSize = true;
            this.lblDirW.Location = new System.Drawing.Point(15, 6);
            this.lblDirW.Name = "lblDirW";
            this.lblDirW.Size = new System.Drawing.Size(18, 13);
            this.lblDirW.TabIndex = 7;
            this.lblDirW.Text = "W";
            this.lblDirW.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cbLocS);
            this.panel8.Controls.Add(this.btnMoreS);
            this.panel8.Controls.Add(this.lblDirS);
            this.panel8.Controls.Add(this.cbZoneS);
            this.panel8.Location = new System.Drawing.Point(16, 170);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(634, 27);
            this.panel8.TabIndex = 13;
            // 
            // cbLocS
            // 
            this.cbLocS.FormattingEnabled = true;
            this.cbLocS.Location = new System.Drawing.Point(305, 3);
            this.cbLocS.Name = "cbLocS";
            this.cbLocS.Size = new System.Drawing.Size(259, 21);
            this.cbLocS.TabIndex = 13;
            // 
            // btnMoreS
            // 
            this.btnMoreS.Location = new System.Drawing.Point(572, 2);
            this.btnMoreS.Name = "btnMoreS";
            this.btnMoreS.Size = new System.Drawing.Size(57, 23);
            this.btnMoreS.TabIndex = 14;
            this.btnMoreS.Text = "More...";
            this.btnMoreS.UseVisualStyleBackColor = true;
            // 
            // lblDirS
            // 
            this.lblDirS.AutoSize = true;
            this.lblDirS.Location = new System.Drawing.Point(15, 6);
            this.lblDirS.Name = "lblDirS";
            this.lblDirS.Size = new System.Drawing.Size(14, 13);
            this.lblDirS.TabIndex = 7;
            this.lblDirS.Text = "S";
            this.lblDirS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbZoneN
            // 
            this.cbZoneN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoneN.FormattingEnabled = true;
            this.cbZoneN.Location = new System.Drawing.Point(38, 3);
            this.cbZoneN.Name = "cbZoneN";
            this.cbZoneN.Size = new System.Drawing.Size(261, 21);
            this.cbZoneN.TabIndex = 0;
            // 
            // cbZoneNE
            // 
            this.cbZoneNE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoneNE.FormattingEnabled = true;
            this.cbZoneNE.Location = new System.Drawing.Point(39, 3);
            this.cbZoneNE.Name = "cbZoneNE";
            this.cbZoneNE.Size = new System.Drawing.Size(261, 21);
            this.cbZoneNE.TabIndex = 3;
            // 
            // cbZoneSE
            // 
            this.cbZoneSE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoneSE.FormattingEnabled = true;
            this.cbZoneSE.Location = new System.Drawing.Point(39, 3);
            this.cbZoneSE.Name = "cbZoneSE";
            this.cbZoneSE.Size = new System.Drawing.Size(261, 21);
            this.cbZoneSE.TabIndex = 9;
            // 
            // cbZoneE
            // 
            this.cbZoneE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoneE.FormattingEnabled = true;
            this.cbZoneE.Location = new System.Drawing.Point(39, 3);
            this.cbZoneE.Name = "cbZoneE";
            this.cbZoneE.Size = new System.Drawing.Size(261, 21);
            this.cbZoneE.TabIndex = 6;
            // 
            // cbZoneSW
            // 
            this.cbZoneSW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoneSW.FormattingEnabled = true;
            this.cbZoneSW.Location = new System.Drawing.Point(39, 3);
            this.cbZoneSW.Name = "cbZoneSW";
            this.cbZoneSW.Size = new System.Drawing.Size(261, 21);
            this.cbZoneSW.TabIndex = 15;
            // 
            // cbZoneS
            // 
            this.cbZoneS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoneS.FormattingEnabled = true;
            this.cbZoneS.Location = new System.Drawing.Point(39, 3);
            this.cbZoneS.Name = "cbZoneS";
            this.cbZoneS.Size = new System.Drawing.Size(261, 21);
            this.cbZoneS.TabIndex = 12;
            // 
            // cbZoneNW
            // 
            this.cbZoneNW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoneNW.FormattingEnabled = true;
            this.cbZoneNW.Location = new System.Drawing.Point(39, 3);
            this.cbZoneNW.Name = "cbZoneNW";
            this.cbZoneNW.Size = new System.Drawing.Size(261, 21);
            this.cbZoneNW.TabIndex = 21;
            // 
            // cbZoneW
            // 
            this.cbZoneW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZoneW.FormattingEnabled = true;
            this.cbZoneW.Location = new System.Drawing.Point(39, 3);
            this.cbZoneW.Name = "cbZoneW";
            this.cbZoneW.Size = new System.Drawing.Size(261, 21);
            this.cbZoneW.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(69, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "Select a zone";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(16, 284);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 50);
            this.btnApply.TabIndex = 24;
            this.btnApply.Text = "Apply Changes";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(97, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 50);
            this.btnCancel.TabIndex = 253;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AccessPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 432);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AccessPointForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit access points";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDirN;
        private System.Windows.Forms.Button btnMoreN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbLocNE;
        private System.Windows.Forms.Button btnMoreNE;
        private System.Windows.Forms.Label lblDirNE;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbLocSE;
        private System.Windows.Forms.Button btnMoreSE;
        private System.Windows.Forms.Label lblDirSE;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbLocE;
        private System.Windows.Forms.Button btnMoreE;
        private System.Windows.Forms.Label lblDirE;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cbLocNW;
        private System.Windows.Forms.Button btnMoreNW;
        private System.Windows.Forms.Label lblDirNW;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cbLocSW;
        private System.Windows.Forms.Button btnMoreSW;
        private System.Windows.Forms.Label lblDirSW;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cbLocW;
        private System.Windows.Forms.Button btnMoreW;
        private System.Windows.Forms.Label lblDirW;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ComboBox cbLocS;
        private System.Windows.Forms.Button btnMoreS;
        private System.Windows.Forms.Label lblDirS;
        private System.Windows.Forms.ComboBox cbZoneN;
        private System.Windows.Forms.ComboBox cbZoneNE;
        private System.Windows.Forms.ComboBox cbZoneSE;
        private System.Windows.Forms.ComboBox cbZoneE;
        private System.Windows.Forms.ComboBox cbZoneNW;
        private System.Windows.Forms.ComboBox cbZoneSW;
        private System.Windows.Forms.ComboBox cbZoneW;
        private System.Windows.Forms.ComboBox cbZoneS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}