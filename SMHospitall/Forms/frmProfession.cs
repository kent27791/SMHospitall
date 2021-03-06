﻿using System;
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
    public partial class frmProfession : SMHospitall.Forms.frmBase
    {
        public frmProfession()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.Profession;
            };
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnDelete.Enabled = btnEdit.Enabled = gridView1.GetFocusedRow() is Data.Profession;
            };
            btnAdd.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                var fm = new frmProfession2() { Owner = this };
                fm.OnSaved += t =>
                {
                    professionXPCollection.Reload();
                    t = work.Query<Data.Profession>().FirstOrDefault(p => p.Id == t.Id);
                    if (t != null)
                        t.Reload();
                    gridView1.SetFocuseRow(t);
                };
                fm.Show();
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmProfession2() { Owner = this };
                fm.Profession_Id = (gridView1.GetFocusedRow() as Data.Profession).Id;
                fm.OnSaved += t =>
                {
                    professionXPCollection.Reload();
                    t = work.Query<Data.Profession>().FirstOrDefault(p => p.Id == t.Id);
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
                var obj = bindingSource.Current as Data.XPObject;
                if (obj != null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá: " + obj, "Thông báo", MessageBoxButtons.OKCancel);
                    if (xtr == DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        professionXPCollection.Reload();
                        gridView1.RefreshData();
                    }

                }
            };
            txtSearch.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtSearch.Text);
            };
            btnRefresh.Click += (s, e) =>
            {
                professionXPCollection.Session = work = new UnitOfWork();
                gridView1.RefreshData();
            };
            btnClose.Click += (s, e) =>
            {
                Close();
            };
        }
    }
}
