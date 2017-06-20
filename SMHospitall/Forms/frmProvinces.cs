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
    public partial class frmProvinces : SMHospitall.Forms.frmBase
    {
        public frmProvinces()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmProvince() { Owner = this };
                fm.OnSaved += t =>
                {
                    ProvincesXPCollection.Reload();
                    t = work.Query<Data.Provinces>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmProvince() { Owner = this };
                fm.provinces_id = (gridView1.GetFocusedRow() as Data.Provinces).Id;
                fm.Show();
                fm.OnSaved += t =>
                {
                    ProvincesXPCollection.Reload();
                    t = work.Query<Data.Provinces>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
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
                if (obj!=null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá: " + obj, "Thông báo", MessageBoxButtons.OKCancel);
                    if (xtr == DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        ProvincesXPCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnDelete.Enabled = btnEdit.Enabled = gridView1.GetFocusedRow() is Data.Provinces;
            };
            txtSearch.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtSearch.Text);
            };
            btnRefresh.Click += (s, e) =>
            {
                ProvincesXPCollection.Session = work = new UnitOfWork();
                gridView1.RefreshData();
            };
            btnClose.Click += (s, e) => Close();
        }
    }
}
