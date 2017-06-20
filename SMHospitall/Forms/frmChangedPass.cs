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
namespace SMHospitall.Forms
{
    public partial class frmChangedPass : SMHospitall.Forms.frmBase
    {
        public frmChangedPass()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (work.LoginUser == null)
                    throw new Exception("Bạn chưa đăng nhập chương trình");
                txtUserName.Text = work.LoginUser.Name;
            };
            btnOk.Click += (s, e) =>
            {
                if (txtOldPass.Text.Hash() != work.LoginUser.PassWord)
                    XtraMessageBox.Show("Mật khẩu cũ không đúng! Vui lòng nhập lại", "Thông báo");
                else if (txtNewPass.Text.Length < 6)
                    XtraMessageBox.Show("Mật khẩu mới phải lớn hơn 6 ký tự", "Thông báo");
                else if (txtNewPass.Text.Hash() != txtReNewPass.Text.Hash())
                    XtraMessageBox.Show("Mật khẩu mới và xác nhận lại mật khẩu mới không giống nhau", "Thông báo");
                else
                {
                    work.LoginUser.PassWord = txtNewPass.Text.Hash();
                    work.CommitChanges();
                    XtraMessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                    btnCance.PerformClick();
                }
            };
            btnCance.Click += (s, e) =>
            {
                Close();
            };
        }
    }
}
