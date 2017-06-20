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
    public partial class frmPrefecture : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmPrefecture()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (prefecture == null)
                    prefecture = new Data.Prefectures(work);
            };
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(prefecture);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                prefecture = new Data.Prefectures(work);
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
                        provincesXPCollection.Reload();
                        prefecture.Provinces = work.Query<Data.Provinces>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
        }

        public Data.Prefectures prefecture 
        {
            get
            {
                return prefecturesBindingSource.DataSource as Data.Prefectures;
            }
            set
            {
                prefecturesBindingSource.DataSource = value as object ?? typeof(Data.Prefectures);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int prefecture_id 
        {
            get
            {
                return prefecture != null ? prefecture_id : 0;
            }
            set 
            {
                prefecture = work.Query<Data.Prefectures>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
