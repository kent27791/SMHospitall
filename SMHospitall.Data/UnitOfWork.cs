using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.Data;

namespace SMHospitall
{
    public partial class UnitOfWork : DevExpress.Xpo.UnitOfWork
    {
        public static readonly string Ext = "SMHospitall File|*.smvn";
        public static int LoginUser_Id { set; get; }
        public Data.User LoginUser
        {
            get
            {
                return this.Query<Data.User>().FirstOrDefault(p => p.Id == LoginUser_Id);
            }
        }
        public static string ConnectString
        {
            //get
            //{
            //    return Properties.Settings.Default.ConnectionString;
            //}
            //set
            //{
            //    Properties.Settings.Default.ConnectionString = value;
            //}
            get
            {
                return ObjectFile.ConnectionString;
            }
            set
            {
                ObjectFile.ConnectionString = value;
                XpoDefault.ConnectionString = value;
            }
        }
        public event EventHandler TrackingChanged = (s, e) => { };
        public UnitOfWork()
        {
            try
            {
                ConnectionString = ConnectString;
                ObjectSaved += (s, e) =>
                {
                    TrackingChanged(this, new EventArgs());
                };
                AfterBeginTrackingChanges += (s, e) =>
                {
                    TrackingChanged(this, new EventArgs());
                };
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
