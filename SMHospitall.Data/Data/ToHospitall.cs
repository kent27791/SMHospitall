using System;
using DevExpress.Xpo;
using System.Linq;
namespace SMHospitall.Data
{
    // Chuyen Vien
    public class ToHospitall : XPObject
    {
        public ToHospitall(Session session)
            : base(session)
        {
            No = (work.Query<Data.ToHospitall>()
                                  .OrderBy(p => p.DateTime)
                                  .Select(p => p.No)
                                  .LastOrDefault() ?? "000000").IntID();
            while (work.Query<Data.ToHospitall>().Any(p => p.No == No))
            {
                No = No.IntID();
            }
        }
        //So luu tru
        private string _No;
        public string No
        {
            get
            {
                return _No;
            }
            set
            {
                SetPropertyValue("No", ref _No, value);
            }
        }
        //Ngay
        private DateTime _DateTime;
        public DateTime DateTime
        {
            get
            {
                return _DateTime;
            }
            set
            {
                SetPropertyValue("DateTime", ref _DateTime, value);
            }
        }
        //Tu ngay
        private DateTime _TimeFrom;
        public DateTime TimeFrom
        {
            get
            {
                return _TimeFrom;
            }
            set
            {
                SetPropertyValue("TimeFrom", ref _TimeFrom, value);
            }
        }
        //Den ngay
        private DateTime _TimeTo;
        public DateTime TimeTo
        {
            get
            {
                return _TimeTo;
            }
            set
            {
                SetPropertyValue("TimeTo", ref _TimeTo, value);
            }
        }
        //Lien ket benh nhan
        private Sick _Sick;
        [Association("Sick-ToHospitalls")]
        public Sick Sick
        {
            get
            {
                return _Sick;
            }
            set
            {
                SetPropertyValue("Sick", ref _Sick, value);
            }
        }
        //Lien ket nhan vien - bac sy
        private Official _Official;
        [Association("Official-ToHospitalls")]
        public Official Official
        {
            get
            {
                return _Official;
            }
            set
            {
                SetPropertyValue("Official", ref _Official, value);
            }
        }
        //Chan doan
        private string _Diagnosis;
        public string Diagnosis
        {
            get
            {
                return _Diagnosis;
            }
            set
            {
                SetPropertyValue("Diagnosis", ref _Diagnosis, value);
            }
        }
        //Ly do chuyen
        private string _Reason;
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                SetPropertyValue("Reason", ref _Reason, value);
            }
        }
        //Tinh trang
        private string _Status;
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                SetPropertyValue("Status", ref _Status, value);
            }
        }
        //Chuyen vien luc
        private DateTime _DateTimeNow;
        public DateTime DateTimeNow
        {
            get
            {
                return _DateTimeNow;
            }
            set
            {
                SetPropertyValue("DateTimeNow", ref _DateTimeNow, value);
            }
        }
        //Phuong tien
        private string _Facilities;
        public string Facilities
        {
            get
            {
                return _Facilities;
            }
            set
            {
                SetPropertyValue("Facilities", ref _Facilities, value);
            }
        }
        //Nguoi nha
        private string _NamHouse;
        public string NamHouse
        {
            get
            {
                return _NamHouse;
            }
            set
            {
                SetPropertyValue("NamHouse", ref _NamHouse, value);
            }
        }
        //Lien ket benh vien
        private Medicall _Medicall;
        [Association("Medicall-ToHospitalls")]
        public Medicall Medicall
        {
            get
            {
                return _Medicall;
            }
            set
            {
                SetPropertyValue("Medicall", ref _Medicall, value);
            }
        }
        //Dau hieu lam sang
        private string _Clinical;
        public string Clinical
        {
            get
            {
                return _Clinical;
            }
            set
            {
                SetPropertyValue("Clinical", ref _Clinical, value);
            }
        }
        //Các xét nghiệm
        private string _Test;
        public string Test
        {
            get
            {
                return _Test;
            }
            set
            {
                SetPropertyValue("Test", ref _Test, value);
            }
        }
        //Thuoc da dung
        private string _Drugs;
        public string Drugs
        {
            get
            {
                return _Drugs;
            }
            set
            {
                SetPropertyValue("Drugs", ref _Drugs, value);
            }
        }
        //Dat nuoc viet nam
        private string _VietNammese;
        public string VietNammese
        {
            get
            {
                return _VietNammese;
            }
            set
            {
                SetPropertyValue("VietNammese", ref _VietNammese, value);
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            DateTimeNow = DateTime.Now;
            DateTime = DateTime.Now;
            TimeFrom = DateTime.Now;
            TimeTo = DateTime.Now;
            //Sick.Country = "Việt Nam";
        }
    }

}