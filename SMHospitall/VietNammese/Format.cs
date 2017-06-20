using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using DevExpress.Utils.Drawing;
using System.Drawing;

namespace SMHospitall.VietNammese
{
    class Format
    {
        public static void Active()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            culture.NumberFormat.CurrencyGroupSeparator = " ";
            culture.NumberFormat.NumberGroupSeparator = " ";
            culture.NumberFormat.NumberDecimalSeparator = ".";
            culture.NumberFormat.CurrencyDecimalSeparator = ".";
            culture.NumberFormat.CurrencySymbol = "đ";
            Thread.CurrentThread.CurrentCulture = culture;
            BackgroundPaintHelper.DefaultDisabledColor = Color.FromArgb(0, Color.Wheat);
        }
    }
}
