using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace SMHospitall
{
    public class MyWindowListener:NativeWindow
    {
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand,Name="FullTrust")]
        public MyWindowListener(System.IntPtr handler)
        {
            this.AssignHandle(handler);
        }
        public event EventHandler btnClick;
    }
}
