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
using DevExpress.Data.Linq;
using SMHospitall.Ctr;

namespace SMHospitall.Forms
{
    public partial class frmSicks : SMHospitall.Forms.frmBase
    {
        public frmSicks()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmSick();
                fm.Owner = this;
                fm.Onsaved += t =>
                {
                    sickxpCollection.Reload();
                    t = work.Query<Data.Sick>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmSick();
                fm.Owner = this;
                fm.sick_id = (gridView1.GetFocusedRow() as Data.Sick).Id;
                fm.Onsaved += t =>
                {
                    sickxpCollection.Reload();
                    t = work.Query<Data.Sick>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnDelete.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Delete);
                var obj = sickbindingSource.Current as Data.XPObject;
                if (obj!=null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá: " + obj, "Thông báo", MessageBoxButtons.OKCancel);
                    if (xtr==DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        sickxpCollection.Reload();
                        gridView1.RefreshData();
                    }
                }
            };
            btnClose.Click += (s, e) => { this.Close(); };
            btnRefresh.Click += (s, e) =>
            {
                sickxpCollection.Session = work = new UnitOfWork();
                gridView1.RefreshData();
            };
            txtKeyEdit.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtKeyEdit.Text);
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.Sick;
            };
            gridView1.RowClick += (s, e) =>
            {
                if (e.Clicks == 2)
                    btnEdit.PerformClick();
            };
        }
    }
}
