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

namespace SMHospitall.Forms
{
    public partial class frmMedicalls : SMHospitall.Forms.frmBase
    {
        public frmMedicalls()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnDelete.Enabled = btnEdit.Enabled = gridView1.GetFocusedRow() is Data.Medicall;
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmMedicall() { Owner = this };
                fm.OnSaved += t =>
                {
                    medicallXPCollection.Reload();
                    t = work.Query<Data.Medicall>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmMedicall() { Owner = this };
                fm.Medicall_Id = (gridView1.GetFocusedRow() as Data.Medicall).Id;
                fm.OnSaved += t =>
                {
                    medicallXPCollection.Reload();
                    t = work.Query<Data.Medicall>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.RefreshData();
                };
                fm.Show();
            };
            gridView1.RowClick += (s, e) =>
            {
                if (e.Clicks == 2)
                    btnEdit.PerformClick();
            };
            btnDelete.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Delete);
                var obj = bindingSource.Current as Data.XPObject;
                if (obj != null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá: " + obj, "Thông báo", MessageBoxButtons.OKCancel);
                    if (xtr == DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        medicallXPCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            btnRefresh.Click += (s, e) =>
            {
                medicallXPCollection.Session = work = new UnitOfWork();
                gridView1.RefreshData();
            };
            txtSearch.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtSearch.Text);
            };
            btnClose.Click += (s, e) => { this.Close(); };
        }
    }
}
