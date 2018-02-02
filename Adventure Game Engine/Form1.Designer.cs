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
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLocName = new System.Windows.Forms.TextBox();
            this.btnUpdateDb = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAddEdditAccessPoint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, -14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Access Point";
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
            this.btnUpdateDb.TabIndex = 7;
            this.btnUpdateDb.Text = "Update Xml";
            this.btnUpdateDb.UseVisualStyleBackColor = true;
            this.btnUpdateDb.Click += new System.EventHandler(this.btnUpdateDb_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(403, 318);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(74, 48);
            this.btnAddRoom.TabIndex = 5;
            this.btnAddRoom.Text = "Add room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(491, 318);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(74, 48);
            this.btnDeleteRoom.TabIndex = 6;
            this.btnDeleteRoom.Text = "Delete room";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "N\t| Location Room",
            "NE\t| Location Room",
            "E\t| Location Room",
            "SE\t| Location Room",
            "S\t| Location Room",
            "SW\t| Location Room",
            "W\t| Location Room",
            "NW\t| Location Room"});
            this.listBox1.Location = new System.Drawing.Point(403, 103);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(248, 108);
            this.listBox1.TabIndex = 3;
            // 
            // btnAddEdditAccessPoint
            // 
            this.btnAddEdditAccessPoint.Location = new System.Drawing.Point(403, 218);
            this.btnAddEdditAccessPoint.Name = "btnAddEdditAccessPoint";
            this.btnAddEdditAccessPoint.Size = new System.Drawing.Size(248, 23);
            this.btnAddEdditAccessPoint.TabIndex = 4;
            this.btnAddEdditAccessPoint.Text = "Add or Edit Access Points";
            this.btnAddEdditAccessPoint.UseVisualStyleBackColor = true;
            this.btnAddEdditAccessPoint.Click += new System.EventHandler(this.btnAddEdditAccessPoint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Double Clic or type Enter to go to selected location";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 688);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddEdditAccessPoint);
            this.Controls.Add(this.listBox1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocationChoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLocDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbLocName;
        private System.Windows.Forms.Button btnUpdateDb;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnAddEdditAccessPoint;
        private System.Windows.Forms.Label label3;
    }
}

