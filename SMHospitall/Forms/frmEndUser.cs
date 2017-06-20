using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.Xpo;
namespace SMHospitall.Forms
{
    public partial class frmEndUser : SMHospitall.Forms.frmBase
    {
        public frmEndUser()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Read);
                endUserBindingSource.DataSource = work.Query<Data.EndUser>().FirstOrDefault() ?? new Data.EndUser(work);
            };
            btnCance.Click += (s, e) =>
            {
                Close();
            };
            btnOk.Click += (s, e) =>
            {
                work.CommitChanges();
                btnCance.PerformClick();
            };
        }
    }
}
