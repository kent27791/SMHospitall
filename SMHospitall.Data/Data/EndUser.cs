using System;
using DevExpress.Xpo;
using System.Drawing;
namespace SMHospitall.Data
{

    public class EndUser : XPObject
    {
        public EndUser(Session session)
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
                return (_Name).ToUpper().Trim();
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }
        private string _NameFull;
        public string NameFull
        {
            get
            {
                return _NameFull;
            }
            set
            {
                SetPropertyValue("NameFull", ref _NameFull, value);
            }
        }
        private string _CongHoa;
        public string CongHoa
        {
            get
            {
                return _CongHoa;
            }
            set
            {
                SetPropertyValue("CongHoa", ref _CongHoa, value);
            }
        }
        private string _DocLap;
        public string DocLap
        {
            get
            {
                return _DocLap;
            }
            set
            {
                SetPropertyValue("DocLap", ref _DocLap, value);
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
        [Delayed]
        public Byte[] Logo
        {
            get
            {
                return GetDelayedPropertyValue<Byte[]>("Logo");
            }
            set
            {
                SetDelayedPropertyValue<Byte[]>("Logo",value);
            }
        }
        [NonPersistent]
        public Image LogoImage
        {
            get
            {
                return Logo.ToImage();
            }
        }
        [NonPersistent]
        public string AddressDC
        {
            get
            {
                return "ĐC: " + Address;
            }
        }
        [NonPersistent]
        public string PhoneDC
        {
            get
            {
                return "ĐT: " + Phone;
            }
        }
        private string _Directory;
        public string Directory
        {
            get
            {
                return _Directory;
            }
            set
            {
                SetPropertyValue("Directory", ref _Directory, value);
            }
        }
        private string _Manager;
        public string Manager
        {
            get
            {
                return _Manager;
            }
            set
            {
                SetPropertyValue("Manager", ref _Manager, value);
            }
        }
        public Image HeaderImage
        {
            get
            {
                return new UcHeader() { EndUser = this }.Image;
            }
        }
        //Ngày báo cáo
        [NonPersistent]
        public string DateTimeNow
        {
            get
            {
                return DateTime.Now.ToString("\\N\\gà\\y dd \\t\\há\\n\\g MM \\nă\\m yyyy");
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }

}