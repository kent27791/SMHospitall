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
using SMHospitall.Data;
using System.Xml.Serialization;
using DevExpress.Data.Filtering;
namespace SMHospitall.Forms
{
    public partial class frmOffWOrks : SMHospitall.Forms.frmBase
    {
        public frmOffWOrks()
        {
            InitializeComponent();
            gridView1.FocusedRowChanged += (s, e) =>
            {
                btnEdit.Enabled = btnDelete.Enabled = gridView1.GetFocusedRow() is Data.OffWork;
            };
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
            };
            btnRefresh.Click += (s, e) =>
            {
                work = new UnitOfWork();
                xpCollection.Session = work;
                bindingSource.DataSource = xpCollection;
                gridView1.RefreshData();
            };
            btnEdit.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                var fm = new frmOffWork();
                fm.Owner = this;
                fm.OffWork_Id = (gridView1.GetFocusedRow() as Data.OffWork).Id;
                fm.Show();
                fm.FormClosed += (s1, e1) => btnRefresh.PerformClick();
            };
            gridView1.RowClick += (s, e) =>
            {
                if (e.Clicks == 2)
                    btnEdit.PerformClick();
            };
            btnDelete.Click += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Delete);
                var obj = bindingSource.Current as Data.OffWork;
                if (obj != null)
                {
                    frmDelete frm = new frmDelete(obj);
                    if (frm.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                    {
                        btnRefresh.PerformClick();
                    }
                }
            };
            ucTime1.TimeChanged += (s, e) =>
            {
                xpCollection.Criteria = new GroupOperator(GroupOperatorType.And,
                    new BinaryOperator("DateTime", ucTime1.DateTimeFrom, BinaryOperatorType.GreaterOrEqual),
                    new BinaryOperator("DateTime", ucTime1.DateTimeTo, BinaryOperatorType.Less));
            };
            txtSearch.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtSearch.Text);
            };
            btnClose.Click += (s, e) => Close();
        }
    }
}
