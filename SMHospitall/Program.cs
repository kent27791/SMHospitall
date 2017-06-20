using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SMHospitall.Forms;
using DevExpress.XtraEditors;
namespace SMHospitall
{
    static class Program
    {
        public static frmMain frmMain;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Cai dat tieng viet
            VietNammese.ActiveVN.Active();
            //Cai dat xong
            Application.ThreadException += (s, e) =>
            {
                XtraMessageBox.Show(String.Format("Lỗi: {0}\nNếu không biết này là lỗi gì thì\nVui lòng liên hệ phòng IT !...", e.Exception.Message), "Thông báo lỗi");
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
