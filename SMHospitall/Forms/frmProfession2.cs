using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMHospitall.Ctr;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using System.Linq;

namespace SMHospitall.Forms
{
    public partial class frmProfession2 : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmProfession2()
        {
            InitializeComponent();
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                if (Profession == null)
                    Profession = new Data.Profession(work);
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(Profession);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                Profession = new Data.Profession(work);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
        }

        public Data.Profession Profession 
        {
            get
            {
                return professionBindingSource.DataSource as Data.Profession;
            }
            set
            {
                professionBindingSource.DataSource = value as object ?? typeof(Data.Profession);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int Profession_Id
        {
            get
            {
                return Profession != null ? Profession_Id : 0;
            }
            set
            {
                Profession = work.Query<Data.Profession>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
