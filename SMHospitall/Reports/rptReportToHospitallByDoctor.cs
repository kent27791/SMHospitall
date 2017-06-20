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
    public partial class rptReportToHospitallByDoctor : SMHospitall.Reports.rptBase
    {
        int num = 0;
        public rptReportToHospitallByDoctor()
        {
            InitializeComponent();
            colnumber.BeforePrint += (s, e) =>
            {
                num++;
                colnumber.Text = num.ToString();
            };
        }
        public rptReportToHospitallByDoctor(int sickid, DateTime from, DateTime to)
            : this()
        {
            toshospitalBindingSource.DataSource = work.GetdataToHospitallByDoctor(sickid,from, to);
            //this.DataSource = work.GetDataReportSickByDoctors(sickid, from, to);
        }

    }
}
