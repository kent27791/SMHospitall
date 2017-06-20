using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using DevExpress.Xpo;

namespace SMHospitall.Ctr
{
    public partial class UcTime : DevExpress.XtraEditors.XtraUserControl
    {
        public UcTime()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                dateEdit2.DateTime = DateTime.Now.OnlyDate().AddDays(1);
                dateEdit1.DateTime = TimeType == Ctr.TimeType.OneDate ? DateTime.Now.OnlyDate() : DateTime.Now.OnlyDate().AddMonths(1);
                dateEdit1.EditValueChanged += (s1, e1) => TimeChanged(s1, e1);
                dateEdit2.EditValueChanged += (s1, e1) => TimeChanged(s1, e1);
            };
        }
        public TimeType TimeType
        {
            get;
            set;
        }
        public DateTime DateTimeFrom
        {
            get
            {
                return dateEdit1.DateTime;
            }
            set
            {
                dateEdit1.DateTime = value;
            }
        }
        public DateTime DateTimeTo
        {
            get
            {
                return dateEdit2.DateTime;
            }
            set
            {
                dateEdit2.DateTime = value;
            }
        }

        public event EventHandler TimeChanged = (s, e) => { };
    }
    public enum TimeType
    {
        OneDate,
        OneMonth,
    }
}
