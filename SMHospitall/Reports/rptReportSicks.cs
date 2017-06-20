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
    public partial class rptReportSicks : SMHospitall.Reports.rptBase
    {
        int num = 0;
        public rptReportSicks()
        {
            InitializeComponent();
            numberPrint.BeforePrint += (s, e) =>
            {
                num++;
                numberPrint.Text = num.ToString();
            };
        }
        public rptReportSicks(DateTime from, DateTime to)
            : this()
        {
            reportsicksbindingSource.DataSource = work.GetDataReportSicks(from, to);
        }
    }
}
