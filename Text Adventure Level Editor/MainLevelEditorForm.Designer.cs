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
            this.rBstartingLocation = new System.Windows.Forms.RadioButton();
            this.ChBxTransitionLocation = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tVObjects = new System.Windows.Forms.TreeView();
            this.pnlObj = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gBAccessPointSetup = new System.Windows.Forms.GroupBox();
            this.cBApObjDir = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeleteObject = new System.Windows.Forms.Button();
            this.btnSaveObject = new System.Windows.Forms.Button();
            this.chBxUnderContainer = new System.Windows.Forms.CheckBox();
            this.chBxInsideContainer = new System.Windows.Forms.CheckBox();
            this.chBxAboveContainer = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbObjectName = new System.Windows.Forms.TextBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCbObjectTypeDesc = new System.Windows.Forms.Label();
            this.CbObjectType = new System.Windows.Forms.ComboBox();
            this.btnAddObject = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlObj.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gBAccessPointSetup.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLocation
            // 
            this.cbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbLocation.FormattingEnabled = true;
            this.cbLocation.Location = new System.Drawing.Point(99, 58);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(275, 21);
            this.cbLocation.TabIndex = 40;
            this.cbLocation.SelectedIndexChanged += new System.EventHandler(this.OnCbTitleSelectedChanged);
            this.cbLocation.Leave += new System.EventHandler(this.OnCbTitleLeave);
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
            this.tbLocDesc.Size = new System.Drawing.Size(362, 402);
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
            this.btnUpdateDb.Location = new System.Drawing.Point(570, 526);
            this.btnUpdateDb.Name = "btnUpdateDb";
            this.btnUpdateDb.Size = new System.Drawing.Size(74, 48);
            this.btnUpdateDb.TabIndex = 90;
            this.btnUpdateDb.Text = "Update Xml";
            this.btnUpdateDb.UseVisualStyleBackColor = true;
            this.btnUpdateDb.Click += new System.EventHandler(this.btnUpdateDb_Click);
            // 
            // btnMain1
            // 
            this.btnMain1.Location = new System.Drawing.Point(410, 526);
            this.btnMain1.Name = "btnMain1";
            this.btnMain1.Size = new System.Drawing.Size(74, 48);
            this.btnMain1.TabIndex = 70;
            this.btnMain1.Text = "Add this Location";
            this.btnMain1.UseVisualStyleBackColor = true;
            this.btnMain1.Click += new System.EventHandler(this.btnMain1_Click);
            // 
            // btnMain2
            // 
            this.btnMain2.Location = new System.Drawing.Point(490, 526);
            this.btnMain2.Name = "btnMain2";
            this.btnMain2.Size = new System.Drawing.Size(74, 48);
            this.btnMain2.TabIndex = 80;
            this.btnMain2.Text = "Edit Location";
            this.btnMain2.UseVisualStyleBackColor = true;
            this.btnMain2.Click += new System.EventHandler(this.btnMain2_Click);
            // 
            // lbAccessPoints
            // 
            this.lbAccessPoints.BackColor = System.Drawing.SystemColors.Menu;
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
            this.lbAccessPoints.Location = new System.Drawing.Point(12, 545);
            this.lbAccessPoints.Name = "lbAccessPoints";
            this.lbAccessPoints.Size = new System.Drawing.Size(362, 121);
            this.lbAccessPoints.TabIndex = 60;
            this.lbAccessPoints.SelectedIndexChanged += new System.EventHandler(this.lbAccessPoints_SelectedIndexChanged);
            this.lbAccessPoints.DoubleClick += new System.EventHandler(this.OnLbAccessPointDoubleClicked);
            this.lbAccessPoints.Enter += new System.EventHandler(this.OnEnterLbApChangColor);
            this.lbAccessPoints.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnlbAccessPointEnterDown);
            this.lbAccessPoints.Leave += new System.EventHandler(this.OnLeaveLbChangeColor);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 526);
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
            this.btnDelete.Location = new System.Drawing.Point(12, 57);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 23);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "Del Location";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // rBstartingLocation
            // 
            this.rBstartingLocation.AutoSize = true;
            this.rBstartingLocation.Location = new System.Drawing.Point(410, 582);
            this.rBstartingLocation.Name = "rBstartingLocation";
            this.rBstartingLocation.Size = new System.Drawing.Size(174, 17);
            this.rBstartingLocation.TabIndex = 91;
            this.rBstartingLocation.TabStop = true;
            this.rBstartingLocation.Text = "The game starts in this location.";
            this.rBstartingLocation.UseVisualStyleBackColor = true;
            // 
            // ChBxTransitionLocation
            // 
            this.ChBxTransitionLocation.AutoSize = true;
            this.ChBxTransitionLocation.Location = new System.Drawing.Point(410, 606);
            this.ChBxTransitionLocation.Name = "ChBxTransitionLocation";
            this.ChBxTransitionLocation.Size = new System.Drawing.Size(161, 17);
            this.ChBxTransitionLocation.TabIndex = 92;
            this.ChBxTransitionLocation.Text = "This is a Transition Location.";
            this.ChBxTransitionLocation.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(410, 625);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 46);
            this.label6.TabIndex = 93;
            this.label6.Text = "A transition location won\'t appear in game but is usefull to handle advanced acce" +
    "ss points. I.e a stairs turning 180°.";
            // 
            // tVObjects
            // 
            this.tVObjects.HideSelection = false;
            this.tVObjects.Location = new System.Drawing.Point(410, 11);
            this.tVObjects.Name = "tVObjects";
            this.tVObjects.Size = new System.Drawing.Size(320, 498);
            this.tVObjects.TabIndex = 94;
            this.tVObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnAfterSelectTvObjects);
            // 
            // pnlObj
            // 
            this.pnlObj.Controls.Add(this.groupBox1);
            this.pnlObj.Location = new System.Drawing.Point(770, 11);
            this.pnlObj.Name = "pnlObj";
            this.pnlObj.Size = new System.Drawing.Size(537, 498);
            this.pnlObj.TabIndex = 95;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gBAccessPointSetup);
            this.groupBox1.Controls.Add(this.btnDeleteObject);
            this.groupBox1.Controls.Add(this.btnSaveObject);
            this.groupBox1.Controls.Add(this.chBxUnderContainer);
            this.groupBox1.Controls.Add(this.chBxInsideContainer);
            this.groupBox1.Controls.Add(this.chBxAboveContainer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbObjectName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 492);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Panel";
            // 
            // gBAccessPointSetup
            // 
            this.gBAccessPointSetup.Controls.Add(this.cBApObjDir);
            this.gBAccessPointSetup.Controls.Add(this.label9);
            this.gBAccessPointSetup.Location = new System.Drawing.Point(10, 119);
            this.gBAccessPointSetup.Name = "gBAccessPointSetup";
            this.gBAccessPointSetup.Size = new System.Drawing.Size(515, 56);
            this.gBAccessPointSetup.TabIndex = 8;
            this.gBAccessPointSetup.TabStop = false;
            this.gBAccessPointSetup.Text = "Access Point Setup";
            // 
            // cBApObjDir
            // 
            this.cBApObjDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBApObjDir.FormattingEnabled = true;
            this.cBApObjDir.Location = new System.Drawing.Point(118, 23);
            this.cBApObjDir.Name = "cBApObjDir";
            this.cBApObjDir.Size = new System.Drawing.Size(48, 21);
            this.cBApObjDir.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "This Object leads to : ";
            // 
            // btnDeleteObject
            // 
            this.btnDeleteObject.Location = new System.Drawing.Point(91, 290);
            this.btnDeleteObject.Name = "btnDeleteObject";
            this.btnDeleteObject.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteObject.TabIndex = 7;
            this.btnDeleteObject.Text = "Delete Object";
            this.btnDeleteObject.UseVisualStyleBackColor = true;
            this.btnDeleteObject.Click += new System.EventHandler(this.btnDeleteObject_Click);
            // 
            // btnSaveObject
            // 
            this.btnSaveObject.Location = new System.Drawing.Point(10, 290);
            this.btnSaveObject.Name = "btnSaveObject";
            this.btnSaveObject.Size = new System.Drawing.Size(75, 23);
            this.btnSaveObject.TabIndex = 6;
            this.btnSaveObject.Text = "Save Object";
            this.btnSaveObject.UseVisualStyleBackColor = true;
            this.btnSaveObject.Click += new System.EventHandler(this.btnSaveObject_Click);
            // 
            // chBxUnderContainer
            // 
            this.chBxUnderContainer.AutoSize = true;
            this.chBxUnderContainer.Location = new System.Drawing.Point(10, 96);
            this.chBxUnderContainer.Name = "chBxUnderContainer";
            this.chBxUnderContainer.Size = new System.Drawing.Size(103, 17);
            this.chBxUnderContainer.TabIndex = 5;
            this.chBxUnderContainer.Text = "Under Container";
            this.chBxUnderContainer.UseVisualStyleBackColor = true;
            // 
            // chBxInsideContainer
            // 
            this.chBxInsideContainer.AutoSize = true;
            this.chBxInsideContainer.Location = new System.Drawing.Point(10, 73);
            this.chBxInsideContainer.Name = "chBxInsideContainer";
            this.chBxInsideContainer.Size = new System.Drawing.Size(102, 17);
            this.chBxInsideContainer.TabIndex = 4;
            this.chBxInsideContainer.Text = "Inside Container";
            this.chBxInsideContainer.UseVisualStyleBackColor = true;
            // 
            // chBxAboveContainer
            // 
            this.chBxAboveContainer.AutoSize = true;
            this.chBxAboveContainer.Location = new System.Drawing.Point(10, 51);
            this.chBxAboveContainer.Name = "chBxAboveContainer";
            this.chBxAboveContainer.Size = new System.Drawing.Size(105, 17);
            this.chBxAboveContainer.TabIndex = 3;
            this.chBxAboveContainer.Text = "Above Container";
            this.chBxAboveContainer.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Object name";
            // 
            // tbObjectName
            // 
            this.tbObjectName.Location = new System.Drawing.Point(79, 25);
            this.tbObjectName.Name = "tbObjectName";
            this.tbObjectName.Size = new System.Drawing.Size(188, 20);
            this.tbObjectName.TabIndex = 0;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.groupBox2);
            this.pnlContainer.Location = new System.Drawing.Point(1316, 11);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(537, 498);
            this.pnlContainer.TabIndex = 96;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCbObjectTypeDesc);
            this.groupBox2.Controls.Add(this.CbObjectType);
            this.groupBox2.Controls.Add(this.btnAddObject);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 492);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Container Panel";
            // 
            // lblCbObjectTypeDesc
            // 
            this.lblCbObjectTypeDesc.Location = new System.Drawing.Point(13, 101);
            this.lblCbObjectTypeDesc.Name = "lblCbObjectTypeDesc";
            this.lblCbObjectTypeDesc.Size = new System.Drawing.Size(473, 47);
            this.lblCbObjectTypeDesc.TabIndex = 4;
            this.lblCbObjectTypeDesc.Text = "Tip for selected object";
            // 
            // CbObjectType
            // 
            this.CbObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbObjectType.FormattingEnabled = true;
            this.CbObjectType.Location = new System.Drawing.Point(94, 72);
            this.CbObjectType.Name = "CbObjectType";
            this.CbObjectType.Size = new System.Drawing.Size(219, 21);
            this.CbObjectType.TabIndex = 3;
            this.CbObjectType.SelectedIndexChanged += new System.EventHandler(this.OnCbObjectTypeChanged);
            // 
            // btnAddObject
            // 
            this.btnAddObject.Location = new System.Drawing.Point(13, 71);
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.Size = new System.Drawing.Size(75, 23);
            this.btnAddObject.TabIndex = 2;
            this.btnAddObject.Text = "Add Object";
            this.btnAddObject.UseVisualStyleBackColor = true;
            this.btnAddObject.Click += new System.EventHandler(this.btnAddObject_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Weight Capacity (kg)";
            // 
            // MainLevelEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 690);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlObj);
            this.Controls.Add(this.tVObjects);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ChBxTransitionLocation);
            this.Controls.Add(this.rBstartingLocation);
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
            this.Name = "MainLevelEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adventure Game Engine";
            this.Load += new System.EventHandler(this.MainLevelEditorForm_Load);
            this.pnlObj.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBAccessPointSetup.ResumeLayout(false);
            this.gBAccessPointSetup.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.RadioButton rBstartingLocation;
        private System.Windows.Forms.CheckBox ChBxTransitionLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView tVObjects;
        private System.Windows.Forms.Panel pnlObj;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteObject;
        private System.Windows.Forms.Button btnSaveObject;
        private System.Windows.Forms.CheckBox chBxUnderContainer;
        private System.Windows.Forms.CheckBox chBxInsideContainer;
        private System.Windows.Forms.CheckBox chBxAboveContainer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbObjectName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddObject;
        private System.Windows.Forms.Label lblCbObjectTypeDesc;
        private System.Windows.Forms.ComboBox CbObjectType;
        private System.Windows.Forms.GroupBox gBAccessPointSetup;
        private System.Windows.Forms.ComboBox cBApObjDir;
        private System.Windows.Forms.Label label9;
    }
}

