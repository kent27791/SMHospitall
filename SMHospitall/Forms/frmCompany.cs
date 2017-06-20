using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Data.Linq;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using System.Linq;
using SMHospitall.Ctr;
namespace SMHospitall.Forms
{
    public partial class frmCompany : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmCompany()
        {
            InitializeComponent();
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                if (company == null)
                    company = new Data.Company(work);
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(company);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                company = new Data.Company(work);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
        }

        public Data.Company company 
        {
            get
            {
                return companyBindingSource.DataSource as Data.Company;
            }
            set
            {
                companyBindingSource.DataSource = value as object ?? typeof(Data.Company);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }
        public int company_id
        {
            set
            {
                company = work.Query<Data.Company>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
