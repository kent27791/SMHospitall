using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace SMHospitall.Reports
{
    public partial class UcReports : DevExpress.XtraEditors.XtraUserControl
    {
        public UcReports()
        {
            InitializeComponent();
        }
        public XtraReport Report
        {
            set
            {
                printControl1.PrintingSystem = value.PrintingSystem;
                value.CreateDocument();
            }
        }
    }
}
