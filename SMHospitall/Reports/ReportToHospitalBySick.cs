using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMHospitall.Reports
{
    public partial class ReportToHospitalBySick : SMHospitall.Forms.frmBase
    {
        public ReportToHospitalBySick()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                dateEdit1.DateTime = DateTime.Now.AddMonths(-1).OnlyDate();
                dateEdit2.DateTime = DateTime.Now.AddDays(1).OnlyDate();
            };
            btnOk.Click += (s, e) =>
            {
                var sicks = cboSick.EditValue as Data.Sick;
                if (sicks != null)
                {
                    rptReportToHospitallBySick rpt = new rptReportToHospitallBySick(sicks.Id, dateEdit1.DateTime, dateEdit2.DateTime);
                    ucReports1.Report = rpt;
                }
            };
            btnClose.Click += (s, e) =>
            {
                Close();
            };
        }
    }
}
