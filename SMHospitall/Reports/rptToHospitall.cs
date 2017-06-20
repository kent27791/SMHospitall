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
    public partial class rptToHospitall : SMHospitall.Reports.rptBase
    {
        public rptToHospitall()
        {
            InitializeComponent();
        }
        public rptToHospitall(Data.ToHospitall toHospitall)
            : this()
        {
            toHospitallBindingSource.DataSource = toHospitall;
        }
    }
}
