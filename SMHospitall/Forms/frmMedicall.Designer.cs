namespace SMHospitall.Forms
{
    partial class frmMedicall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicall));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.medicallBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProvinceXPCollection = new DevExpress.Xpo.XPCollection();
            this.ucAction = new SMHospitall.Ctr.UcAction1();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.faxTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.phoneTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.addressTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.provincesLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.nameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.work)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicallBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvinceXPCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.faxTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provincesLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // medicallBindingSource
            // 
            this.medicallBindingSource.DataSource = typeof(SMHospitall.Data.Medicall);
            // 
            // ProvinceXPCollection
            // 
            this.ProvinceXPCollection.ObjectType = typeof(SMHospitall.Data.Provinces);
            this.ProvinceXPCollection.Session = this.work;
            // 
            // ucAction
            // 
            this.ucAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucAction.InvoiceState = SMHospitall.Ctr.InvoiceState.Empty;
            this.ucAction.Location = new System.Drawing.Point(0, 126);
            this.ucAction.Name = "ucAction";
            this.ucAction.Size = new System.Drawing.Size(367, 26);
            this.ucAction.TabIndex = 1;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.faxTextEdit);
            this.layoutControl1.Controls.Add(this.phoneTextEdit);
            this.layoutControl1.Controls.Add(this.addressTextEdit);
            this.layoutControl1.Controls.Add(this.provincesLookUpEdit);
            this.layoutControl1.Controls.Add(this.nameTextEdit);
            this.layoutControl1.Controls.Add(this.codeTextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(367, 124);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // faxTextEdit
            // 
            this.faxTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.medicallBindingSource, "Fax", true));
            this.faxTextEdit.Location = new System.Drawing.Point(242, 101);
            this.faxTextEdit.Name = "faxTextEdit";
            this.faxTextEdit.Size = new System.Drawing.Size(122, 20);
            this.faxTextEdit.StyleController = this.layoutControl1;
            this.faxTextEdit.TabIndex = 10;
            // 
            // phoneTextEdit
            // 
            this.phoneTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.medicallBindingSource, "Phone", true));
            this.phoneTextEdit.Location = new System.Drawing.Point(60, 101);
            this.phoneTextEdit.Name = "phoneTextEdit";
            this.phoneTextEdit.Size = new System.Drawing.Size(121, 20);
            this.phoneTextEdit.StyleController = this.layoutControl1;
            this.phoneTextEdit.TabIndex = 9;
            // 
            // addressTextEdit
            // 
            this.addressTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.medicallBindingSource, "Address", true));
            this.addressTextEdit.Location = new System.Drawing.Point(60, 77);
            this.addressTextEdit.Name = "addressTextEdit";
            this.addressTextEdit.Size = new System.Drawing.Size(304, 20);
            this.addressTextEdit.StyleController = this.layoutControl1;
            this.addressTextEdit.TabIndex = 8;
            // 
            // provincesLookUpEdit
            // 
            this.provincesLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.medicallBindingSource, "Provinces", true));
            this.provincesLookUpEdit.Location = new System.Drawing.Point(60, 51);
            this.provincesLookUpEdit.Name = "provincesLookUpEdit";
            this.provincesLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("provincesLookUpEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.provincesLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", 10, "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên")});
            this.provincesLookUpEdit.Properties.DataSource = this.ProvinceXPCollection;
            this.provincesLookUpEdit.Properties.DisplayMember = "Name";
            this.provincesLookUpEdit.Properties.NullText = "";
            this.provincesLookUpEdit.Properties.ValueMember = "This";
            this.provincesLookUpEdit.Size = new System.Drawing.Size(304, 22);
            this.provincesLookUpEdit.StyleController = this.layoutControl1;
            this.provincesLookUpEdit.TabIndex = 7;
            // 
            // nameTextEdit
            // 
            this.nameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.medicallBindingSource, "Name", true));
            this.nameTextEdit.Location = new System.Drawing.Point(60, 27);
            this.nameTextEdit.Name = "nameTextEdit";
            this.nameTextEdit.Size = new System.Drawing.Size(304, 20);
            this.nameTextEdit.StyleController = this.layoutControl1;
            this.nameTextEdit.TabIndex = 6;
            // 
            // codeTextEdit
            // 
            this.codeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.medicallBindingSource, "Code", true));
            this.codeTextEdit.Location = new System.Drawing.Point(60, 3);
            this.codeTextEdit.Name = "codeTextEdit";
            this.codeTextEdit.Size = new System.Drawing.Size(120, 20);
            this.codeTextEdit.StyleController = this.layoutControl1;
            this.codeTextEdit.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(367, 124);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.codeTextEdit;
            this.layoutControlItem2.CustomizationFormText = "Mã:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(181, 24);
            this.layoutControlItem2.Text = "Mã:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(53, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(181, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(184, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.nameTextEdit;
            this.layoutControlItem3.CustomizationFormText = "Tên:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(365, 24);
            this.layoutControlItem3.Text = "Tên:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.provincesLookUpEdit;
            this.layoutControlItem4.CustomizationFormText = "Tỉnh:";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(365, 26);
            this.layoutControlItem4.Text = "Tỉnh:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.addressTextEdit;
            this.layoutControlItem5.CustomizationFormText = "Địa chỉ:";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(365, 24);
            this.layoutControlItem5.Text = "Địa chỉ:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.phoneTextEdit;
            this.layoutControlItem6.CustomizationFormText = "Điện thoại:";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(182, 24);
            this.layoutControlItem6.Text = "Điện thoại:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.faxTextEdit;
            this.layoutControlItem7.CustomizationFormText = "Fax:";
            this.layoutControlItem7.Location = new System.Drawing.Point(182, 98);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(183, 24);
            this.layoutControlItem7.Text = "Fax:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(53, 13);
            // 
            // frmMedicall
            // 
            this._PermissionAlias = "SMHospitall.Catalogue.Medicall";
            this._PermissionHow = SMHospitall.PermissionHow.ReadEAddEditDelete;
            this._PermissionName = "Thông tin bệnh viện";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(367, 152);
            this.Controls.Add(this.ucAction);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.Name = "frmMedicall";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Thông tin bệnh viện";
            ((System.ComponentModel.ISupportInitialize)(this.work)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicallBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProvinceXPCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.faxTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provincesLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit faxTextEdit;
        private System.Windows.Forms.BindingSource medicallBindingSource;
        private DevExpress.XtraEditors.TextEdit phoneTextEdit;
        private DevExpress.XtraEditors.TextEdit addressTextEdit;
        private DevExpress.XtraEditors.LookUpEdit provincesLookUpEdit;
        private DevExpress.XtraEditors.TextEdit nameTextEdit;
        private DevExpress.XtraEditors.TextEdit codeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private Ctr.UcAction1 ucAction;
        private DevExpress.Xpo.XPCollection ProvinceXPCollection;
    }
}
