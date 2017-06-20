using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Xpo.DB;
using System.Linq;
using DevExpress.Data;
using DevExpress.Xpo;
using Microsoft.Data.ConnectionUI;
namespace SMHospitall.Forms
{
    public partial class frmNewData : DevExpress.XtraEditors.XtraForm
    {
        UnitOfWork work;
        public frmNewData()
        {
            InitializeComponent();
            btnParth.ButtonClick += (s, e) =>
            {
                if (radioGroup2.EditValue as bool ?== null)
                {
                    using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = UnitOfWork.Ext })
                    {
                        if (saveFile.ShowDialog()==DialogResult.OK)
                        {
                            btnParth.Text = MSSqlCEConnectionProvider.GetConnectionString(saveFile.FileName);
                        }
                    }
                }
                else if (radioGroup2.EditValue as bool ?==false)
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
                else
                {
                    XtraMessageBox.Show("Hãy liên hệ số điện thoại: 0905 328.466 để được hướng dẫn");
                }
            };
            btnCreater.Click += (s, e) =>
            {
                UnitOfWork.ConnectString = btnParth.Text;
                work = new UnitOfWork();
                work.UpdateSchema();
                work.GetPermissionWork();
                new Data.EndUser(work)
                {
                    Code="Mã",
                    NameFull="Tên Chủ Quản",
                    Name="Tên Cơ Quan",
                    CongHoa="Cộng Hoà Xã Hội Chủ Nghĩa Việt Nam",
                    DocLap="Độc Lập - Tự Do - Hạnh Phúc",
                    Address="Địa Chỉ",
                    Phone="Điện Thoại",
                    Fax = "Fax"
                };
                work.CommitChanges();
                var g = new Data.UserGroup(work)
                {
                    Code="Administrator",
                    Name="Nhóm quản trị",
                };
                work.Query<Data.Permisson>().ToList().ForEach(p=>
                {
                    g.PermissionSets.Add(new Data.PermissionSet(work)
                    {
                        UserGroup=g,
                        Permisson=p,
                        PermissionHow=PermissionHow.Full
                    });
                });
                new Data.User(work)
                {
                    UserGroup=g,
                    Code="Admin",
                    Name="Quản trị",
                };
                work.CommitChanges();
                XtraMessageBox.Show("Đã tạo cơ sở dữ liệu thành công", "Thông báo");
                Close();
            };
            btnCance.Click += (s, e) => Close();
        }
    }
}