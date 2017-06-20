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
    public partial class frmPeople : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmPeople()
        {
            InitializeComponent();
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                if (People == null)
                    People = new Data.People(work);
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(People);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                People = new Data.People(work);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };

        }

        public Data.People People
        {
            get
            {
                return peopleBindingSource.DataSource as Data.People;
            }
            set
            {
            	peopleBindingSource.DataSource = value as object ?? typeof(Data.People);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int People_Id
        {
            get
            {
                return People != null ? People_Id : 0;
            }
            set
            {
                People = work.Query<Data.People>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
