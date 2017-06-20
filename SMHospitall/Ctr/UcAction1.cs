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
    public partial class UcAction1 : DevExpress.XtraEditors.XtraUserControl
    {
        public UcAction1()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                var fm = FindForm() as Forms.frmBase;
            };
            Dock = System.Windows.Forms.DockStyle.Bottom;
            btnAdd.Click += (s, e) => NewButtonClick(s, e);
            btnEdit.Click += (s, e) =>
            {
                FindForm().Validate();
                if (InvoiceState == Ctr.InvoiceState.InvoiceSaved)
                    EditButtonClick(s, e);
                else
                    SaveButtonClick(s, e);
            };
            btnClose.Click += (s, e) =>
            {
                FindForm().Close();
            };
        }
        public event EventHandler NewButtonClick = (s, e) => { };
        public event EventHandler EditButtonClick = (s, e) => { };
        public event EventHandler DelButtonClick = (s, e) => { };
        public event EventHandler SaveButtonClick = (s, e) => { };
        public event EventHandler InvoiceStateChanged = (s, e) => { };
        public InvoiceState _InvoiceState = InvoiceState.Empty;
        public InvoiceState InvoiceState
        {
            get
            {
                return _InvoiceState;
            }
            set
            {
                _InvoiceState = value;
                InvoiceStateChanged(value, new EventArgs());
                if (value == Ctr.InvoiceState.Empty)
                {
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = btnDelete.Enabled = false;
                }
                else
                {
                    btnEdit.Enabled = InvoiceState != Ctr.InvoiceState.Empty;
                    btnAdd.Enabled = btnDelete.Enabled = InvoiceState == Ctr.InvoiceState.InvoiceSaved;
                }
                btnEdit.Text = InvoiceState == Ctr.InvoiceState.InvoiceEditing ? "Lưu" : "Sửa";
                btnEdit.Image = InvoiceState == Ctr.InvoiceState.InvoiceEditing ? Properties.Resources.save_icon : Properties.Resources.edit1_icon;
            }
        }
    }
}
