namespace SMHospitall.Forms
{
    partial class frmOfficial
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOfficial));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.phoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.officialBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sciencesLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.sciencesXPCollection = new DevExpress.Xpo.XPCollection();
            this.birthDayDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.nameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.sexTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ucAction = new SMHospitall.Ctr.UcAction1();
            ((System.ComponentModel.ISupportInitialize)(this.work)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officialBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sciencesLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sciencesXPCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.birthDayDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.birthDayDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.phoneTextEdit);
            this.layoutControl1.Controls.Add(this.sciencesLookUpEdit);
            this.layoutControl1.Controls.Add(this.birthDayDateEdit);
            this.layoutControl1.Controls.Add(this.nameTextEdit);
            this.layoutControl1.Controls.Add(this.codeTextEdit);
            this.layoutControl1.Controls.Add(this.sexTextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(820, 208, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(327, 124);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // phoneTextEdit
            // 
            this.phoneTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.officialBindingSource, "Phone", true));
            this.phoneTextEdit.EnterMoveNextControl = true;
            this.phoneTextEdit.Location = new System.Drawing.Point(75, 101);
            this.phoneTextEdit.Name = "phoneTextEdit";
            this.phoneTextEdit.Size = new System.Drawing.Size(249, 20);
            this.phoneTextEdit.StyleController = this.layoutControl1;
            this.phoneTextEdit.TabIndex = 10;
            // 
            // officialBindingSource
            // 
            this.officialBindingSource.DataSource = typeof(SMHospitall.Data.Official);
            // 
            // sciencesLookUpEdit
            // 
            this.sciencesLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.officialBindingSource, "Sciences", true));
            this.sciencesLookUpEdit.EnterMoveNextControl = true;
            this.sciencesLookUpEdit.Location = new System.Drawing.Point(75, 75);
            this.sciencesLookUpEdit.Name = "sciencesLookUpEdit";
            this.sciencesLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("sciencesLookUpEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.sciencesLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", 10, "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên")});
            this.sciencesLookUpEdit.Properties.DataSource = this.sciencesXPCollection;
            this.sciencesLookUpEdit.Properties.DisplayMember = "Name";
            this.sciencesLookUpEdit.Properties.NullText = "";
            this.sciencesLookUpEdit.Properties.ValueMember = "This";
            this.sciencesLookUpEdit.Size = new System.Drawing.Size(249, 22);
            this.sciencesLookUpEdit.StyleController = this.layoutControl1;
            this.sciencesLookUpEdit.TabIndex = 9;
            // 
            // sciencesXPCollection
            // 
            this.sciencesXPCollection.ObjectType = typeof(SMHospitall.Data.Sciences);
            this.sciencesXPCollection.Session = this.work;
            // 
            // birthDayDateEdit
            // 
            this.birthDayDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.officialBindingSource, "BirthDay", true));
            this.birthDayDateEdit.EditValue = null;
            this.birthDayDateEdit.EnterMoveNextControl = true;
            this.birthDayDateEdit.Location = new System.Drawing.Point(75, 51);
            this.birthDayDateEdit.Name = "birthDayDateEdit";
            this.birthDayDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.birthDayDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.birthDayDateEdit.Size = new System.Drawing.Size(115, 20);
            this.birthDayDateEdit.StyleController = this.layoutControl1;
            this.birthDayDateEdit.TabIndex = 7;
            // 
            // nameTextEdit
            // 
            this.nameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.officialBindingSource, "Name", true));
            this.nameTextEdit.EnterMoveNextControl = true;
            this.nameTextEdit.Location = new System.Drawing.Point(75, 27);
            this.nameTextEdit.Name = "nameTextEdit";
            this.nameTextEdit.Size = new System.Drawing.Size(249, 20);
            this.nameTextEdit.StyleController = this.layoutControl1;
            this.nameTextEdit.TabIndex = 6;
            // 
            // codeTextEdit
            // 
            this.codeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.officialBindingSource, "Code", true));
            this.codeTextEdit.EnterMoveNextControl = true;
            this.codeTextEdit.Location = new System.Drawing.Point(75, 3);
            this.codeTextEdit.Name = "codeTextEdit";
            this.codeTextEdit.Size = new System.Drawing.Size(86, 20);
            this.codeTextEdit.StyleController = this.layoutControl1;
            this.codeTextEdit.TabIndex = 5;
            // 
            // sexTextEdit
            // 
            this.sexTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.officialBindingSource, "Sex", true));
            this.sexTextEdit.EnterMoveNextControl = true;
            this.sexTextEdit.Location = new System.Drawing.Point(266, 51);
            this.sexTextEdit.Name = "sexTextEdit";
            this.sexTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sexTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 5, "Tên")});
            this.sexTextEdit.Properties.DisplayMember = "Name";
            this.sexTextEdit.Properties.NullText = "";
            this.sexTextEdit.Properties.PopupSizeable = false;
            this.sexTextEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.sexTextEdit.Properties.ValueMember = "This";
            this.sexTextEdit.Size = new System.Drawing.Size(58, 20);
            this.sexTextEdit.StyleController = this.layoutControl1;
            this.sexTextEdit.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(327, 124);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.codeTextEdit;
            this.layoutControlItem2.CustomizationFormText = "Mã:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(162, 24);
            this.layoutControlItem2.Text = "Mã:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.nameTextEdit;
            this.layoutControlItem3.CustomizationFormText = "Tên:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(325, 24);
            this.layoutControlItem3.Text = "Tên:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.birthDayDateEdit;
            this.layoutControlItem4.CustomizationFormText = "Ngày sinh:";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(191, 24);
            this.layoutControlItem4.Text = "Ngày sinh:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.sexTextEdit;
            this.layoutControlItem5.CustomizationFormText = "Giới tính:";
            this.layoutControlItem5.Location = new System.Drawing.Point(191, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(134, 24);
            this.layoutControlItem5.Text = "Giới tính:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.sciencesLookUpEdit;
            this.layoutControlItem6.CustomizationFormText = "Khoa - phòng:";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(325, 26);
            this.layoutControlItem6.Text = "Khoa - phòng:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(68, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(162, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(163, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.phoneTextEdit;
            this.layoutControlItem7.CustomizationFormText = "Điện thoại:";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(325, 24);
            this.layoutControlItem7.Text = "Điện thoại:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(68, 13);
            // 
            // ucAction
            // 
            this.ucAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucAction.InvoiceState = SMHospitall.Ctr.InvoiceState.Empty;
            this.ucAction.Location = new System.Drawing.Point(0, 126);
            this.ucAction.Name = "ucAction";
            this.ucAction.Size = new System.Drawing.Size(327, 26);
            this.ucAction.TabIndex = 1;
            // 
            // frmOfficial
            // 
            this._PermissionAlias = "SMHospitall.Catalogue.Official";
            this._PermissionHow = SMHospitall.PermissionHow.ReadEAddEditDelete;
            this._PermissionName = "Thông tin công nhân viên chức";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(327, 152);
            this.Controls.Add(this.ucAction);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.Name = "frmOfficial";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Thông tin công nhân viên chức";
            ((System.ComponentModel.ISupportInitialize)(this.work)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.phoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officialBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sciencesLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sciencesXPCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.birthDayDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.birthDayDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit sciencesLookUpEdit;
        private System.Windows.Forms.BindingSource officialBindingSource;
        private DevExpress.XtraEditors.DateEdit birthDayDateEdit;
        private DevExpress.XtraEditors.TextEdit nameTextEdit;
        private DevExpress.XtraEditors.TextEdit codeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Ctr.UcAction1 ucAction;
        private DevExpress.Xpo.XPCollection sciencesXPCollection;
        private DevExpress.XtraEditors.LookUpEdit sexTextEdit;
        private DevExpress.XtraEditors.TextEdit phoneTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}
