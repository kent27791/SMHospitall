using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Xpo;
using System.Data;
using DevExpress.XtraEditors;
using SMHospitall.Data;
using SMHospitall.DataReport;
namespace SMHospitall.Reports
{
    public partial class rptReportSickBySicks : SMHospitall.Reports.rptBase
    {
        int num = 0;
        public rptReportSickBySicks()
        {
            InitializeComponent();
            numberPrint.BeforePrint += (s, e) =>
            {
                num++;
                numberPrint.Text = num.ToString();
            };
        }
        //public DataReport.reportSicksBySicks SickBySicks
        //{
        //    set
        //    {
        //        sickbysicksbindingSource.DataSource = value;
        //    }
        //}
        public rptReportSickBySicks(int sickid, DateTime from, DateTime to)
            : this()
        {
            sickbysicksbindingSource.DataSource = work.GetDataReportSickBySicks(sickid,from, to);
            //this.DataSource = work.GetDataReportSickBySicks(sickid, from, to);
        }
    }
}
