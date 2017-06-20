using System;
using DevExpress.Xpo;
using System.Globalization;

namespace SMHospitall.Data
{
    //Tỉnh - thành phố
    public class Provinces : XPObject
    {
        public Provinces(Session session)
            : base(session)
        {
        }
        private string _Code;
        public string Code
        {
            get
            {
                return (_Code??"").ToUpper().Trim();
            }
            set
            {
                SetPropertyValue("Code", ref _Code, value);
            }
        }
        private string _Name;
        public string Name
        {
            get
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_Name ?? "");
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }
        private string _Description;
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                SetPropertyValue("Description", ref _Description, value);
            }
        }
        [Association("Provinces-Prefecturess")]
        public XPCollection<Prefectures> Prefecturess
        {
            get
            {
                return GetCollection<Prefectures>("Prefecturess");
            }
        }
        [Association("Provinces-districts")]
        public XPCollection<district> districts
        {
            get
            {
                return GetCollection<district>("districts");
            }
        }
        [Association("Provinces-Medicalls")]
        public XPCollection<Medicall> Medicalls
        {
            get
            {
                return GetCollection<Medicall>("Medicalls");
            }
        }
        //Liên kết bệnh nhân
        [Association("Provinces-Sicks")]
        public XPCollection<Sick> Sicks
        {
            get
            {
                return GetCollection<Sick>("Sicks");
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        public override string ToString()
        {
            return Name;
        }
    }

}