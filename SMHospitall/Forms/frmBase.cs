using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using SMHospitall.Data;
namespace SMHospitall.Forms
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        public delegate void SaveHandler(Data.XPObject xpobject);
        public frmBase()
        {
            InitializeComponent();
            Owner = Program.frmMain;
            ShowInTaskbar = false;
            Load += (s, e) =>
            {
                if (MdiParent == null && Program.frmMain != null)
                {
                    Location = new Point(Program.frmMain.Location.X + (Program.frmMain.Width - Width) / 2,
                                        Program.frmMain.Location.Y + (Program.frmMain.Height - Height) / 2);
                }
            };
        }
        protected override void OnLoad(EventArgs e)
        {
            new MyWindowListener(Handle).btnClick += (a, b) =>
            {
                if (GetType()!=typeof(frmMain))
                {
                    Point screenPos = Cursor.Position;
                    Point clientPos = PointToClient(screenPos);
                    var control = GetControlAtPoint(this, clientPos);
                    if (control.GetType()!=typeof(GridControl) && control.GetType()!=typeof(GroupControl) && control.GetType()!=typeof(TextEdit))
                    {
                        Validate();
                    }
                }
            };
            try
            {
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                base.BeginInvoke(new MethodInvoker(Close));
                throw ex;
            }
        }

        static Control GetControlAtPoint(Control control, Point point)
        {
            var c = control.GetChildAtPoint(point);
            if (c!=null)
            {
                return GetControlAtPoint(c, point);
            }
            else
            {
                return control;
            }
        }
        private string _Pn;
        public string _PermissionName
        {
            get
            {
                return _Pn ?? Text;
            }
            set
            {
                _Pn = value;
            }
        }
        public PermissionHow _PermissionHow { set; get; }
        public string _PermissionAlias { set; get; }
    }
}