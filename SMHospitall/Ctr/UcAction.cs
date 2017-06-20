using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SMHospitall.Ctr
{
    public partial class UcAction : DevExpress.XtraEditors.XtraUserControl
    {
        public event EventHandler InvoiceStateChanged = (s, e) => { };
        public event EventHandler NewButtonClick = (s, e) => { };
        public event EventHandler EditButtonClick = (s, e) => { };
        public event EventHandler DelButtonClick = (s, e) => { };
        public event EventHandler SaveButtonClick = (s, e) => { };
        public event EventHandler PrintButtonClick = (s, e) => { };
        public event EventHandler ExitButtonClick = (s, e) => { };
        private InvoiceState _invoiceState = InvoiceState.Empty;
        public InvoiceState InvoiceState
        {
            get
            {
                return _invoiceState;
            }
            set
            {
                _invoiceState = value;
                InvoiceStateChanged(value, new EventArgs());
                btnPrint.Enabled = btnNew.Enabled = btnDel.Enabled = btnEdit.Enabled = InvoiceState == Ctr.InvoiceState.InvoiceSaved;
                btnOk.Enabled = btnSave.Enabled = InvoiceState == Ctr.InvoiceState.InvoiceEditing;
            }
        }
        public UcAction()
        {
            InitializeComponent();
            btnSave.Click += (s, e) =>
            {
                SaveButtonClick(s, e);
            };
            btnOk.Click += (s, e) =>
            {
                SaveButtonClick(s, e);
                PrintButtonClick(s, e);
                NewButtonClick(s, e);
            };
            btnNew.Click += (s, e) => NewButtonClick(s, e);
            btnEdit.Click += (s, e) => EditButtonClick(s, e);
            btnDel.Click += (s, e) => DelButtonClick(s, e);
            btnPrint.Click += (s, e) => PrintButtonClick(s, e);
            btnClose.Click += (s, e) => this.FindForm().Close();
        }
    }
    public enum InvoiceState
    {
        Empty=0,
        InvoiceSaved=1,
        InvoiceEditing=2,
    }
}
