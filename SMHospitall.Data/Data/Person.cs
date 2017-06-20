using System;
using System.Globalization;
using DevExpress.Xpo;
using System.ComponentModel;
using SMHospitall;
namespace SMHospitall.Data
{

    public class Person : XPObject
    {
        public Person(Session session)
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
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_Name??"");
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }
        //public int Sex { get; set; }
        //public string sSex
        //{
        //    get { return Sex == 1 ? "Nam" : "Nữ"; }
        //    set
        //    {
        //        if (value == "Nam")
        //            Sex = 1;
        //        else
        //            Sex = 0;
        //    }

        //}
        private GioiTinh _Sex;
        public GioiTinh Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                SetPropertyValue("Sex", ref _Sex, value);
            }
        }
        public string sex_string
        {
            get
            {
                return Sex.Description();
            }
        }
        public enum GioiTinh
        {
            [Description("Nam")]
            Nam=0,
            [Description("Nữ")]
            Nữ=1,
        }
        private DateTime _AddDate;
        public DateTime AddDate
        {
            get
            {
                return _AddDate;
            }
            set
            {
                SetPropertyValue("AddDate", ref _AddDate, value);
            }
        }
        private DateTime _BirthDay;
        public DateTime BirthDay
        {
            get
            {
                return _BirthDay;
            }
            set
            {
                SetPropertyValue("BirthDay", ref _BirthDay, value);
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
        private string _Address;
        public string Address
        {
            get
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_Address ?? "");
            }
            set
            {
                SetPropertyValue("Address", ref _Address, value);
            }
        }
        private string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetPropertyValue("Email", ref _Email, value);
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            AddDate = DateTime.Now;
            BirthDay = new DateTime(1920, 01, 01);
        }
        public override string ToString()
        {
            return Name;
        }
    }

}