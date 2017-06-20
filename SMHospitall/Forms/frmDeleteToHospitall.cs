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
    public partial class frmDeleteToHospitall : XtraForm
    {
        public frmDeleteToHospitall(Data.ToHospitall Hospitall)
        {
            InitializeComponent();
            labelControl1.Text = String.Format("Bạn chắc chắn muốn xoá: {0} ?", Hospitall.No);
            btnCance.Click += (s, e) =>
            {
                Close();
            };
            btnOk.Click += (s, e) =>
            {
                Hospitall.Delete();
                //offwork.Sick.Delete();
                Hospitall.work.CommitChanges();
                DialogResult = DialogResult.OK;
            };
        }
    }
}