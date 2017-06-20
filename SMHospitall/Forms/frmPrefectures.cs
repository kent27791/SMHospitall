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
    public partial class frmPrefectures : SMHospitall.Forms.frmBase
    {
        public frmPrefectures()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.Prefectures;
            };
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnDelete.Enabled = btnEdit.Enabled = gridView1.GetFocusedRow() is Data.Prefectures;
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmPrefecture() { Owner = this };
                fm.OnSaved += t =>
                {
                    prefecturesXPCollection.Reload();
                    t = work.Query<Data.Prefectures>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            }; 
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmPrefecture() { Owner = this };
                fm.prefecture_id = (gridView1.GetFocusedRow() as Data.Prefectures).Id;
                fm.OnSaved += t =>
                {
                    prefecturesXPCollection.Reload();
                    t = work.Query<Data.Prefectures>().FirstOrDefault(p => p.Id == t.Id);
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
                if (obj!=null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá: " + obj, "Thông báo", MessageBoxButtons.OKCancel);
                    if (xtr==DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        prefecturesXPCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            btnRefresh.Click += (s, e) =>
            {
                prefecturesXPCollection.Session = work = new UnitOfWork();
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
