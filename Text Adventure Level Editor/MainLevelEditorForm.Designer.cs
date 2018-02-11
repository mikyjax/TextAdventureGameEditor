namespace TextAdventureGame
{
    partial class MainLevelEditorForm
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
            this.btnMain1 = new System.Windows.Forms.Button();
            this.btnMain2 = new System.Windows.Forms.Button();
            this.lbAccessPoints = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbZone = new System.Windows.Forms.ComboBox();
            this.btnNewZone = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbLocation
            // 
            this.cbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(12, 58);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(275, 21);
            this.cbLocation.TabIndex = 30;
            this.cbLocation.SelectedIndexChanged += new System.EventHandler(this.OnCbTitleSelectedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter a new location name or select one to edit an existing one.*";
            // 
            // tbLocDesc
            // 
            this.tbLocDesc.Location = new System.Drawing.Point(12, 107);
            this.tbLocDesc.Multiline = true;
            this.tbLocDesc.Name = "tbLocDesc";
            this.tbLocDesc.Size = new System.Drawing.Size(362, 214);
            this.tbLocDesc.TabIndex = 50;
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
            this.btnUpdateDb.Location = new System.Drawing.Point(564, 273);
            this.btnUpdateDb.Name = "btnUpdateDb";
            this.btnUpdateDb.Size = new System.Drawing.Size(74, 48);
            this.btnUpdateDb.TabIndex = 90;
            this.btnUpdateDb.Text = "Update Xml";
            this.btnUpdateDb.UseVisualStyleBackColor = true;
            this.btnUpdateDb.Click += new System.EventHandler(this.btnUpdateDb_Click);
            // 
            // btnMain1
            // 
            this.btnMain1.Location = new System.Drawing.Point(404, 273);
            this.btnMain1.Name = "btnMain1";
            this.btnMain1.Size = new System.Drawing.Size(74, 48);
            this.btnMain1.TabIndex = 70;
            this.btnMain1.Text = "Add this Location";
            this.btnMain1.UseVisualStyleBackColor = true;
            this.btnMain1.Click += new System.EventHandler(this.btnMain1_Click);
            // 
            // btnMain2
            // 
            this.btnMain2.Location = new System.Drawing.Point(484, 273);
            this.btnMain2.Name = "btnMain2";
            this.btnMain2.Size = new System.Drawing.Size(74, 48);
            this.btnMain2.TabIndex = 80;
            this.btnMain2.Text = "Edit Location";
            this.btnMain2.UseVisualStyleBackColor = true;
            this.btnMain2.Click += new System.EventHandler(this.btnMain2_Click);
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
            this.lbAccessPoints.Location = new System.Drawing.Point(401, 58);
            this.lbAccessPoints.Name = "lbAccessPoints";
            this.lbAccessPoints.Size = new System.Drawing.Size(248, 121);
            this.lbAccessPoints.TabIndex = 60;
            this.lbAccessPoints.DoubleClick += new System.EventHandler(this.OnLbAccessPointDoubleClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 39);
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
            this.cbZone.TabIndex = 10;
            this.cbZone.SelectedIndexChanged += new System.EventHandler(this.OnCbZoneSelectedIndexChanged);
            // 
            // btnNewZone
            // 
            this.btnNewZone.Location = new System.Drawing.Point(291, 11);
            this.btnNewZone.Name = "btnNewZone";
            this.btnNewZone.Size = new System.Drawing.Size(83, 23);
            this.btnNewZone.TabIndex = 20;
            this.btnNewZone.Text = "Zone Editor";
            this.btnNewZone.UseVisualStyleBackColor = true;
            this.btnNewZone.Click += new System.EventHandler(this.btnNewZone_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Describe the location as it will be shown in game.";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(291, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 23);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Del Location";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 688);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnNewZone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbZone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbAccessPoints);
            this.Controls.Add(this.btnMain2);
            this.Controls.Add(this.btnMain1);
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
        private System.Windows.Forms.Button btnMain1;
        private System.Windows.Forms.Button btnMain2;
        private System.Windows.Forms.ListBox lbAccessPoints;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbZone;
        private System.Windows.Forms.Button btnNewZone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDelete;
    }
}

