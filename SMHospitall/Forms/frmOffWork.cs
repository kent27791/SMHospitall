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
    public partial class frmOffWork : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmOffWork()
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
                if (OffWork == null)
                {
                    this.CheckPermission(PermissionHow.Add);
                    OffWork = new Data.OffWork(work,Data.OffworkHospitall.Offwork);
                }
            };
            codeEditButton.ButtonClick += (s, e) =>
            {
                using (var fm = new frmSearchObject() { Sicks = work.Query<Data.Sick>().Where(p => !p.InActive).Cast<Data.Sick>().ToList() })
                {
                    if (fm.ShowDialog()==DialogResult.OK)
                    {
                        OffWork.Sick = fm.Sick as Data.Sick;
                    }
                }
            };
            codeEditButton.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && codeEditButton.Text.IsNullOrEmpty())
                {
                    if (OffWork.Sick == null)
                        OffWork.Sick = new Data.Sick(work);
                    OffWork.Sick.No = codeEditButton.Text = OffWork.Sick.GetNewCode();
                }
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                if (codeEditButton.Text == null || codeEditButton.Text.IsNullOrEmpty())
                    throw new Exception("Chưa nhập mã bệnh nhân");
                if (OffWork.Sick.Name == null || OffWork.Sick.Name.IsNullOrEmpty())
                    throw new Exception("Chưa nhập tên bệnh nhân");
                if (OffWork.Reason == null || OffWork.Reason.IsNullOrEmpty())
                    throw new Exception("Chưa nhập lý do nghỉ hưởng BHXH");
                if (OffWork.Company == null || OffWork.Reason.IsNullOrEmpty())
                    throw new Exception("Chưa nhập địa chỉ công ty");
                if (OffWork.Official == null || OffWork.Official.Name.IsNullOrEmpty())
                    throw new Exception("Chưa nhập tên bác sỹ cho nghỉ");
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(OffWork);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Add);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
                OffWork = new Data.OffWork(work, Data.OffworkHospitall.Offwork);
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.DelButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Delete);
                var obj = offWorkBindingSource.Current as Data.OffWork;
                if (obj != null)
                {
                    var fm = new frmDelete(obj);
                    if (fm.ShowDialog()==DialogResult.OK)
                    {
                        ucAction.InvoiceState = InvoiceState.Empty;
                        this.CheckPermission(PermissionHow.Add);
                        OffWork = new Data.OffWork(work, Data.OffworkHospitall.Offwork);
                    }
                }
            };
            ucAction.PrintButtonClick += (s, e) =>
            {
                using (Reports.rptOffWork rpt = new Reports.rptOffWork(OffWork))
                {
                    using (Reports.ReportDevExpess fmReport = new Reports.ReportDevExpess(rpt))
                    {
                        fmReport.ShowDialog();
                    }
                }
            };
            companyLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind== DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmCompany();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        CompanyXPCollection.Reload();
                        OffWork.Company = work.Query<Data.Company>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            sciencesLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmScience();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        SciencesxpCollection.Reload();
                        OffWork.Sciences = work.Query<Data.Sciences>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
            officialLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmOfficial();
                    fm.Owner = this;
                    fm.OnSaved += t =>
                    {
                        OfficialxpCollection.Reload();
                        OffWork.Official = work.Query<Data.Official>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.ShowDialog();
                }
            };
        }

        public Data.OffWork OffWork 
        {
            get
            {
                return offWorkBindingSource.DataSource as Data.OffWork;
            }
            set
            {
                offWorkBindingSource.DataSource = value as object ?? typeof(Data.OffWork);
                if (value != null)
                {
                    if (value.Id <= 0)
                    {
                        this.CheckPermission(PermissionHow.Add);
                    }
                    value.PropertyChanged += (s, e) =>
                    {
                        codeEditButton.EditValue=OffWork.Sick != null ? OffWork.Sick.No:"";
                    };
                    value.OnPropertyChanged("");
                }
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int OffWork_Id 
        {
            set
            {
                this.CheckPermission(PermissionHow.Edit);
                OffWork = work.Query<Data.OffWork>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
