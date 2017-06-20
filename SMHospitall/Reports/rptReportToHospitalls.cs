using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using DevExpress.Xpo;
using System.Data;
using DevExpress.XtraEditors;
namespace SMHospitall.Reports
{
    public partial class rptReportToHospitalls : SMHospitall.Reports.rptBase
    {
        int num = 0;
        public rptReportToHospitalls()
        {
            InitializeComponent();
            colNumber.BeforePrint += (s, e) =>
            {
                num = num + 1;
                colNumber.Text = num.ToString();
            };
        }
        public rptReportToHospitalls(DateTime from, DateTime to)
            : this()
        {
            tohospitallBindingSource.DataSource = work.GetDataReportToHospitall(from, to);
        }
    }
}
