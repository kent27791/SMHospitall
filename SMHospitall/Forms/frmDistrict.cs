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
    public partial class frmDistrict : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmDistrict()
        {
            InitializeComponent();
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                if (district == null)
                    district = new Data.district(work);
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(district);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                district = new Data.district(work);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            prefecturesLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmPrefecture() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        prefectureXPCollection.Reload();
                        district.prefectures = work.Query<Data.Prefectures>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
            provincesLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmProvince() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        provinceXPCollection.Reload();
                        district.Provinces = work.Query<Data.Provinces>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
        }

        public Data.district district 
        {
            get
            {
                return districtBindingSource.DataSource as Data.district;
            }
            set
            {
                districtBindingSource.DataSource = value as object ?? typeof(Data.district);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }
        public int district_id
        {
            set
            {
                district = work.Query<Data.district>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
