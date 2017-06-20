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
    public partial class frmOfficialGroup : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmOfficialGroup()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (Official == null)
                    Official = new Data.OfficialGroup(work);
            };
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(Official);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                Official = new Data.OfficialGroup(work);
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
                        Official.Medicall = work.Query<Data.Medicall>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
        }
        public Data.OfficialGroup Official
        {
            get
            {
                return officialGroupBindingSource.DataSource as Data.OfficialGroup;
            }
            set
            {
                officialGroupBindingSource.DataSource = value as object ?? typeof(Data.OfficialGroup);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int Official_Id
        {
            get
            {
                return Official != null ? Official_Id : 0;
            }
            set
            {
                Official = work.Query<Data.OfficialGroup>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
