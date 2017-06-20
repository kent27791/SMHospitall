using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace SMHospitall.Reports
{
    public partial class ReportDevExpess : DevExpress.XtraEditors.XtraForm
    {
        public ReportDevExpess()
        {
            InitializeComponent();
        }
        public ReportDevExpess(XtraReport rpt)
        {
            InitializeComponent();
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument();
        }
    }
}