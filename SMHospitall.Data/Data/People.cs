using System;
using DevExpress.Xpo;
using System.Globalization;

namespace SMHospitall.Data
{
    //Dân tộc
    public class People : XPObject
    {
        public People(Session session)
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
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_Name??"");
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
        //Liên kết bệnh nhân
        [Association("People-Sicks")]
        public XPCollection<Sick> Sicks
        {
            get
            {
                return GetCollection<Sick>("Sicks");
            }
        }

        public override string ToString()
        {
            return Name;
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }

}