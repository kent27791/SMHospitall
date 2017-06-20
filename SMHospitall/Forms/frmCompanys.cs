using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.Xpo;

namespace SMHospitall.Forms
{
    public partial class frmCompanys : SMHospitall.Forms.frmBase
    {
        public frmCompanys()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.Company;
            };
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmCompany();
                fm.Owner = this;
                fm.OnSaved += t =>
                {
                    CompanyXPCollection.Reload();
                    t = work.Query<Data.Company>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmCompany();
                fm.Owner = this;
                fm.company_id = (gridView1.GetFocusedRow() as Data.Company).Id;
                fm.OnSaved += t =>
                {
                    CompanyXPCollection.Reload();
                    t = work.Query<Data.Company>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
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
                var obj = CompanyBindingSource.Current as Data.XPObject;
                if (obj != null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá: " + obj, "Thông báo", MessageBoxButtons.OKCancel);
                    if (xtr == DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        CompanyXPCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.Company;
            };
            btnRefresh.Click += (s, e) =>
            {
                CompanyXPCollection.Session = work = new UnitOfWork();
                gridView1.RefreshData();
            };
            txtKeyEdit.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtKeyEdit.Text);
            };
            btnClose.Click += (s, e) =>
            {
                this.Close();
            };
        }
    }
}
