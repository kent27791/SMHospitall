using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SMHospitall.Ctr;
using System.Linq;
using DevExpress.Xpo;

namespace SMHospitall.Forms
{
    public partial class frmToHospitalls : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmToHospitalls()
        {
            InitializeComponent();
            ucAction1.InvoiceStateChanged += (s, e) =>
            {
                layoutControl4.Enabled = ucAction1.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                var gt = Enum.GetValues(typeof(Data.Sick.GioiTinh))
                             .Cast<Data.Sick.GioiTinh>()
                             .Select(p => new { This = p, Name = p.Description() });
                sexLookUpEdit.Properties.DataSource = gt.ToList();
                if (ToHospitall == null)
                {
                    this.CheckPermission(PermissionHow.Add);
                    ToHospitall = new Data.ToHospitall(work)
                    {
                        VietNammese = "Việt Nam",
                        Diagnosis = "Bình thường",
                        Reason = "Khám và điều trị",
                        Status = "Tỉnh táo",
                        Facilities = "Tự túc",
                        Clinical ="Bình thường",
                        Test = "Chưa",
                        Drugs ="Chưa",
                    };
                }
            };
            //Tim benh nhan
            btnCodeSick.ButtonClick += (s, e) =>
            {
                using (var fm = new frmSearchObject() { Sicks = work.Query<Data.Sick>().Where(p => !p.InActive).Cast<Data.Sick>().ToList() })
                {
                    if (fm.ShowDialog() == DialogResult.OK)
                    {
                        ToHospitall.Sick = fm.Sick as Data.Sick;
                    }
                }
            };
            //benh nhan moi
            btnCodeSick.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && btnCodeSick.Text.IsNullOrEmpty())
                {
                    if (ToHospitall.Sick == null)
                        ToHospitall.Sick = new Data.Sick(work);
                    ToHospitall.Sick.No = btnCodeSick.Text = ToHospitall.Sick.GetNewCode();
                }
            };
            //Cac lan chuyen vien
            btnCodeSick.EditValueChanged += (s, e) =>
            {
                gridView1.ApplyFindFilter(btnCodeSick.Text);
            };
            //Them dan toc
            peopleLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmPeople();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        peopleXP.Reload();
                        ToHospitall.Sick.People = work.Query<Data.People>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            //Them nghe nghiep
            professionLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmProfession2();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        professionXP.Reload();
                        ToHospitall.Sick.Profession = work.Query<Data.Profession>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            //Them xa
            districtLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmDistrict();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        districtXP.Reload();
                        ToHospitall.Sick.district = work.Query<Data.district>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            //Them huyen
            prefecturesLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmPrefecture();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        prefecturesXP.Reload();
                        ToHospitall.Sick.Prefectures = work.Query<Data.Prefectures>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            //Them tinh
            provinceLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmProvince();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        provinceXP.Reload();
                        ToHospitall.Sick.Province = work.Query<Data.Provinces>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            //Them khoa phong
            sciencesLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmScience();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        sciencesXP.Reload();
                        ToHospitall.Sick.Sciences = work.Query<Data.Sciences>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            //Them benh vien
            medicallLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmMedicall();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        medicallXP.Reload();
                        ToHospitall.Medicall = work.Query<Data.Medicall>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            //Them bác sỹ
            officialLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmOfficial();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        OfficialXP.Reload();
                        ToHospitall.Official = work.Query<Data.Official>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            ucAction1.SaveButtonClick += (s, e) =>
            {
                if (btnCodeSick.Text == null || btnCodeSick.Text.IsNullOrEmpty())
                    throw new Exception("Chưa nhập mã bệnh nhân");
                if (ToHospitall.Sick.Name == null || ToHospitall.Sick.Name.IsNullOrEmpty())
                    throw new Exception("Chưa nhập tên bệnh nhân");
                if (ToHospitall.Sick.Number == null || ToHospitall.Sick.Number.IsNullOrEmpty())
                    throw new Exception("Chưa nhập số thẻ bảo hiểm");
                if (ToHospitall.Sick.Sciences.Name == null || ToHospitall.Sick.Sciences.Name.IsNullOrEmpty())
                    throw new Exception("Chưa nhập điều trị tại khoa nào");
                if (ToHospitall.Medicall.Name == null || ToHospitall.Medicall.Name.IsNullOrEmpty())
                    throw new Exception("Chưa nhập tên bệnh viện cần chuyển đến");
                if (ToHospitall.Official.Name == null || ToHospitall.Official.Name.IsNullOrEmpty())
                    throw new Exception("Chưa nhập bác sỹ điều trị");
                if (ToHospitall.Reason == null || ToHospitall.Reason.IsNullOrEmpty())
                    throw new Exception("Chưa nhập lý do chuyển");
                if (ToHospitall.Clinical == null || ToHospitall.Clinical.IsNullOrEmpty())
                    throw new Exception("Chưa nhập dấu hiệu lâm sàng");
                if (ToHospitall.Test == null || ToHospitall.Test.IsNullOrEmpty())
                    throw new Exception("Chưa nhập các xét nghiệm đã làm");
                if (ToHospitall.Drugs == null || ToHospitall.Drugs.IsNullOrEmpty())
                    throw new Exception("Chưa nhập các thuốc đã dùng");
                work.CommitChanges();
                ucAction1.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(ToHospitall);
            };
            ucAction1.NewButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                ucAction1.InvoiceState = InvoiceState.InvoiceEditing;
                ToHospitall = new Data.ToHospitall(work)
                {
                    //VietNammese = "Việt Nam",
                    Diagnosis = "Bình thường",
                    Reason = "Khám và điều trị",
                    Status = "Tỉnh táo",
                    Facilities = "Tự túc",
                    Clinical = "Bình thường",
                    Test = "Chưa",
                    Drugs = "Chưa",
                };
                btnCodeSick.Focus();
            };
            ucAction1.EditButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                ucAction1.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction1.DelButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Delete);
                var obj = toHospitallBindingSource.Current as Data.ToHospitall;
                if (obj != null)
                {
                    var fm = new frmDeleteToHospitall(obj);
                    if (fm.ShowDialog() == DialogResult.OK)
                    {
                        ucAction1.InvoiceState = InvoiceState.Empty;
                        this.CheckPermission(PermissionHow.Add);
                        ToHospitall = new Data.ToHospitall(work);
                    }
                }
            };
            ucAction1.PrintButtonClick += (s, e) =>
            {
                using (Reports.rptToHospitall rpt = new Reports.rptToHospitall(ToHospitall))
                {
                    using (Reports.ReportDevExpess fmReport = new Reports.ReportDevExpess(rpt))
                    {
                        fmReport.ShowDialog();
                    }
                }
            };
        }

        public Data.ToHospitall ToHospitall 
        {
            get
            {
                return toHospitallBindingSource.DataSource as Data.ToHospitall;
            }
            set
            {
                toHospitallBindingSource.DataSource = value as object ?? typeof(Data.ToHospitall);
                if (value != null)
                {
                    if (value.Id <= 0)
                    {
                        this.CheckPermission(PermissionHow.Add);
                    }
                    value.PropertyChanged += (s, e) =>
                    {
                        btnCodeSick.EditValue = ToHospitall.Sick != null ? ToHospitall.Sick.No : "";
                    };
                    value.OnPropertyChanged("");
                }
                ucAction1.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }
        public int ToHospitall_Id
        {
            set
            {
                this.CheckPermission(PermissionHow.Edit);
                ToHospitall = work.Query<Data.ToHospitall>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
