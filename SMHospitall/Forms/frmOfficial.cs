using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.Xpo;
using SMHospitall.Ctr;
namespace SMHospitall.Forms
{
    public partial class frmOfficial : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmOfficial()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                var gt = Enum.GetValues(typeof(Data.Official.GioiTinh))
                             .Cast<Data.Official.GioiTinh>()
                             .Select(p => new { This = p, Name = p.Description() });
                sexTextEdit.Properties.DataSource = gt.ToList();
                if (Official == null)
                    Official = new Data.Official(work);
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
                Official = new Data.Official(work);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.DelButtonClick += (s, e) =>
            {

            };
            sciencesLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmScience() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        sciencesXPCollection.Reload();
                        Official.Sciences = work.Query<Data.Sciences>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
        }
        public Data.Official Official
        {
            get
            {
                return officialBindingSource.DataSource as Data.Official;
            }
            set
            {
                officialBindingSource.DataSource = value as object ?? typeof(Data.Official);
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
                Official = work.Query<Data.Official>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
