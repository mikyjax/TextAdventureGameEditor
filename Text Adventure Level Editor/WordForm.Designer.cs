namespace TextAdventureGame
{
    partial class WordForm
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
            this.gBNoun = new System.Windows.Forms.GroupBox();
            this.tBSingularNoun = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBPluralNoun = new System.Windows.Forms.TextBox();
            this.chBxIsMascNoun = new System.Windows.Forms.CheckBox();
            this.chBxHasElisionNoun = new System.Windows.Forms.CheckBox();
            this.lblExampleOutput = new System.Windows.Forms.Label();
            this.btnSaveNoun = new System.Windows.Forms.Button();
            this.btnCancelNoun = new System.Windows.Forms.Button();
            this.gBNoun.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBNoun
            // 
            this.gBNoun.Controls.Add(this.btnCancelNoun);
            this.gBNoun.Controls.Add(this.btnSaveNoun);
            this.gBNoun.Controls.Add(this.lblExampleOutput);
            this.gBNoun.Controls.Add(this.chBxHasElisionNoun);
            this.gBNoun.Controls.Add(this.chBxIsMascNoun);
            this.gBNoun.Controls.Add(this.label2);
            this.gBNoun.Controls.Add(this.tBPluralNoun);
            this.gBNoun.Controls.Add(this.label1);
            this.gBNoun.Controls.Add(this.tBSingularNoun);
            this.gBNoun.Location = new System.Drawing.Point(13, 13);
            this.gBNoun.Name = "gBNoun";
            this.gBNoun.Size = new System.Drawing.Size(358, 371);
            this.gBNoun.TabIndex = 0;
            this.gBNoun.TabStop = false;
            this.gBNoun.Text = "Noun";
            // 
            // tBSingularNoun
            // 
            this.tBSingularNoun.Location = new System.Drawing.Point(60, 33);
            this.tBSingularNoun.Name = "tBSingularNoun";
            this.tBSingularNoun.Size = new System.Drawing.Size(292, 20);
            this.tBSingularNoun.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Singular";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plural";
            // 
            // tBPluralNoun
            // 
            this.tBPluralNoun.Location = new System.Drawing.Point(60, 59);
            this.tBPluralNoun.Name = "tBPluralNoun";
            this.tBPluralNoun.Size = new System.Drawing.Size(292, 20);
            this.tBPluralNoun.TabIndex = 2;
            // 
            // chBxIsMascNoun
            // 
            this.chBxIsMascNoun.AutoSize = true;
            this.chBxIsMascNoun.Checked = true;
            this.chBxIsMascNoun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBxIsMascNoun.Location = new System.Drawing.Point(10, 90);
            this.chBxIsMascNoun.Name = "chBxIsMascNoun";
            this.chBxIsMascNoun.Size = new System.Drawing.Size(84, 17);
            this.chBxIsMascNoun.TabIndex = 4;
            this.chBxIsMascNoun.Text = "Is masculine";
            this.chBxIsMascNoun.UseVisualStyleBackColor = true;
            // 
            // chBxHasElisionNoun
            // 
            this.chBxHasElisionNoun.AutoSize = true;
            this.chBxHasElisionNoun.Location = new System.Drawing.Point(10, 113);
            this.chBxHasElisionNoun.Name = "chBxHasElisionNoun";
            this.chBxHasElisionNoun.Size = new System.Drawing.Size(77, 17);
            this.chBxHasElisionNoun.TabIndex = 5;
            this.chBxHasElisionNoun.Text = "Has elision";
            this.chBxHasElisionNoun.UseVisualStyleBackColor = true;
            // 
            // lblExampleOutput
            // 
            this.lblExampleOutput.AutoSize = true;
            this.lblExampleOutput.Location = new System.Drawing.Point(10, 146);
            this.lblExampleOutput.Name = "lblExampleOutput";
            this.lblExampleOutput.Size = new System.Drawing.Size(46, 13);
            this.lblExampleOutput.TabIndex = 6;
            this.lblExampleOutput.Text = "example";
            // 
            // btnSaveNoun
            // 
            this.btnSaveNoun.Location = new System.Drawing.Point(10, 182);
            this.btnSaveNoun.Name = "btnSaveNoun";
            this.btnSaveNoun.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNoun.TabIndex = 7;
            this.btnSaveNoun.Text = "Save noun";
            this.btnSaveNoun.UseVisualStyleBackColor = true;
            this.btnSaveNoun.Click += new System.EventHandler(this.btnSaveNoun_Click);
            // 
            // btnCancelNoun
            // 
            this.btnCancelNoun.Location = new System.Drawing.Point(91, 182);
            this.btnCancelNoun.Name = "btnCancelNoun";
            this.btnCancelNoun.Size = new System.Drawing.Size(75, 23);
            this.btnCancelNoun.TabIndex = 8;
            this.btnCancelNoun.Text = "Cancel";
            this.btnCancelNoun.UseVisualStyleBackColor = true;
            this.btnCancelNoun.Click += new System.EventHandler(this.btnCancelNoun_Click);
            // 
            // WordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 404);
            this.Controls.Add(this.gBNoun);
            this.Name = "WordForm";
            this.Text = "WordForm";
            this.gBNoun.ResumeLayout(false);
            this.gBNoun.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBNoun;
        private System.Windows.Forms.CheckBox chBxHasElisionNoun;
        private System.Windows.Forms.CheckBox chBxIsMascNoun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBPluralNoun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBSingularNoun;
        private System.Windows.Forms.Button btnCancelNoun;
        private System.Windows.Forms.Button btnSaveNoun;
        private System.Windows.Forms.Label lblExampleOutput;
    }
}