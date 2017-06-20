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
using SMHospitall.Reports;
namespace SMHospitall
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                using (Forms.frmLogin Login = new Forms.frmLogin())
                {
                    Login.ShowDialog();
                    work = new UnitOfWork();
                }
            };
            barManager.ItemClick += (s, e) =>
            {
                if (e.Item == btnLogin)
                {
                    using (Forms.frmLogin fm = new Forms.frmLogin())
                    {
                        fm.ShowDialog();
                        work = new UnitOfWork();
                    }
                }
                else if (e.Item == btnToHospitall)
                    OpenForm<Forms.frmToHospitalls>(false);
                else if (e.Item == btnInforHospitall)
                    OpenForm<Forms.frmEndUser>(false);
                else if (e.Item == btnChangedPass)
                    OpenForm<Forms.frmChangedPass>(false);
                else if (e.Item == btnUserGroups)
                    OpenForm<Forms.frmUserGroups>();
                else if (e.Item == btnUsers)
                    OpenForm<Forms.frmUsers>();
                else if (e.Item == btnProvince)
                    OpenForm<Forms.frmProvinces>();
                else if (e.Item == btnPrefecture)
                    OpenForm<Forms.frmPrefectures>();
                else if (e.Item == btnDistrict)
                    OpenForm<Forms.frmDistricts>();
                else if (e.Item == btnPeople)
                    OpenForm<Forms.frmPeoples>();
                else if (e.Item == btnProfession)
                    OpenForm<Forms.frmProfession>();
                else if (e.Item == btnMedicall)
                    OpenForm<Forms.frmMedicalls>();
                else if (e.Item == btnSciences)
                    OpenForm<Forms.frmSciences>();
                else if (e.Item == btnOfficialGroup)
                    OpenForm<Forms.frmOfficialGroups>();
                else if (e.Item == btnOfficial)
                    OpenForm<Forms.frmOfficials>();
                else if (e.Item == btnCompany)
                    OpenForm<Forms.frmCompanys>();
                else if (e.Item == btnNotebook)
                    OpenForm<Forms.frmNotebooks>();
                else if (e.Item == btnSick)
                    OpenForm<Forms.frmSicks>();
                else if (e.Item == btnSickHospitall)
                    OpenForm<Forms.frmSickToHospitalls>();
                else if (e.Item == btnOffWork)
                    OpenForm<Forms.frmOffWork>(false);
                else if (e.Item == btnListOffWork)
                    OpenForm<Forms.frmOffWOrks>();
                else if (e.Item == btnListToHospitall)
                    OpenForm<Forms.frmToHospitallss>();
                else if (e.Item == btnReportSicks)
                    OpenForm<Reports.ReportSicks>();
                else if (e.Item == btnReportSickByDoctor)
                    OpenForm<Reports.ReportSickByDoctors>(); 
                else if (e.Item == btnReportSickBySic)
                    OpenForm<Reports.ReportSickBySicks>();
                else if (e.Item == btnListReportToHospitall)
                    OpenForm<Reports.ReportToHospitall>();
                else if (e.Item == btnReportToHospitalByDoctor)
                    OpenForm<Reports.ReportToHospitalByDoctor>();
                else if (e.Item == btnReportToHospitalBySick)
                    OpenForm<Reports.ReportToHospitalBySick>();
            };
            navBarControl.LinkClicked += (s, e) =>
            {
                var item = e.Link.Item;
                if (item == navBarItemOffWork)
                    OpenForm<Forms.frmOffWork>(false);
                else if (item == navBarItemOffWorkList)
                    OpenForm<Forms.frmOffWOrks>();
                else if (item == navBarItemToMedical)
                    OpenForm<Forms.frmToHospitalls>(false);
                else if (item == navBarItemToMedicalList)
                    OpenForm<Forms.frmToHospitallss>();
            };
            FormClosing += (s, e) =>
            {
                var xtr = XtraMessageBox.Show("Bạn muốn thoát khỏi chương trình không ?", "Thoát chương trình", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                switch (xtr)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            };
        }
        public UnitOfWork work { set; get; }
        void OpenForm<T>(bool? dg = null) where T : XtraForm, new()
        {
            if (work == null || work.LoginUser == null)
            {
                throw new Exception("Bạn chưa đăng nhập chương trình");
            }
            var fm = dg == null ? (MdiChildren.FirstOrDefault(p => p is T) ?? new T() { MdiParent = this })
                : (OwnedForms.FirstOrDefault(p => p is T) ?? new T() { Owner = this });
            if (dg == true)
                fm.ShowDialog();
            else
                fm.Show();
            fm.Focus();
        }
    }
}