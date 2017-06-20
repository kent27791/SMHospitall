﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMHospitall.Reports
{
    public partial class ReportToHospitalByDoctor : SMHospitall.Forms.frmBase
    {
        public ReportToHospitalByDoctor()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                dateEdit1.DateTime = DateTime.Now.AddMonths(-1).OnlyDate();
                dateEdit2.DateTime = DateTime.Now.AddDays(1).OnlyDate();
            };
            btnOk.Click += (s, e) =>
            {
                var sicks = cboOfficall.EditValue as Data.Official;
                if (sicks != null)
                {
                    rptReportToHospitallByDoctor rpt = new rptReportToHospitallByDoctor(sicks.Id, dateEdit1.DateTime, dateEdit2.DateTime);
                    ucReports1.Report = rpt;
                }
            };
            btnCance.Click += (s, e) => Close();
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
