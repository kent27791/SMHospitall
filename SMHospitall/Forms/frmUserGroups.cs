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
    public partial class frmUserGroups : SMHospitall.Forms.frmBase
    {
        public frmUserGroups()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmUserGroup() { Owner = this };
                fm.Show();
                fm.OnSaved += t =>
                {
                    xpCollection.Reload();
                    t = work.Query<Data.UserGroup>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmUserGroup() { Owner = this };
                fm.UserGroup_Id = (gridView1.GetFocusedRow() as Data.UserGroup).Id;
                fm.Show();
                fm.OnSaved += t =>
                {
                    xpCollection.Reload();
                    t = work.Query<Data.UserGroup>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
            };
            btnDelete.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Delete);
                var obj = bindingSource.Current as Data.XPObject;
                if (obj != null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá nhóm nhân viên: " + obj, "Thông báo", MessageBoxButtons.OKCancel);
                    if (xtr == DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        xpCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            gridView1.RowClick += (s, e) =>
            {
                if (e.Clicks == 2)
                    btnEdit.PerformClick();
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnDelete.Enabled = btnEdit.Enabled = gridView1.GetFocusedRow() is Data.UserGroup;
            };
        }
    }
}
