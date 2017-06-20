using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Controls;
namespace SMHospitall.VietNammese
{
    class Localizer :DevExpress.XtraEditors.Controls.Localizer
    {
        public override string Language
        {
            get
            {
                return "VietNammese";
            }
        }
        public override string GetLocalizedString(StringId id)
        {
            string ret = "";
            switch (id)
            {
                case StringId.LookUpEditValueIsNull:
                    ret = "";
                    break;
                case StringId.Apply:
                    ret = "Áp dụng";
                    break;
                case StringId.OK:
                    ret = "Đồng ý";
                    break;
                case StringId.XtraMessageBoxOkButtonText:
                    ret = "Đồng ý";
                    break;
                case StringId.XtraMessageBoxCancelButtonText:
                    ret = "Hủy";
                    break;
                case StringId.XtraMessageBoxIgnoreButtonText:
                    ret = "Bỏ qua";
                    break;
                case StringId.XtraMessageBoxNoButtonText:
                    ret = "Không";
                    break;
                case StringId.XtraMessageBoxRetryButtonText:
                    ret = "Thử lại";
                    break;
                case StringId.XtraMessageBoxYesButtonText:
                    ret = "Đồng ý";
                    break;
                default:
                    ret = base.GetLocalizedString(id);
                    break;
            }
            return ret;
        }
    }
}
