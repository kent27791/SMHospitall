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
    public partial class frmUsers : SMHospitall.Forms.frmBase
    {
        public frmUsers()
        {
            InitializeComponent();
            Data.User.Users = UserXPCollection;

            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmUser() { Owner = this };
                fm.Show();
                fm.OnSaved += t =>
                {
                    UserXPCollection.Reload();
                    t = work.Query<Data.User>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmUser();
                fm.Owner = this;
                fm.User_Id = (gridView1.GetFocusedRow() as Data.User).Id;
                fm.Show();
                fm.OnSaved += t =>
                {
                    UserXPCollection.Reload();
                    t = work.Query<Data.User>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
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
                        UserXPCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.User;
            };
            gridView1.RowClick += (s, e) =>
            {
                if (e.Clicks == 2)
                    btnEdit.PerformClick();
            };
            txtSearch.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtSearch.Text);
            };
        }
    }
}
