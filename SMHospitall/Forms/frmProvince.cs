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
    public partial class frmProvince : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmProvince()
        {
            InitializeComponent();
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                if (provinces == null)
                    provinces = new Data.Provinces(work);
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(provinces);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                provinces = new Data.Provinces(work);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
        }

        public Data.Provinces provinces 
        {
            get
            {
                return provincesBindingSource.DataSource as Data.Provinces;
            }
            set
            {
                provincesBindingSource.DataSource = value as object ?? typeof(Data.Provinces);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }
        public int provinces_id
        {
            get
            {
                return provinces != null ? provinces_id : 0;
            }
            set
            {
                provinces = work.Query<Data.Provinces>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
