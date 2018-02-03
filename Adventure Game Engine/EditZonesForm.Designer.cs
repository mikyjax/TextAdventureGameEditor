namespace Adventure_Game_Engine
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
            this.SuspendLayout();
            // 
            // lbZones
            // 
            this.lbZones.FormattingEnabled = true;
            this.lbZones.Location = new System.Drawing.Point(12, 27);
            this.lbZones.Name = "lbZones";
            this.lbZones.Size = new System.Drawing.Size(236, 199);
            this.lbZones.TabIndex = 0;
            this.lbZones.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // tbNameZone
            // 
            this.tbNameZone.Location = new System.Drawing.Point(259, 27);
            this.tbNameZone.Name = "tbNameZone";
            this.tbNameZone.Size = new System.Drawing.Size(232, 20);
            this.tbNameZone.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type the name of your new zone";
            // 
            // btnAddOrEditZone
            // 
            this.btnAddOrEditZone.Location = new System.Drawing.Point(260, 54);
            this.btnAddOrEditZone.Name = "btnAddOrEditZone";
            this.btnAddOrEditZone.Size = new System.Drawing.Size(231, 23);
            this.btnAddOrEditZone.TabIndex = 3;
            this.btnAddOrEditZone.Text = "Add new zone";
            this.btnAddOrEditZone.UseVisualStyleBackColor = true;
            this.btnAddOrEditZone.Click += new System.EventHandler(this.btnAddOrEditZone_Click);
            // 
            // btnDeleteZone
            // 
            this.btnDeleteZone.Location = new System.Drawing.Point(260, 84);
            this.btnDeleteZone.Name = "btnDeleteZone";
            this.btnDeleteZone.Size = new System.Drawing.Size(231, 23);
            this.btnDeleteZone.TabIndex = 4;
            this.btnDeleteZone.Text = "Delete selected zone and all locations in it";
            this.btnDeleteZone.UseVisualStyleBackColor = true;
            // 
            // EditZonesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 250);
            this.Controls.Add(this.btnDeleteZone);
            this.Controls.Add(this.btnAddOrEditZone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNameZone);
            this.Controls.Add(this.lbZones);
            this.Name = "EditZonesForm";
            this.Text = "EditZonesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbZones;
        private System.Windows.Forms.TextBox tbNameZone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddOrEditZone;
        private System.Windows.Forms.Button btnDeleteZone;
    }
}