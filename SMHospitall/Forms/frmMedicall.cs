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
    public partial class frmMedicall : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmMedicall()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (Medicall == null)
                    Medicall = new Data.Medicall(work);
            };
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(Medicall);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                Medicall = new Data.Medicall(work);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.DelButtonClick += (s, e) =>
            {

            };
            provincesLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmProvince() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        ProvinceXPCollection.Reload();
                        Medicall.Provinces = work.Query<Data.Provinces>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
        }

        public Data.Medicall Medicall
        {
            get
            {
                return medicallBindingSource.DataSource as Data.Medicall;
            }
            set
            {
                medicallBindingSource.DataSource = value as object ?? typeof(Data.Medicall);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int Medicall_Id 
        {
            get
            {
                return Medicall != null ? Medicall_Id : 0;
            }
            set
            {
                Medicall = work.Query<Data.Medicall>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
