using System;
using DevExpress.Xpo;
using System.Linq;
using DevExpress.Data;
using DevExpress.XtraEditors;

using System.Globalization;
namespace SMHospitall.Data
{
    //Bệnh nhân
    public class Sick : Person
    {
        public Sick(UnitOfWork work, SickType type):base(work)
        {
            SickType = type;
        }
        public Sick(Session session)
            : base(session)
        {
            No = (work.Query<Data.Sick>()
                                  .Select(p => p.No)
                                  .LastOrDefault() ?? "000000").IntID();
            while (work.Query<Data.Sick>().Any(p=>p.No==No))
            {
                No = No.IntID();
            }
        }
        //bệnh nhân Chuyển viện hay nghỉ ốm
        private SickType _SickType;
        public SickType SickType
        {
        	get
        	{
        		return _SickType;
        	}
        	set
        	{
        	  SetPropertyValue("SickType", ref _SickType, value);
        	}
        }

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

        //Lien ket dan toc
        private People _People;
        [Association("People-Sicks")]
        public People People
        {
            get
            {
                return _People;
            }
            set
            {
                SetPropertyValue("People", ref _People, value);
            }
        }
        //Liên kết tỉnh
        private Provinces _Province;
        [Association("Provinces-Sicks")]
        public Provinces Province
        {
            get
            {
                return _Province;
            }
            set
            {
                SetPropertyValue("Province", ref _Province, value);
            }
        }
        //Liên kết quận - huyện
        private Prefectures _Prefectures;
        [Association("Prefectures-Sicks")]
        public Prefectures Prefectures
        {
            get
            {
                return _Prefectures;
            }
            set
            {
                SetPropertyValue("Prefectures", ref _Prefectures, value);
            }
        }
        //Liên kết xã - phường
        private district _District;
        [Association("district-Sicks")]
        public district district
        {
            get
            {
                return _District;
            }
            set
            {
                SetPropertyValue("district", ref _District, value);
            }
        }
        private string _Number;
        public string Number
        {
            get
            {
                return (_Number??"").ToUpper().Trim();
            }
            set
            {
                SetPropertyValue("Number", ref _Number, value);
            }
        }
        private DateTime _DateTimeFrom;
        public DateTime DateTimeFrom
        {
            get
            {
                return _DateTimeFrom;
            }
            set
            {
                SetPropertyValue("DateTimeFrom", ref _DateTimeFrom, value);
            }
        }
        private DateTime _DateTimeTo;
        public DateTime DateTimeTo
        {
            get
            {
                return _DateTimeTo;
            }
            set
            {
                SetPropertyValue("DateTimeTo", ref _DateTimeTo, value);
            }
        }
        ////Liên kết bệnh viện
        //private Medicall _Medicall;
        //[Association("Medicall-Sicks")]
        //public Medicall Medicall
        //{
        //    get
        //    {
        //        return _Medicall;
        //    }
        //    set
        //    {
        //        SetPropertyValue("Medicall", ref _Medicall, value);
        //    }
        //}
        //Liên kết nghỉ ốm
        [Association("Sick-OffWorks")]
        public XPCollection<OffWork> OffWorks
        {
            get
            {
                return GetCollection<OffWork>("OffWorks");
            }
        }
        private bool _InActive;
        public bool InActive
        {
            get
            {
                SetPropertyValue("InActive", ref _InActive, No.IsNullOrEmpty());
                return _InActive;
            }
            set
            {
                SetPropertyValue("InActive", ref _InActive, value);
            }
        }
        //Id tang tu dong trong nghi ốm
        public string GetNewCode()
        {
            var no = DateTime.Now.ToString("ddMMyyyy.000001");
            while (work.Query<Data.Sick>().Any(p=>p.No==no && p != this))
            {
                no = no.IntID();
            }
            return no;
        }
        //Lien ket chuyen vien
        [Association("Sick-ToHospitalls")]
        public XPCollection<ToHospitall> ToHospitalls
        {
            get
            {
                return GetCollection<ToHospitall>("ToHospitalls");
            }
        }
        //Lien ket khoa phong
        private Sciences _Sciences;
        [Association("Sciences-Sicks")]
        public Sciences Sciences
        {
            get
            {
                return _Sciences;
            }
            set
            {
                SetPropertyValue("Sciences", ref _Sciences, value);
            }
        }
        //Quoc tich
        private string _Country;
        public string Country
        {
            get
            {
                return _Country;
            }
            set
            {
                SetPropertyValue("Country", ref _Country, value);
            }
        }
        //lien ket nghe nghiep
        private Profession _Profession;
        [Association("Profession-Sicks")]
        public Profession Profession
        {
            get
            {
                return _Profession;
            }
            set
            {
                SetPropertyValue("Profession", ref _Profession, value);
            }
        }
        //Noi lam viec
        private string _Workplace;
        public string Workplace
        {
            get
            {
                return _Workplace;
            }
            set
            {
                SetPropertyValue("Workplace", ref _Workplace, value);
            }
        }
        public override void AfterConstruction()
        {
            DateTimeFrom = DateTime.Now;
            DateTimeTo = DateTime.Now.AddYears(1);
            base.AfterConstruction();
        }
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if (propertyName == "Name" && No.IsNullOrEmpty())
                No = GetNewCode();
        }
        public override void Delete()
        {
            if (OffWorks.Any())
                throw new Exception(String.Format("Bệnh nhân đã có trong danh sách nghỉ ốm\nDanh sách phiếu: ('{0}')", OffWorks.Select(p => p.No).Aggregate((a, b) => String.Format("{0};{1}", a, b))));
            base.Delete();
        }
    }

}