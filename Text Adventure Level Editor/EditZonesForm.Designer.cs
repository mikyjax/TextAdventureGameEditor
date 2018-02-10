namespace TextAdventureGame
{
    partial class EditZonesForm
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
            this.lbZones = new System.Windows.Forms.ListBox();
            this.tbNameZone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddOrEditZone = new System.Windows.Forms.Button();
            this.btnDeleteZone = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbZones
            // 
            this.lbZones.FormattingEnabled = true;
            this.lbZones.Location = new System.Drawing.Point(253, 12);
            this.lbZones.Name = "lbZones";
            this.lbZones.Size = new System.Drawing.Size(236, 134);
            this.lbZones.TabIndex = 4;
            this.lbZones.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // tbNameZone
            // 
            this.tbNameZone.Location = new System.Drawing.Point(5, 101);
            this.tbNameZone.Name = "tbNameZone";
            this.tbNameZone.Size = new System.Drawing.Size(232, 20);
            this.tbNameZone.TabIndex = 1;
            this.tbNameZone.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type the name of your new zone";
            // 
            // btnAddOrEditZone
            // 
            this.btnAddOrEditZone.Location = new System.Drawing.Point(6, 128);
            this.btnAddOrEditZone.Name = "btnAddOrEditZone";
            this.btnAddOrEditZone.Size = new System.Drawing.Size(231, 23);
            this.btnAddOrEditZone.TabIndex = 2;
            this.btnAddOrEditZone.Text = "Add new zone";
            this.btnAddOrEditZone.UseVisualStyleBackColor = true;
            this.btnAddOrEditZone.Click += new System.EventHandler(this.btnAddOrEditZone_Click);
            // 
            // btnDeleteZone
            // 
            this.btnDeleteZone.Location = new System.Drawing.Point(6, 158);
            this.btnDeleteZone.Name = "btnDeleteZone";
            this.btnDeleteZone.Size = new System.Drawing.Size(231, 23);
            this.btnDeleteZone.TabIndex = 3;
            this.btnDeleteZone.Text = "Delete selected zone and all locations in it";
            this.btnDeleteZone.UseVisualStyleBackColor = true;
            this.btnDeleteZone.Click += new System.EventHandler(this.btnDeleteZone_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(253, 158);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(236, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 70);
            this.label2.TabIndex = 6;
            this.label2.Text = "A Zone is mostly a container for locations. Example: in your game, a Zone could b" +
    "e someone\'s house containing other Locations like bedrooms.";
            // 
            // EditZonesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 196);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteZone);
            this.Controls.Add(this.btnAddOrEditZone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNameZone);
            this.Controls.Add(this.lbZones);
            this.Name = "EditZonesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zone Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbZones;
        private System.Windows.Forms.TextBox tbNameZone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddOrEditZone;
        private System.Windows.Forms.Button btnDeleteZone;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
    }
}