using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.Xpo;

namespace SMHospitall.Reports
{
    public partial class rptOffWork : SMHospitall.Reports.rptBase
    {
        public rptOffWork()
        {
            InitializeComponent();
        }
        public rptOffWork(Data.OffWork offwork)
            : this()
        {
            offWorkbindingSource.DataSource = offwork;
        }
    }
}
