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
    public partial class rptReportSicksByDoctors : SMHospitall.Reports.rptBase
    {
        int num = 0;
        public rptReportSicksByDoctors()
        {
            InitializeComponent();
            numberPrint.BeforePrint += (s, e) =>
            {
                num++;
                numberPrint.Text = num.ToString();
            };
        }
        public rptReportSicksByDoctors(int sickid,DateTime from, DateTime to)
            : this()
        {
            sickbyDoctorsbindingSource.DataSource = work.GetDataReportSickByDoctors(sickid,from, to);
            //this.DataSource = work.GetDataReportSickByDoctors(sickid, from, to);
        }
    }
}
