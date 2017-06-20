using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.Data;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
using Microsoft.Data.ConnectionUI;
namespace SMHospitall.Forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        UnitOfWork work;
        void CreateData()
        {
            UnitOfWork.ConnectString = btnParth.Text;
            work = new UnitOfWork();
            if (work.Query<Data.EndUser>().Any())
                XtraMessageBox.Show("Không thể ghi đè lên dữ liệu cũ");
            else
            {
                work.UpdateSchema();
                new Data.EndUser(work)
                {
                    Code = "Mã",
                    Name = "Bệnh Viện Đa Khoa Huyện Cư Kuin",
                    Address = "Địa chỉ",
                    Phone = "Điện thoại",
                    Fax = " Fax"
                };
                work.CommitChanges();
                work.GetPermissionWork();
                var g = new Data.UserGroup(work)
                {
                    Code = "Administrators",
                    Name = "Nhóm quản trị hệ thống",
                };
                work.Query<Data.Permisson>().ToList()
                    .ForEach(p =>
                    {
                        g.PermissionSets.Add(new Data.PermissionSet(work)
                        {
                            UserGroup = g,
                            Permisson = p,
                            PermissionHow = PermissionHow.Full,
                        });
                    });
                var u = new Data.User(work)
                {
                    UserGroup = g,
                    Code = "Admin",
                    Name = "Quản trị viên",

                };
                work.CommitChanges();
                UnitOfWork.LoginUser_Id = u.Id;
                using (frmEndUser fmEndUser = new frmEndUser() { Owner = this })
                {
                    fmEndUser.ShowDialog();
                }
                UnitOfWork.LoginUser_Id = 0;
                XtraMessageBox.Show("Khởi tạo dữ liệu thành công", "Thông báo");
            }
        }
        public frmLogin()
        {
            InitializeComponent();
            Owner = Program.frmMain;
            btnCreater.LinkClicked += (s, e) =>
            {
                //using (frmNewData newdata = new frmNewData())
                //{
                //    Visible = false;
                //    newdata.Owner = Program.frmMain;
                //    newdata.ShowDialog();
                //    btnParth.Text = UnitOfWork.ConnectString;
                //    work = new UnitOfWork();
                //    Visible = true;
                //}
                if (radioGroup2.EditValue as bool? == null)
                {
                    using (SaveFileDialog openfiledialog = new SaveFileDialog() { Filter = UnitOfWork.Ext, FileName = "Data", Title = "Chọn nơi lưu dữ liệu", })
                    {
                        if (openfiledialog.ShowDialog() == DialogResult.OK)
                        {
                            btnParth.Text = MSSqlCEConnectionProvider.GetConnectionString(openfiledialog.FileName);
                            CreateData();
                        }
                    }
                }
                else
                {
                    DataConnectionDialog dlg = new DataConnectionDialog();
                    DataSource.AddStandardDataSources(dlg);
                    dlg.SelectedDataSource = DataSource.SqlDataSource;
                    dlg.SelectedDataProvider = DataProvider.SqlDataProvider;

                    if (DataConnectionDialog.Show(dlg) == DialogResult.OK)
                    {
                        btnParth.Text = dlg.ConnectionString;
                        CreateData();
                    }
                }
            };
            btnOk.Click += (s, e) =>
            {
                //Cursor = Cursors.WaitCursor;
                //if (btnParth.Text.IsNullOrEmpty())
                //{
                //    XtraMessageBox.Show("Chưa chọn nơi lưu trữ dữ liệu", "Thông báo");
                //}
                //else
                //{
                //    try
                //    {
                //        UnitOfWork.ConnectString = btnParth.Text;
                //        work = new UnitOfWork();
                //        string passHash = txtPassword.Text.Hash();
                //        var us = work.Query<Data.User>().FirstOrDefault(p => p.Code.ToUpper() == txtUserName.Text.ToUpper() && p.PassWord == passHash);
                //        if (us!=null)
                //        {
                //            UnitOfWork.LoginUser_Id = us.Id;
                //            if (checkSave.Checked)
                //            {
                //                Properties.Settings.Default.UserId = txtUserName.Text;
                //                Properties.Settings.Default.PassWork = txtPassword.Text;
                //            }
                //            else
                //            {
                //                Properties.Settings.Default.UserId = "";
                //                Properties.Settings.Default.PassWork = "";
                //            }
                //            Properties.Settings.Default.Save();
                //            DialogResult = DialogResult.OK;
                //        }
                //        else
                //        {
                //            XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng","Thông báo");
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        XtraMessageBox.Show("Không thể kết nối đến cơ sở dữ liệu\nLỗi: " + ex.Message, "Thông báo");
                //    }
                //}
                //Cursor = Cursors.Default;
                Cursor = Cursors.WaitCursor;

                if (btnParth.Text.IsNullOrEmpty())
                {
                    XtraMessageBox.Show("Chưa có dữ liệu làm việc", "Thông báo lỗi!");
                }
                else try
                    {
                        UnitOfWork.ConnectString = btnParth.Text;
                        work = new UnitOfWork();
                        if (!work.Query<Data.EndUser>().Any())
                        {
                            XtraMessageBox.Show("Đây là lần đầu tiên bạn chạy chương trình");
                            CreateData();
                        }
                        string passE = txtPassword.Text.Hash();

                        var us = work.Query<Data.User>().FirstOrDefault(p => p.Code.ToUpper() == txtUserName.Text.ToUpper() && p.PassWord == passE);
                        if (us != null)
                        {
                            UnitOfWork.LoginUser_Id = us.Id;
                            if (checkSave.Checked)
                            {
                                Properties.Settings.Default.UserId = txtUserName.Text;
                                Properties.Settings.Default.PassWork = txtPassword.Text;

                            }
                            else
                            {
                                Properties.Settings.Default.UserId = "";
                                Properties.Settings.Default.PassWork = "";

                            }
                            Properties.Settings.Default.Save();
                            if (txtPassword.Text == "123456")
                                XtraMessageBox.Show("Nếu muốn bảo mật dữ liệu!\nVui lòng đổi lại mật khẩu", "Thông báo");
                            DialogResult = DialogResult.OK;
                        }
                        else
                            XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo lỗi");

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Không thể kết nối đến dữ liệu\nLỗi:" + ex.Message, "Thông báo lỗi");
                    }
                Cursor = Cursors.Default;
            };
            btnCance.Click += (s, e) =>
            {
                Close();
            };
            FormClosing += (s, e) =>
            {
                if (work==null||work.LoginUser==null)
                {
                    e.Cancel = (XtraMessageBox.Show("Bạn chắc chắn thoát khỏi chương trình", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No);
                    if (!e.Cancel)
                    {
                        Environment.Exit(1);
                    }
                }
            };
            Load += (s, e) =>
            {
                if (btnParth.Text.Contains("smvn")) 
                {
                    radioGroup2.SelectedIndex = 0;
                }
                else if (btnParth.Text.Contains("Init catalog"))
                {
                    radioGroup2.SelectedIndex = 1;
                }
                txtUserName.Text = Properties.Settings.Default.UserId;
                txtPassword.Text = Properties.Settings.Default.PassWork;
                if (txtUserName.Text == "" && txtPassword.Text == "")
                {
                    checkSave.Checked = false;
                }
                else
                {
                    checkSave.Checked = true;
                }
                btnParth.Text = UnitOfWork.ConnectString;
            };
            btnParth.ButtonClick += (s, e) =>
            {
                if (radioGroup2.EditValue as bool ? == null)
                {
                    using (OpenFileDialog open = new OpenFileDialog() { Filter = UnitOfWork.Ext })
                    {
                        if (open.ShowDialog()==DialogResult.OK)
                        {
                            btnParth.Text = MSSqlCEConnectionProvider.GetConnectionString(open.FileName);
                        }
                    }

                }
                else if (radioGroup2.EditValue as bool ? == false)
                {
                    DataConnectionDialog dlg = new DataConnectionDialog();
                    DataSource.AddStandardDataSources(dlg);
                    dlg.SelectedDataSource = DataSource.SqlDataSource;
                    dlg.SelectedDataProvider = DataProvider.SqlDataProvider;
                    if (DataConnectionDialog.Show(dlg)==DialogResult.OK)
                    {
                        btnParth.Text = dlg.ConnectionString;
                    }
                }
            };
        }
    }
}