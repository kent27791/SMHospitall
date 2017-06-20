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
    public partial class frmUser : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmUser()
        {
            InitializeComponent();
            ucAction.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                if (User == null)
                    User = new Data.User(work);
            };
            ucAction.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(User);
            };
            ucAction.NewButtonClick += (s, e) =>
            {
                User = new Data.User(work);
                ucAction.InvoiceState = Ctr.InvoiceState.InvoiceEditing;
            };
            userGroupLookUpEdit.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind==DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                {
                    var fm = new frmUserGroup();
                    fm.OnSaved += t =>
                    {
                        fm.Show();
                        UserGroupXPCollection.Reload();
                        User.UserGroup = work.Query<Data.UserGroup>().FirstOrDefault(p => p.Id == t.Id);
                    };
                    fm.Owner = this;
                    fm.Show();
                }
            };
            ucAction.EditButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Edit);
                ucAction.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction.DelButtonClick += (s, e) =>
            {
                this.CheckPermission(PermissionHow.Delete);
                var obj = User;
                if (obj!=null)
                {
                    var xtr = XtraMessageBox.Show("Bạn chắc chắn xoá: " + obj, "Thông báo", MessageBoxButtons.OKCancel);
                    if (xtr==DialogResult.OK)
                    {
                        obj.Delete();
                        work.CommitChanges();
                        User = null;
                        ucAction.InvoiceState = InvoiceState.Empty;
                        OnSaved(User);
                    }
                }
            };
        }

        public Data.User User 
        {
            get
            {
                return userBindingSource.DataSource as Data.User;
            }
            set
            {
                userBindingSource.DataSource=value as object ?? typeof(Data.User);
                ucAction.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int User_Id 
        {
            get
            {
                return User != null ? User_Id : 0;
            }
            set
            {
                User = work.Query<Data.User>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
