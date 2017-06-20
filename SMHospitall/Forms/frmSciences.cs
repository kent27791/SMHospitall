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
using SMHospitall.Ctr;

namespace SMHospitall.Forms
{
    public partial class frmSciences : SMHospitall.Forms.frmBase
    {
        public frmSciences()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.Sciences;
            };
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnDelete.Enabled = btnEdit.Enabled = gridView1.GetFocusedRow() is Data.Sciences;
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmScience() { Owner = this };
                fm.OnSaved += t =>
                {
                    SciencesXPCollection.Reload();
                    t = work.Query<Data.Sciences>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmScience() { Owner = this };
                fm.sciences_Id = (gridView1.GetFocusedRow() as Data.Sciences).Id;
                fm.OnSaved += t =>
                {
                    SciencesXPCollection.Reload();
                    t = work.Query<Data.Sciences>().FirstOrDefault(p => p.Id == t.Id);
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
                        SciencesXPCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            btnRefresh.Click += (s, e) =>
            {
                SciencesXPCollection.Session = work = new UnitOfWork();
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
