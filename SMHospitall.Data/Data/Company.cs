using System;
using System.Globalization;
using DevExpress.Xpo;

namespace SMHospitall.Data
{
    //Công ty
    public class Company : XPObject
    {
        public Company(Session session)
            : base(session)
        {
        }
        private string _Code;
        public string Code
        {
            get
            {
                return (_Code ?? "").ToUpper().Trim();
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
        //Liên kết nghỉ ốm
        [Association("Company-OffWorks")]
        public XPCollection<OffWork> OffWorks
        {
            get
            {
                return GetCollection<OffWork>("OffWorks");
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