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
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLocDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdateDb = new System.Windows.Forms.Button();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.lbAccessPoints = new System.Windows.Forms.ListBox();
            this.btnAddEdditAccessPoint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbZone = new System.Windows.Forms.ComboBox();
            this.btnNewZone = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbLocation
            // 
            this.cbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(12, 62);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(362, 21);
            this.cbLocation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter a new location name or select one to edit an existing one.*";
            // 
            // tbLocDesc
            // 
            this.tbLocDesc.Location = new System.Drawing.Point(12, 111);
            this.tbLocDesc.Multiline = true;
            this.tbLocDesc.Name = "tbLocDesc";
            this.tbLocDesc.Size = new System.Drawing.Size(362, 214);
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
            // btnUpdateDb
            // 
            this.btnUpdateDb.Location = new System.Drawing.Point(575, 277);
            this.btnUpdateDb.Name = "btnUpdateDb";
            this.btnUpdateDb.Size = new System.Drawing.Size(74, 48);
            this.btnUpdateDb.TabIndex = 7;
            this.btnUpdateDb.Text = "Update Xml";
            this.btnUpdateDb.UseVisualStyleBackColor = true;
            this.btnUpdateDb.Click += new System.EventHandler(this.btnUpdateDb_Click);
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(401, 277);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(74, 48);
            this.btnAddRoom.TabIndex = 5;
            this.btnAddRoom.Text = "Add this room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(489, 277);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(74, 48);
            this.btnDeleteRoom.TabIndex = 6;
            this.btnDeleteRoom.Text = "Delete room";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            // 
            // lbAccessPoints
            // 
            this.lbAccessPoints.FormattingEnabled = true;
            this.lbAccessPoints.Items.AddRange(new object[] {
            "N\t| Location Room",
            "NE\t| Location Room",
            "E\t| Location Room",
            "SE\t| Location Room",
            "S\t| Location Room",
            "SW\t| Location Room",
            "W\t| Location Room",
            "NW\t| Location Room"});
            this.lbAccessPoints.Location = new System.Drawing.Point(401, 62);
            this.lbAccessPoints.Name = "lbAccessPoints";
            this.lbAccessPoints.Size = new System.Drawing.Size(248, 108);
            this.lbAccessPoints.TabIndex = 3;
            // 
            // btnAddEdditAccessPoint
            // 
            this.btnAddEdditAccessPoint.Location = new System.Drawing.Point(401, 177);
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
            this.label3.Location = new System.Drawing.Point(401, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Double Clic or type Enter to go to selected location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Select zone*";
            // 
            // cbZone
            // 
            this.cbZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbZone.FormattingEnabled = true;
            this.cbZone.Location = new System.Drawing.Point(95, 12);
            this.cbZone.Name = "cbZone";
            this.cbZone.Size = new System.Drawing.Size(192, 21);
            this.cbZone.TabIndex = 35;
            this.cbZone.SelectedValueChanged += new System.EventHandler(this.OnCbZoneValueChanged);
            // 
            // btnNewZone
            // 
            this.btnNewZone.Location = new System.Drawing.Point(291, 11);
            this.btnNewZone.Name = "btnNewZone";
            this.btnNewZone.Size = new System.Drawing.Size(83, 23);
            this.btnNewZone.TabIndex = 37;
            this.btnNewZone.Text = "Zone Editor";
            this.btnNewZone.UseVisualStyleBackColor = true;
            this.btnNewZone.Click += new System.EventHandler(this.btnNewZone_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Describe the location as it will be shown in game.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 688);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnNewZone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbZone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddEdditAccessPoint);
            this.Controls.Add(this.lbAccessPoints);
            this.Controls.Add(this.btnDeleteRoom);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnUpdateDb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLocDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbLocation);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adventure Game Engine";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLocDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateDb;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.ListBox lbAccessPoints;
        private System.Windows.Forms.Button btnAddEdditAccessPoint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbZone;
        private System.Windows.Forms.Button btnNewZone;
        private System.Windows.Forms.Label label5;
    }
}

