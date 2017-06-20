namespace SMHospitall.Forms
{
    partial class frmDistrict
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDistrict));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.districtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prefectureXPCollection = new DevExpress.Xpo.XPCollection();
            this.provinceXPCollection = new DevExpress.Xpo.XPCollection();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.provincesLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.prefecturesLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.nameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.codeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.descriptionTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ucAction = new SMHospitall.Ctr.UcAction1();
            ((System.ComponentModel.ISupportInitialize)(this.work)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.districtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prefectureXPCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceXPCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.provincesLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prefecturesLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // districtBindingSource
            // 
            this.districtBindingSource.DataSource = typeof(SMHospitall.Data.district);
            // 
            // prefectureXPCollection
            // 
            this.prefectureXPCollection.ObjectType = typeof(SMHospitall.Data.Prefectures);
            this.prefectureXPCollection.Session = this.work;
            // 
            // provinceXPCollection
            // 
            this.provinceXPCollection.ObjectType = typeof(SMHospitall.Data.Provinces);
            this.provinceXPCollection.Session = this.work;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.provincesLookUpEdit);
            this.layoutControl1.Controls.Add(this.prefecturesLookUpEdit);
            this.layoutControl1.Controls.Add(this.nameTextEdit);
            this.layoutControl1.Controls.Add(this.codeTextEdit);
            this.layoutControl1.Controls.Add(this.descriptionTextEdit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(840, 384, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(356, 182);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // provincesLookUpEdit
            // 
            this.provincesLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.districtBindingSource, "Provinces", true));
            this.provincesLookUpEdit.Location = new System.Drawing.Point(92, 77);
            this.provincesLookUpEdit.Name = "provincesLookUpEdit";
            this.provincesLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("provincesLookUpEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.provincesLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", 10, "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên")});
            this.provincesLookUpEdit.Properties.DataSource = this.provinceXPCollection;
            this.provincesLookUpEdit.Properties.DisplayMember = "Name";
            this.provincesLookUpEdit.Properties.NullText = "";
            this.provincesLookUpEdit.Properties.ValueMember = "This";
            this.provincesLookUpEdit.Size = new System.Drawing.Size(261, 22);
            this.provincesLookUpEdit.StyleController = this.layoutControl1;
            this.provincesLookUpEdit.TabIndex = 9;
            // 
            // prefecturesLookUpEdit
            // 
            this.prefecturesLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.districtBindingSource, "prefectures", true));
            this.prefecturesLookUpEdit.Location = new System.Drawing.Point(92, 51);
            this.prefecturesLookUpEdit.Name = "prefecturesLookUpEdit";
            this.prefecturesLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("prefecturesLookUpEdit.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.prefecturesLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", 10, "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên")});
            this.prefecturesLookUpEdit.Properties.DataSource = this.prefectureXPCollection;
            this.prefecturesLookUpEdit.Properties.DisplayMember = "Name";
            this.prefecturesLookUpEdit.Properties.NullText = "";
            this.prefecturesLookUpEdit.Properties.ValueMember = "This";
            this.prefecturesLookUpEdit.Size = new System.Drawing.Size(261, 22);
            this.prefecturesLookUpEdit.StyleController = this.layoutControl1;
            this.prefecturesLookUpEdit.TabIndex = 7;
            // 
            // nameTextEdit
            // 
            this.nameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.districtBindingSource, "Name", true));
            this.nameTextEdit.Location = new System.Drawing.Point(92, 27);
            this.nameTextEdit.Name = "nameTextEdit";
            this.nameTextEdit.Size = new System.Drawing.Size(261, 20);
            this.nameTextEdit.StyleController = this.layoutControl1;
            this.nameTextEdit.TabIndex = 6;
            // 
            // codeTextEdit
            // 
            this.codeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.districtBindingSource, "Code", true));
            this.codeTextEdit.Location = new System.Drawing.Point(92, 3);
            this.codeTextEdit.Name = "codeTextEdit";
            this.codeTextEdit.Size = new System.Drawing.Size(95, 20);
            this.codeTextEdit.StyleController = this.layoutControl1;
            this.codeTextEdit.TabIndex = 5;
            // 
            // descriptionTextEdit
            // 
            this.descriptionTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.districtBindingSource, "Description", true));
            this.descriptionTextEdit.Location = new System.Drawing.Point(92, 103);
            this.descriptionTextEdit.Name = "descriptionTextEdit";
            this.descriptionTextEdit.Size = new System.Drawing.Size(261, 76);
            this.descriptionTextEdit.StyleController = this.layoutControl1;
            this.descriptionTextEdit.TabIndex = 8;
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
            this.layoutControlItem6});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(356, 182);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.codeTextEdit;
            this.layoutControlItem2.CustomizationFormText = "Mã:";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(188, 24);
            this.layoutControlItem2.Text = "Mã:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(85, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(188, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(166, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.nameTextEdit;
            this.layoutControlItem3.CustomizationFormText = "Tên:";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(354, 24);
            this.layoutControlItem3.Text = "Tên:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.prefecturesLookUpEdit;
            this.layoutControlItem4.CustomizationFormText = "Quận - Huyện:";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(354, 26);
            this.layoutControlItem4.Text = "Quận - Huyện:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.descriptionTextEdit;
            this.layoutControlItem5.CustomizationFormText = "Mô tả:";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(354, 80);
            this.layoutControlItem5.Text = "Mô tả:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(85, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.provincesLookUpEdit;
            this.layoutControlItem6.CustomizationFormText = "Tỉnh - Thành phố:";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(354, 26);
            this.layoutControlItem6.Text = "Tỉnh - Thành phố:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(85, 13);
            // 
            // ucAction
            // 
            this.ucAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucAction.InvoiceState = SMHospitall.Ctr.InvoiceState.Empty;
            this.ucAction.Location = new System.Drawing.Point(0, 184);
            this.ucAction.Name = "ucAction";
            this.ucAction.Size = new System.Drawing.Size(356, 26);
            this.ucAction.TabIndex = 1;
            // 
            // frmDistrict
            // 
            this._PermissionAlias = "SMHospitall.Catalogue.District";
            this._PermissionHow = SMHospitall.PermissionHow.ReadEAddEditDelete;
            this._PermissionName = "Thông tin Phường - Xã";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(356, 210);
            this.Controls.Add(this.ucAction);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.Name = "frmDistrict";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Thông tin Phường - Xã";
            ((System.ComponentModel.ISupportInitialize)(this.work)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.districtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prefectureXPCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceXPCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.provincesLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prefecturesLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.descriptionTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit prefecturesLookUpEdit;
        private System.Windows.Forms.BindingSource districtBindingSource;
        private DevExpress.XtraEditors.TextEdit nameTextEdit;
        private DevExpress.XtraEditors.TextEdit codeTextEdit;
        private DevExpress.XtraEditors.MemoEdit descriptionTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private Ctr.UcAction1 ucAction;
        private DevExpress.Xpo.XPCollection prefectureXPCollection;
        private DevExpress.XtraEditors.LookUpEdit provincesLookUpEdit;
        private DevExpress.Xpo.XPCollection provinceXPCollection;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}
