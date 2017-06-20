using System;
using DevExpress.Xpo;

namespace SMHospitall.Data
{
    //Bệnh viện
    public class Medicall : XPObject
    {
        public Medicall(Session session)
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
                return (_Name??"").ToUpper().Trim();
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }
        private string _Address;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                SetPropertyValue("Address", ref _Address, value);
            }
        }
        private string _Phone;
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                SetPropertyValue("Phone", ref _Phone, value);
            }
        }
        private string _Fax;
        public string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                SetPropertyValue("Fax", ref _Fax, value);
            }
        }
        private Provinces _Provinces;
        [Association("Provinces-Medicalls")]
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
        [Association("Medicall-Sciencess")]
        public XPCollection<Sciences> Sciencess
        {
            get
            {
                return GetCollection<Sciences>("Sciencess");
            }
        }
        [Association("Medicall-OfficialGroups")]
        public XPCollection<OfficialGroup> OfficialGroups
        {
            get
            {
                return GetCollection<OfficialGroup>("OfficialGroups");
            }
        }
        [Association("Medicall-Officials")]
        public XPCollection<Official> Officials
        {
            get
            {
                return GetCollection<Official>("Officials");
            }
        }
        ////Liên kết bệnh nhân
        //[Association("Medicall-Sicks")]
        //public XPCollection<Sick> Sicks
        //{
        //    get
        //    {
        //        return GetCollection<Sick>("Sicks");
        //    }
        //}
        //Lien ket chuyen vien
        [Association("Medicall-ToHospitalls")]
        public XPCollection<ToHospitall> ToHospitalls
        {
            get
            {
                return GetCollection<ToHospitall>("ToHospitalls");
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