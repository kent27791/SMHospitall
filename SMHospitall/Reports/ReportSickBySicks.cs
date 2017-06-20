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
using SMHospitall.DataReport;

namespace SMHospitall.Reports
{
    public partial class ReportSickBySicks : SMHospitall.Forms.frmBase
    {
        public ReportSickBySicks()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //cboSick.Properties.DataSource = work.Query<Data.Sick>().Select(p => new { Name = p.Name, This = p }).Distinct().ToList();
                dateEdit1.DateTime = DateTime.Now.AddMonths(-1).OnlyDate();
                dateEdit2.DateTime = DateTime.Now.AddDays(1).OnlyDate();
            };
            btnOk.Click += (s, e) =>
            {
                //var data = work.GetDataReportSickBySicks(dateEdit1.DateTime, dateEdit2.DateTime);
                //if (cboSick.EditValue != null)
                //    data.offwork = data.offwork.Where(p => p.Sick == cboSick.EditValue as Data.Sick).ToList();

                //ucReports1.Report = new Reports.rptReportSickBySicks()
                //{
                //    SickBySicks = data
                //};
                var sicks = cboSick.EditValue as Data.Sick;
                if (sicks != null)
                {
                    rptReportSickBySicks rpt = new rptReportSickBySicks(sicks.Id, dateEdit1.DateTime, dateEdit2.DateTime);
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
