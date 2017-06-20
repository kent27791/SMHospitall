using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.LookAndFeel;
namespace SMHospitall.VietNammese
{
    class ActiveVN
    {
        public static void Active()
        {
            DevExpress.UserSkins.OfficeSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Blue");
            //set number
            Format.Active();
            //set button
            Localizer.Active = new VietNammese.Localizer();
            PreviewLocalizer.Active = new VietNammese.PreviewLocalizer();
        }
    }
}
