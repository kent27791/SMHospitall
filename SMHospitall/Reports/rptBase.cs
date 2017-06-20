using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using System.Linq;

namespace SMHospitall.Reports
{
    public partial class rptBase : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBase()
        {
            InitializeComponent();
            try
            {
                endUserbindingSource.DataSource = new UnitOfWork().Query<Data.EndUser>().FirstOrDefault();

            }
            catch (Exception)
            {

                endUserbindingSource.DataSource = typeof(Data.EndUser);
            }
            BeforePrint += (s, e) =>
            {
                xrHeader.SendToBack();
            };
        }

    }
}
