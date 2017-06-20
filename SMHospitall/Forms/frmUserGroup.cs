using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.Xpo;
using SMHospitall.Ctr;

namespace SMHospitall.Forms
{
    public partial class frmUserGroup : SMHospitall.Forms.frmBase
    {
        public event SaveHandler OnSaved = t => { };
        public frmUserGroup()
        {
            InitializeComponent();
            ucAction1.InvoiceStateChanged += (s, e) =>
            {
                layoutControl1.Enabled = ucAction1.InvoiceState == InvoiceState.InvoiceEditing;
            };
            Load += (s, e) =>
            {
                if (UserGroups == null)
                    UserGroups = new Data.UserGroup(work);
            };
            ucAction1.SaveButtonClick += (s, e) =>
            {
                work.CommitChanges();
                ucAction1.InvoiceState = InvoiceState.InvoiceSaved;
                OnSaved(UserGroups);
            };
            ucAction1.NewButtonClick += (s, e) =>
            {
                UserGroups = new Data.UserGroup(work);
                ucAction1.InvoiceState = InvoiceState.InvoiceEditing;
            };
            ucAction1.EditButtonClick += (s, e) =>
            {
                ucAction1.InvoiceState = InvoiceState.InvoiceEditing;
            };
        }
        public Data.UserGroup UserGroups
        {
            get
            {
                return userGroupBindingSource.DataSource as Data.UserGroup;
            }
            set
            {
                ucPermission.UserGroup = value;
                userGroupBindingSource.DataSource = value as object ?? typeof(Data.UserGroup);
                ucAction1.InvoiceState = value == null ? InvoiceState.Empty : value.work.TrackingChanges ? InvoiceState.InvoiceEditing : InvoiceState.InvoiceSaved;
            }
        }

        public int UserGroup_Id 
        {
            get
            {
                return UserGroups != null ? UserGroups.Id : 0;
            }
            set
            {
                UserGroups = work.Query<Data.UserGroup>().FirstOrDefault(p => p.Id == value);
            }
        }
    }
}
