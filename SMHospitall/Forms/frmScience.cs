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

namespace SMHospitall.Forms
{
    public partial class frmScience : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmScience()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (sciences == null)
                    sciences = new Data.Sciences(work);
            };
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(sciences);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                sciences = new Data.Sciences(work);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.DelButtonClick += (s, e) =>
            {

            };
            medicallLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmMedicall() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        medicallXPCollection.Reload();
                        sciences.Medicall = work.Query<Data.Medicall>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
        }

        public Data.Sciences sciences
        {
            get
            {
                return sciencesBindingSource.DataSource as Data.Sciences;
            }
            set
            {
                sciencesBindingSource.DataSource = value as object ?? typeof(Data.Sciences);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int sciences_Id
        {
            get
            {
                return sciences != null ? sciences_Id : 0;
            }
            set
            {
                sciences = work.Query<Data.Sciences>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
