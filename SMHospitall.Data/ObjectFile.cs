using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SMHospitall
{
    public class ObjectFile
    {
        readonly static string file = Application.StartupPath + "\\smhospital.key";
        static string _serialKey = null;
        public static string SerialKey
        {
            get
            {
                return _serialKey ?? (_serialKey = OpenFile().SerialKey ?? "");
            }
            set
            {
                var o = OpenFile();
                o.SerialKey = _serialKey = value;
                SaveFile(o);
            }
        }
        static string _connectionString;
        public static string ConnectionString
        {
            get
            {
                _connectionString = _connectionString ?? (_connectionString = OpenFile().ConnectionString ?? "");
                if (_connectionString.IsNullOrEmpty())
                    _connectionString = String.Format("XpoProvider=MSSqlServerCE;data source={0}\\data.smvn;password=", Application.StartupPath);
                return _connectionString;
            }
            set
            {
                var f = OpenFile();
                f.ConnectionString = _connectionString = value;
                SaveFile(f);
            }
        }

        static Obj OpenFile()
        {
            if (!File.Exists(file))
                return new Obj();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(Obj));
            using (StreamReader read = new StreamReader(file))
            {
                try
                {
                    return x.Deserialize(read) as Obj;
                }
                catch (Exception)
                {
                    return new Obj();
                }

            }
        }
        static void SaveFile(Obj f)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(Obj));
            using (StreamWriter write = new StreamWriter(file, false))
            {

                x.Serialize(write, f);
            }
        }
        public class Obj
        {
            public string SerialKey { get; set; }
            public string ConnectionString { get; set; }
        }
    }
}
