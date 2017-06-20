using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMHospitall.Forms
{
    public partial class frmSearchObject : SMHospitall.Forms.frmBase
    {
        public frmSearchObject()
        {
            InitializeComponent();
            txtSearch.TextChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(txtSearch.Text);
            };
            gridView1.RowClick += (s, e) =>
            {
                if (e.Clicks==2)
                {
                    Sick = gridView1.GetFocusedRow() as Data.Sick;
                    DialogResult = DialogResult.OK;
                }
            };
        }

        public Data.Sick Sick { get; set; }
        public List<Data.Sick> Sicks
        {
            set
            {
                    gridControl1.DataSource = value;
            }
        }
    }
}
