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
    public partial class frmSickToHospitall : SMHospitall.Forms.frmBase
    {
        public event SaveHandler Onsaved = t => { };
        public frmSickToHospitall()
        {
            InitializeComponent();
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                var gt = Enum.GetValues(typeof(Data.Sick.GioiTinh))
                             .Cast<Data.Sick.GioiTinh>()
                             .Select(p => new { This = p, Name = p.Description() });
                sexLookUpEdit.Properties.DataSource = gt.ToList();
                if (sick == null)
                    sick = new Data.Sick(work,Data.SickType.ToHospitall);
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                Onsaved(sick);
            };
            peopleLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmPeople() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        PeopleXP.Reload();
                        sick.People = work.Query<Data.People>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
            professionLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmProfession2() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        ProfessionXP.Reload();
                        sick.Profession = work.Query<Data.Profession>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
            districtLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmDistrict() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        DistrictXP.Reload();
                        sick.district = work.Query<Data.district>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
            prefecturesLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmPrefecture() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        PrefectureXP.Reload();
                        sick.Prefectures = work.Query<Data.Prefectures>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
            provinceLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmProvince() { Owner = this };
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        ProvinceXP.Reload();
                        sick.Province = work.Query<Data.Provinces>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Show();
                }
            };
            //medicallLookUpEdit.ButtonClick += (s, e) =>
            //{
            //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            //    {
            //        var fm = new frmMedicall() { Owner = this };
            //        fm.OnSaved += t =>
            //        {
            //            fm.Show();
            //            medicallxpCollection.Reload();
            //            sick.Medicall = work.Query<Data.Medicall>().FirstOrDefault(p => p.Id == t.Id);
            //        };
            //        fm.Show();
            //    }
            //};
            ucAction.NewButtonClick += (s, e) =>
            {
                sick = new Data.Sick(work,Data.SickType.ToHospitall);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
        }
        public Data.Sick sick
        {
            get
            {
                return sickBindingSource.DataSource as Data.Sick;
            }
            set
            {
                sickBindingSource.DataSource = value as object ?? typeof(Data.Sick);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int sick_id
        {
            get
            {
                return sick != null ? sick_id : 0;
            }
            set
            {
                sick = work.Query<Data.Sick>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
