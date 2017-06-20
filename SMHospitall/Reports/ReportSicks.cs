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
using SMHospitall.Ctr;

namespace SMHospitall.Reports
{
    public partial class ReportSicks : SMHospitall.Forms.frmBase
    {
        public ReportSicks()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                dateEdit1.DateTime = DateTime.Now.AddMonths(-1).OnlyDate();
                dateEdit2.DateTime = DateTime.Now.AddDays(1).OnlyDate();
            };
            btnOk.Click += (s, e) =>
            {
                ucReports1.Report = new Reports.rptReportSicks(dateEdit1.DateTime,dateEdit2.DateTime);
            };
            btnClose.Click += (s, e) => Close();
        }
        public DateTime from
        {
            set
            {
                dateEdit1.EditValue = value;
            }
        }
        public DateTime to
        {
            set
            {
                dateEdit2.EditValue = value;
            }
        }
    }
}
