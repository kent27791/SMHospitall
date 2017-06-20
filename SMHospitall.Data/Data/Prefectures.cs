using System;
using DevExpress.Xpo;
using System.Globalization;

namespace SMHospitall.Data
{
    //Quận - huyện
    public class Prefectures : XPObject
    {
        public Prefectures(Session session)
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
        private Provinces _Provinces;
        [Association("Provinces-Prefecturess")]
        public Provinces Provinces
        {
            get
            {
                return _Provinces;
            }
            set
            {
                SetPropertyValue("Provinces", ref _Provinces, value);
            }
        }
        [Association("Prefectures-districts")]
        public XPCollection<district> districts
        {
            get
            {
                return GetCollection<district>("districts");
            }
        }
        //Liên kết bệnh nhân
        [Association("Prefectures-Sicks")]
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