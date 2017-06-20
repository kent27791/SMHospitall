using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.ComponentModel;
namespace SMHospitall
{
    public static class DataWork
    {
        public static string Hash(this string str)
        {
            Byte[] bytes = ASCIIEncoding.Default.GetBytes(str);
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                var endCode = md5.ComputeHash(bytes);
                return BitConverter.ToString(endCode);
            }
        }
        public static Image ToImage(this byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            using (MemoryStream m = new MemoryStream(bytes))
            {
                return new Bitmap(m);
            }
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static string Description(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();

        }
        public static string IntID(this string str)
        {
            str = str.Trim();
            if (string.IsNullOrEmpty(str) || str.Length > 15)
                return "";
            var sodautien = 0;
            var sothunhat = "";
            var sothuhai = str;
            while (!int.TryParse("0" + sothuhai, out sodautien))
            {
                sothuhai = sothuhai.Substring(1);
                sothunhat = str.Substring(0, str.Length - sothuhai.Length);
            }
            sodautien++;
            return sothunhat + (sodautien.ToString().Length > sothuhai.Length ? sodautien.ToString() : "0000000".Substring(0, sothuhai.Length - sodautien.ToString().Length) + sodautien);
        }
        public static void ForEach<T>(this IEnumerable<T> ts, Action<T> action)
        {
            ts.ToList().ForEach(action);
        }
        public static DateTime OnlyDate(this DateTime datetime)
        {
            return datetime.AddTicks(0 - datetime.TimeOfDay.Ticks);
        }
    }
}
