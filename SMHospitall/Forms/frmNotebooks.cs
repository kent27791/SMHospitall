using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.Data;
using SMHospitall.Ctr;

namespace SMHospitall.Forms
{
    public partial class frmNotebooks : SMHospitall.Forms.frmBase
    {
        public frmNotebooks()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.Notebook;
            };
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmNotebook();
                fm.Owner = this;
                fm.OnSaved += t =>
                {
                    NotebookXPCollection.Reload();
                    t = work.Query<Data.Notebook>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmNotebook();
                fm.Owner = this;
                fm.notebook_id = (gridView1.GetFocusedRow() as Data.Notebook).Id;
                fm.OnSaved += t =>
                {
                    NotebookXPCollection.Reload();
                    t = work.Query<Data.Notebook>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnDelete.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Delete);
                var obj = NotebookBindingSource.Current as Data.XPObject;
                if (obj != null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá: " + obj, "Thông báo",MessageBoxButtons.OKCancel);
                    if (xtr==DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        NotebookXPCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            btnClose.Click += (s, e) =>
            {
                this.Close();
            };
            txtKeyEdit.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtKeyEdit.Text);
            };
            gridView1.RowClick += (s, e) =>
            {
                if (e.Clicks == 2)
                    btnEdit.PerformClick();
            };
        }
    }
}
