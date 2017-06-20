using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.Data;
namespace SMHospitall.Forms
{
    public partial class frmDelete : DevExpress.XtraEditors.XtraForm
    {
        public frmDelete(Data.OffWork offwork)
        {
            InitializeComponent();
            labelControl1.Text = String.Format("Bạn chắc chắn muốn xoá: {0} ?", offwork.No);
            btnCance.Click += (s, e) =>
            {
                this.Close();
            };
            btnOk.Click += (s, e) =>
            {
                offwork.Delete();
                //offwork.Sick.Delete();
                offwork.work.CommitChanges();
                DialogResult = DialogResult.OK;
            };
        }
    }
}