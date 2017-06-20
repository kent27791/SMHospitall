namespace SMHospitall.Ctr
{
    partial class UcPermission
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tree = new DevExpress.XtraTreeList.TreeList();
            this.colThis = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFull = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRead = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAdd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEdit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colReport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.permissionSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.Controls.Add(this.tree);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(501, 394);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Phân quyền hệ thống";
            // 
            // tree
            // 
            this.tree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colThis,
            this.colFull,
            this.colRead,
            this.colAdd,
            this.colEdit,
            this.colDelete,
            this.colReport});
            this.tree.CustomizationFormBounds = new System.Drawing.Rectangle(1141, 447, 216, 178);
            this.tree.DataSource = this.permissionSetBindingSource;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.KeyFieldName = "This";
            this.tree.Location = new System.Drawing.Point(2, 22);
            this.tree.Name = "tree";
            this.tree.OptionsBehavior.PopulateServiceColumns = true;
            this.tree.ParentFieldName = "Parent";
            this.tree.Size = new System.Drawing.Size(497, 370);
            this.tree.TabIndex = 0;
            // 
            // colThis
            // 
            this.colThis.Caption = "Chức năng";
            this.colThis.FieldName = "This";
            this.colThis.Name = "colThis";
            this.colThis.OptionsColumn.AllowEdit = false;
            this.colThis.SortOrder = System.Windows.Forms.SortOrder.Descending;
            this.colThis.Visible = true;
            this.colThis.VisibleIndex = 0;
            this.colThis.Width = 173;
            // 
            // colFull
            // 
            this.colFull.AppearanceHeader.Options.UseTextOptions = true;
            this.colFull.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFull.Caption = "Đầy đủ";
            this.colFull.FieldName = "Full";
            this.colFull.Name = "colFull";
            this.colFull.OptionsColumn.FixedWidth = true;
            this.colFull.Visible = true;
            this.colFull.VisibleIndex = 1;
            this.colFull.Width = 56;
            // 
            // colRead
            // 
            this.colRead.AppearanceHeader.Options.UseTextOptions = true;
            this.colRead.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRead.Caption = "Đọc";
            this.colRead.FieldName = "Read";
            this.colRead.Name = "colRead";
            this.colRead.OptionsColumn.FixedWidth = true;
            this.colRead.Visible = true;
            this.colRead.VisibleIndex = 2;
            this.colRead.Width = 50;
            // 
            // colAdd
            // 
            this.colAdd.AppearanceHeader.Options.UseTextOptions = true;
            this.colAdd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAdd.Caption = "Thêm";
            this.colAdd.FieldName = "Add";
            this.colAdd.Name = "colAdd";
            this.colAdd.OptionsColumn.FixedWidth = true;
            this.colAdd.Visible = true;
            this.colAdd.VisibleIndex = 3;
            this.colAdd.Width = 49;
            // 
            // colEdit
            // 
            this.colEdit.AppearanceHeader.Options.UseTextOptions = true;
            this.colEdit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEdit.Caption = "Sửa";
            this.colEdit.FieldName = "Edit";
            this.colEdit.Name = "colEdit";
            this.colEdit.OptionsColumn.FixedWidth = true;
            this.colEdit.Visible = true;
            this.colEdit.VisibleIndex = 4;
            this.colEdit.Width = 47;
            // 
            // colDelete
            // 
            this.colDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.colDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDelete.Caption = "Xoá";
            this.colDelete.FieldName = "Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.OptionsColumn.FixedWidth = true;
            this.colDelete.Visible = true;
            this.colDelete.VisibleIndex = 5;
            this.colDelete.Width = 52;
            // 
            // colReport
            // 
            this.colReport.AppearanceHeader.Options.UseTextOptions = true;
            this.colReport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReport.Caption = "In";
            this.colReport.FieldName = "Report";
            this.colReport.Name = "colReport";
            this.colReport.OptionsColumn.FixedWidth = true;
            this.colReport.Visible = true;
            this.colReport.VisibleIndex = 6;
            this.colReport.Width = 52;
            // 
            // permissionSetBindingSource
            // 
            this.permissionSetBindingSource.DataSource = typeof(SMHospitall.Data.PermissionSet);
            // 
            // UcPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "UcPermission";
            this.Size = new System.Drawing.Size(501, 394);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList tree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colThis;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFull;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRead;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAdd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colReport;
        private System.Windows.Forms.BindingSource permissionSetBindingSource;
    }
}
