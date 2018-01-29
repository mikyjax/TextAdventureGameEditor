namespace Adventure_Game_Engine
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
            this.cbLocationChoice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLocDesc = new System.Windows.Forms.TextBox();
            this.cbApDest0 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApGo0 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLocName = new System.Windows.Forms.TextBox();
            this.btnUpdateDb = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.pnlAp0 = new System.Windows.Forms.Panel();
            this.cbApDir0 = new System.Windows.Forms.ComboBox();
            this.cbApDest3 = new System.Windows.Forms.ComboBox();
            this.btnApGo3 = new System.Windows.Forms.Button();
            this.cbApDir3 = new System.Windows.Forms.ComboBox();
            this.pnlAp3 = new System.Windows.Forms.Panel();
            this.cbApDest2 = new System.Windows.Forms.ComboBox();
            this.btnApGo2 = new System.Windows.Forms.Button();
            this.cbApDir2 = new System.Windows.Forms.ComboBox();
            this.pnlAp2 = new System.Windows.Forms.Panel();
            this.cbApDest1 = new System.Windows.Forms.ComboBox();
            this.btnApGo1 = new System.Windows.Forms.Button();
            this.cbApDir1 = new System.Windows.Forms.ComboBox();
            this.pnlAp1 = new System.Windows.Forms.Panel();
            this.pnlAp5 = new System.Windows.Forms.Panel();
            this.cbApDir5 = new System.Windows.Forms.ComboBox();
            this.btnApGo5 = new System.Windows.Forms.Button();
            this.cbApDest5 = new System.Windows.Forms.ComboBox();
            this.pnlAp6 = new System.Windows.Forms.Panel();
            this.cbApDir6 = new System.Windows.Forms.ComboBox();
            this.btnApGo6 = new System.Windows.Forms.Button();
            this.cbApDest6 = new System.Windows.Forms.ComboBox();
            this.pnlAp7 = new System.Windows.Forms.Panel();
            this.cbApDir7 = new System.Windows.Forms.ComboBox();
            this.btnApGo7 = new System.Windows.Forms.Button();
            this.cbApDest7 = new System.Windows.Forms.ComboBox();
            this.pnlAp4 = new System.Windows.Forms.Panel();
            this.cbApDir4 = new System.Windows.Forms.ComboBox();
            this.btnApGo4 = new System.Windows.Forms.Button();
            this.cbApDest4 = new System.Windows.Forms.ComboBox();
            this.pnlAp0.SuspendLayout();
            this.pnlAp3.SuspendLayout();
            this.pnlAp2.SuspendLayout();
            this.pnlAp1.SuspendLayout();
            this.pnlAp5.SuspendLayout();
            this.pnlAp6.SuspendLayout();
            this.pnlAp7.SuspendLayout();
            this.pnlAp4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLocationChoice
            // 
            this.cbLocationChoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLocationChoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLocationChoice.FormattingEnabled = true;
            this.cbLocationChoice.Location = new System.Drawing.Point(96, 15);
            this.cbLocationChoice.Name = "cbLocationChoice";
            this.cbLocationChoice.Size = new System.Drawing.Size(241, 21);
            this.cbLocationChoice.TabIndex = 0;
            this.cbLocationChoice.SelectedIndexChanged += new System.EventHandler(this.SelectRoom);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select location";
            // 
            // tbLocDesc
            // 
            this.tbLocDesc.Location = new System.Drawing.Point(14, 103);
            this.tbLocDesc.Multiline = true;
            this.tbLocDesc.Name = "tbLocDesc";
            this.tbLocDesc.Size = new System.Drawing.Size(362, 263);
            this.tbLocDesc.TabIndex = 2;
            // 
            // cbApDest0
            // 
            this.cbApDest0.FormattingEnabled = true;
            this.cbApDest0.Location = new System.Drawing.Point(52, 4);
            this.cbApDest0.Name = "cbApDest0";
            this.cbApDest0.Size = new System.Drawing.Size(133, 21);
            this.cbApDest0.TabIndex = 4;
            this.cbApDest0.TextChanged += new System.EventHandler(this.accessPointCBTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, -14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Access Point";
            // 
            // btnApGo0
            // 
            this.btnApGo0.Location = new System.Drawing.Point(191, 3);
            this.btnApGo0.Name = "btnApGo0";
            this.btnApGo0.Size = new System.Drawing.Size(78, 23);
            this.btnApGo0.TabIndex = 5;
            this.btnApGo0.Text = "New Room";
            this.btnApGo0.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Location Name";
            // 
            // tbLocName
            // 
            this.tbLocName.Location = new System.Drawing.Point(96, 49);
            this.tbLocName.Name = "tbLocName";
            this.tbLocName.Size = new System.Drawing.Size(227, 20);
            this.tbLocName.TabIndex = 1;
            this.tbLocName.TextChanged += new System.EventHandler(this.RefreshTbName);
            this.tbLocName.Leave += new System.EventHandler(this.RefreshTbName);
            // 
            // btnUpdateDb
            // 
            this.btnUpdateDb.Location = new System.Drawing.Point(577, 318);
            this.btnUpdateDb.Name = "btnUpdateDb";
            this.btnUpdateDb.Size = new System.Drawing.Size(74, 48);
            this.btnUpdateDb.TabIndex = 11;
            this.btnUpdateDb.Text = "Update Xml";
            this.btnUpdateDb.UseVisualStyleBackColor = true;
            this.btnUpdateDb.Click += new System.EventHandler(this.btnUpdateDb_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(403, 318);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(74, 48);
            this.btnAddRoom.TabIndex = 34;
            this.btnAddRoom.Text = "Add room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(491, 318);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(74, 48);
            this.btnDeleteRoom.TabIndex = 35;
            this.btnDeleteRoom.Text = "Delete room";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // pnlAp0
            // 
            this.pnlAp0.AutoSize = true;
            this.pnlAp0.Controls.Add(this.cbApDir0);
            this.pnlAp0.Controls.Add(this.btnApGo0);
            this.pnlAp0.Controls.Add(this.cbApDest0);
            this.pnlAp0.Location = new System.Drawing.Point(394, 15);
            this.pnlAp0.Name = "pnlAp0";
            this.pnlAp0.Size = new System.Drawing.Size(272, 29);
            this.pnlAp0.TabIndex = 36;
            // 
            // cbApDir0
            // 
            this.cbApDir0.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbApDir0.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbApDir0.FormattingEnabled = true;
            this.cbApDir0.Location = new System.Drawing.Point(2, 4);
            this.cbApDir0.Name = "cbApDir0";
            this.cbApDir0.Size = new System.Drawing.Size(44, 21);
            this.cbApDir0.TabIndex = 3;
            this.cbApDir0.TextChanged += new System.EventHandler(this.accessPointCBTextChanged);
            this.cbApDir0.Leave += new System.EventHandler(this.onCbApDirLeave);
            // 
            // cbApDest3
            // 
            this.cbApDest3.FormattingEnabled = true;
            this.cbApDest3.Location = new System.Drawing.Point(52, 4);
            this.cbApDest3.Name = "cbApDest3";
            this.cbApDest3.Size = new System.Drawing.Size(133, 21);
            this.cbApDest3.TabIndex = 4;
            // 
            // btnApGo3
            // 
            this.btnApGo3.Location = new System.Drawing.Point(191, 3);
            this.btnApGo3.Name = "btnApGo3";
            this.btnApGo3.Size = new System.Drawing.Size(78, 23);
            this.btnApGo3.TabIndex = 5;
            this.btnApGo3.Text = "New Room";
            this.btnApGo3.UseVisualStyleBackColor = true;
            // 
            // cbApDir3
            // 
            this.cbApDir3.FormattingEnabled = true;
            this.cbApDir3.Location = new System.Drawing.Point(2, 4);
            this.cbApDir3.Name = "cbApDir3";
            this.cbApDir3.Size = new System.Drawing.Size(44, 21);
            this.cbApDir3.TabIndex = 3;
            this.cbApDir3.Leave += new System.EventHandler(this.onCbApDirLeave);
            // 
            // pnlAp3
            // 
            this.pnlAp3.AutoSize = true;
            this.pnlAp3.Controls.Add(this.cbApDir3);
            this.pnlAp3.Controls.Add(this.btnApGo3);
            this.pnlAp3.Controls.Add(this.cbApDest3);
            this.pnlAp3.Location = new System.Drawing.Point(394, 111);
            this.pnlAp3.Name = "pnlAp3";
            this.pnlAp3.Size = new System.Drawing.Size(272, 29);
            this.pnlAp3.TabIndex = 37;
            // 
            // cbApDest2
            // 
            this.cbApDest2.FormattingEnabled = true;
            this.cbApDest2.Location = new System.Drawing.Point(52, 4);
            this.cbApDest2.Name = "cbApDest2";
            this.cbApDest2.Size = new System.Drawing.Size(133, 21);
            this.cbApDest2.TabIndex = 4;
            // 
            // btnApGo2
            // 
            this.btnApGo2.Location = new System.Drawing.Point(191, 3);
            this.btnApGo2.Name = "btnApGo2";
            this.btnApGo2.Size = new System.Drawing.Size(78, 23);
            this.btnApGo2.TabIndex = 5;
            this.btnApGo2.Text = "New Room";
            this.btnApGo2.UseVisualStyleBackColor = true;
            // 
            // cbApDir2
            // 
            this.cbApDir2.FormattingEnabled = true;
            this.cbApDir2.Location = new System.Drawing.Point(2, 4);
            this.cbApDir2.Name = "cbApDir2";
            this.cbApDir2.Size = new System.Drawing.Size(44, 21);
            this.cbApDir2.TabIndex = 3;
            this.cbApDir2.Leave += new System.EventHandler(this.onCbApDirLeave);
            // 
            // pnlAp2
            // 
            this.pnlAp2.AutoSize = true;
            this.pnlAp2.Controls.Add(this.cbApDir2);
            this.pnlAp2.Controls.Add(this.btnApGo2);
            this.pnlAp2.Controls.Add(this.cbApDest2);
            this.pnlAp2.Location = new System.Drawing.Point(394, 79);
            this.pnlAp2.Name = "pnlAp2";
            this.pnlAp2.Size = new System.Drawing.Size(272, 29);
            this.pnlAp2.TabIndex = 38;
            // 
            // cbApDest1
            // 
            this.cbApDest1.FormattingEnabled = true;
            this.cbApDest1.Location = new System.Drawing.Point(52, 4);
            this.cbApDest1.Name = "cbApDest1";
            this.cbApDest1.Size = new System.Drawing.Size(133, 21);
            this.cbApDest1.TabIndex = 4;
            // 
            // btnApGo1
            // 
            this.btnApGo1.Location = new System.Drawing.Point(191, 3);
            this.btnApGo1.Name = "btnApGo1";
            this.btnApGo1.Size = new System.Drawing.Size(78, 23);
            this.btnApGo1.TabIndex = 5;
            this.btnApGo1.Text = "New Room";
            this.btnApGo1.UseVisualStyleBackColor = true;
            // 
            // cbApDir1
            // 
            this.cbApDir1.FormattingEnabled = true;
            this.cbApDir1.Location = new System.Drawing.Point(2, 4);
            this.cbApDir1.Name = "cbApDir1";
            this.cbApDir1.Size = new System.Drawing.Size(44, 21);
            this.cbApDir1.TabIndex = 3;
            this.cbApDir1.Leave += new System.EventHandler(this.onCbApDirLeave);
            // 
            // pnlAp1
            // 
            this.pnlAp1.AutoSize = true;
            this.pnlAp1.Controls.Add(this.cbApDir1);
            this.pnlAp1.Controls.Add(this.btnApGo1);
            this.pnlAp1.Controls.Add(this.cbApDest1);
            this.pnlAp1.Location = new System.Drawing.Point(394, 47);
            this.pnlAp1.Name = "pnlAp1";
            this.pnlAp1.Size = new System.Drawing.Size(272, 29);
            this.pnlAp1.TabIndex = 39;
            // 
            // pnlAp5
            // 
            this.pnlAp5.AutoSize = true;
            this.pnlAp5.Controls.Add(this.cbApDir5);
            this.pnlAp5.Controls.Add(this.btnApGo5);
            this.pnlAp5.Controls.Add(this.cbApDest5);
            this.pnlAp5.Location = new System.Drawing.Point(394, 174);
            this.pnlAp5.Name = "pnlAp5";
            this.pnlAp5.Size = new System.Drawing.Size(272, 29);
            this.pnlAp5.TabIndex = 44;
            // 
            // cbApDir5
            // 
            this.cbApDir5.FormattingEnabled = true;
            this.cbApDir5.Location = new System.Drawing.Point(2, 4);
            this.cbApDir5.Name = "cbApDir5";
            this.cbApDir5.Size = new System.Drawing.Size(44, 21);
            this.cbApDir5.TabIndex = 3;
            this.cbApDir5.Leave += new System.EventHandler(this.onCbApDirLeave);
            // 
            // btnApGo5
            // 
            this.btnApGo5.Location = new System.Drawing.Point(191, 3);
            this.btnApGo5.Name = "btnApGo5";
            this.btnApGo5.Size = new System.Drawing.Size(78, 23);
            this.btnApGo5.TabIndex = 5;
            this.btnApGo5.Text = "New Room";
            this.btnApGo5.UseVisualStyleBackColor = true;
            // 
            // cbApDest5
            // 
            this.cbApDest5.FormattingEnabled = true;
            this.cbApDest5.Location = new System.Drawing.Point(52, 4);
            this.cbApDest5.Name = "cbApDest5";
            this.cbApDest5.Size = new System.Drawing.Size(133, 21);
            this.cbApDest5.TabIndex = 4;
            // 
            // pnlAp6
            // 
            this.pnlAp6.AutoSize = true;
            this.pnlAp6.Controls.Add(this.cbApDir6);
            this.pnlAp6.Controls.Add(this.btnApGo6);
            this.pnlAp6.Controls.Add(this.cbApDest6);
            this.pnlAp6.Location = new System.Drawing.Point(394, 206);
            this.pnlAp6.Name = "pnlAp6";
            this.pnlAp6.Size = new System.Drawing.Size(272, 29);
            this.pnlAp6.TabIndex = 43;
            // 
            // cbApDir6
            // 
            this.cbApDir6.FormattingEnabled = true;
            this.cbApDir6.Location = new System.Drawing.Point(2, 4);
            this.cbApDir6.Name = "cbApDir6";
            this.cbApDir6.Size = new System.Drawing.Size(44, 21);
            this.cbApDir6.TabIndex = 3;
            this.cbApDir6.Leave += new System.EventHandler(this.onCbApDirLeave);
            // 
            // btnApGo6
            // 
            this.btnApGo6.Location = new System.Drawing.Point(191, 3);
            this.btnApGo6.Name = "btnApGo6";
            this.btnApGo6.Size = new System.Drawing.Size(78, 23);
            this.btnApGo6.TabIndex = 5;
            this.btnApGo6.Text = "New Room";
            this.btnApGo6.UseVisualStyleBackColor = true;
            // 
            // cbApDest6
            // 
            this.cbApDest6.FormattingEnabled = true;
            this.cbApDest6.Location = new System.Drawing.Point(52, 4);
            this.cbApDest6.Name = "cbApDest6";
            this.cbApDest6.Size = new System.Drawing.Size(133, 21);
            this.cbApDest6.TabIndex = 4;
            // 
            // pnlAp7
            // 
            this.pnlAp7.AutoSize = true;
            this.pnlAp7.Controls.Add(this.cbApDir7);
            this.pnlAp7.Controls.Add(this.btnApGo7);
            this.pnlAp7.Controls.Add(this.cbApDest7);
            this.pnlAp7.Location = new System.Drawing.Point(394, 238);
            this.pnlAp7.Name = "pnlAp7";
            this.pnlAp7.Size = new System.Drawing.Size(272, 29);
            this.pnlAp7.TabIndex = 42;
            // 
            // cbApDir7
            // 
            this.cbApDir7.FormattingEnabled = true;
            this.cbApDir7.Location = new System.Drawing.Point(2, 4);
            this.cbApDir7.Name = "cbApDir7";
            this.cbApDir7.Size = new System.Drawing.Size(44, 21);
            this.cbApDir7.TabIndex = 3;
            this.cbApDir7.Leave += new System.EventHandler(this.onCbApDirLeave);
            // 
            // btnApGo7
            // 
            this.btnApGo7.Location = new System.Drawing.Point(191, 3);
            this.btnApGo7.Name = "btnApGo7";
            this.btnApGo7.Size = new System.Drawing.Size(78, 23);
            this.btnApGo7.TabIndex = 5;
            this.btnApGo7.Text = "New Room";
            this.btnApGo7.UseVisualStyleBackColor = true;
            // 
            // cbApDest7
            // 
            this.cbApDest7.FormattingEnabled = true;
            this.cbApDest7.Location = new System.Drawing.Point(52, 4);
            this.cbApDest7.Name = "cbApDest7";
            this.cbApDest7.Size = new System.Drawing.Size(133, 21);
            this.cbApDest7.TabIndex = 4;
            // 
            // pnlAp4
            // 
            this.pnlAp4.AutoSize = true;
            this.pnlAp4.Controls.Add(this.cbApDir4);
            this.pnlAp4.Controls.Add(this.btnApGo4);
            this.pnlAp4.Controls.Add(this.cbApDest4);
            this.pnlAp4.Location = new System.Drawing.Point(394, 142);
            this.pnlAp4.Name = "pnlAp4";
            this.pnlAp4.Size = new System.Drawing.Size(272, 29);
            this.pnlAp4.TabIndex = 41;
            // 
            // cbApDir4
            // 
            this.cbApDir4.FormattingEnabled = true;
            this.cbApDir4.Location = new System.Drawing.Point(2, 4);
            this.cbApDir4.Name = "cbApDir4";
            this.cbApDir4.Size = new System.Drawing.Size(44, 21);
            this.cbApDir4.TabIndex = 3;
            this.cbApDir4.Leave += new System.EventHandler(this.onCbApDirLeave);
            // 
            // btnApGo4
            // 
            this.btnApGo4.Location = new System.Drawing.Point(191, 3);
            this.btnApGo4.Name = "btnApGo4";
            this.btnApGo4.Size = new System.Drawing.Size(78, 23);
            this.btnApGo4.TabIndex = 5;
            this.btnApGo4.Text = "New Room";
            this.btnApGo4.UseVisualStyleBackColor = true;
            // 
            // cbApDest4
            // 
            this.cbApDest4.FormattingEnabled = true;
            this.cbApDest4.Location = new System.Drawing.Point(52, 4);
            this.cbApDest4.Name = "cbApDest4";
            this.cbApDest4.Size = new System.Drawing.Size(133, 21);
            this.cbApDest4.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 688);
            this.Controls.Add(this.pnlAp5);
            this.Controls.Add(this.pnlAp6);
            this.Controls.Add(this.pnlAp7);
            this.Controls.Add(this.pnlAp4);
            this.Controls.Add(this.pnlAp1);
            this.Controls.Add(this.pnlAp2);
            this.Controls.Add(this.pnlAp3);
            this.Controls.Add(this.pnlAp0);
            this.Controls.Add(this.btnDeleteRoom);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnUpdateDb);
            this.Controls.Add(this.tbLocName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLocDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLocationChoice);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adventure Game Engine";
            this.pnlAp0.ResumeLayout(false);
            this.pnlAp3.ResumeLayout(false);
            this.pnlAp2.ResumeLayout(false);
            this.pnlAp1.ResumeLayout(false);
            this.pnlAp5.ResumeLayout(false);
            this.pnlAp6.ResumeLayout(false);
            this.pnlAp7.ResumeLayout(false);
            this.pnlAp4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocationChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLocDesc;
        private System.Windows.Forms.ComboBox cbApDest0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApGo0;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbLocName;
        private System.Windows.Forms.Button btnUpdateDb;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Panel pnlAp0;
        private System.Windows.Forms.ComboBox cbApDir0;
        private System.Windows.Forms.ComboBox cbApDest3;
        private System.Windows.Forms.Button btnApGo3;
        private System.Windows.Forms.ComboBox cbApDir3;
        private System.Windows.Forms.Panel pnlAp3;
        private System.Windows.Forms.ComboBox cbApDest2;
        private System.Windows.Forms.Button btnApGo2;
        private System.Windows.Forms.ComboBox cbApDir2;
        private System.Windows.Forms.Panel pnlAp2;
        private System.Windows.Forms.ComboBox cbApDest1;
        private System.Windows.Forms.Button btnApGo1;
        private System.Windows.Forms.ComboBox cbApDir1;
        private System.Windows.Forms.Panel pnlAp1;
        private System.Windows.Forms.Panel pnlAp5;
        private System.Windows.Forms.ComboBox cbApDir5;
        private System.Windows.Forms.Button btnApGo5;
        private System.Windows.Forms.ComboBox cbApDest5;
        private System.Windows.Forms.Panel pnlAp6;
        private System.Windows.Forms.ComboBox cbApDir6;
        private System.Windows.Forms.Button btnApGo6;
        private System.Windows.Forms.ComboBox cbApDest6;
        private System.Windows.Forms.Panel pnlAp7;
        private System.Windows.Forms.ComboBox cbApDir7;
        private System.Windows.Forms.Button btnApGo7;
        private System.Windows.Forms.ComboBox cbApDest7;
        private System.Windows.Forms.Panel pnlAp4;
        private System.Windows.Forms.ComboBox cbApDir4;
        private System.Windows.Forms.Button btnApGo4;
        private System.Windows.Forms.ComboBox cbApDest4;
    }
}

