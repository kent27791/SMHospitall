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
using DevExpress.Data;
using SMHospitall.Ctr;
namespace SMHospitall.Forms
{
    public partial class frmNotebook : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmNotebook()
        {
            InitializeComponent();
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                if (notebook == null)
                    notebook = new Data.Notebook(work);
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(notebook);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
                notebook = new Data.Notebook(work);
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
        }

        public Data.Notebook notebook 
        {
            get
            {
                return notebookBindingSource.DataSource as Data.Notebook;
            }
            set
            {
                notebookBindingSource.DataSource = value as object ?? typeof(Data.Notebook);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }
        public int notebook_id
        {
            set
            {
                notebook = work.Query<Data.Notebook>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
