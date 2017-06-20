using System;
using DevExpress.Xpo;
using System.Linq;
namespace SMHospitall.Data
{
    //Nghỉ ốm
    public class OffWork : XPObject,OffWorkInterface
    {
        public OffWork(Session session)
            : base(session) { }
        public OffWork(Session session,Data.OffworkHospitall type)
            : base(session)
        {
            Sick = new Sick(work, type == Data.OffworkHospitall.Offwork ? Data.SickType.Offwork : Data.SickType.ToHospitall) { InActive = true };
            No = (work.Query<Data.OffWork>()
                                  .Where(p=>p.OffworkHospitall == type)
                                  .OrderBy(p => p.DateTime)
                                  .Select(p => p.No)
                                  .LastOrDefault() ?? "000000").IntID();
            while (work.Query<Data.OffWork>().Where(p=>p.OffworkHospitall==type).Any(p=>p.No==No))
            {
                No = No.IntID();
            }
        }
        //Chuyển viện hay nghỉ ốm
        private OffworkHospitall _OffworkHospitall;
        public OffworkHospitall OffworkHospitall
        {
            get
            {
                return _OffworkHospitall;
            }
            set
            {
                SetPropertyValue("OffworkHospitall", ref _OffworkHospitall, value);
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
        private string _Quyen;
        public string Quyen
        {
            get
            {
                return _Quyen;
            }
            set
            {
                SetPropertyValue("Quyen", ref _Quyen, value);
            }
        }
        private  string _So;
        public  string So
        {
            get
            {
                return _So;
            }
            set
            {
                SetPropertyValue("So", ref _So, value);
            }
        }
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
        //Liên kết bệnh nhân
        private Sick _Sick;
        [Association("Sick-OffWorks")]
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
        //Liên kết công ty
        private Company _Company;
        [Association("Company-OffWorks")]
        public Company Company
        {
            get
            {
                return _Company;
            }
            set
            {
                SetPropertyValue("Company", ref _Company, value);
            }
        }
        //Liên kết quyển số
        private Notebook _Notebook;
        [Association("Notebook-OffWorks")]
        public Notebook Notebook
        {
            get
            {
                return _Notebook;
            }
            set
            {
                SetPropertyValue("Notebook", ref _Notebook, value);
            }
        }
        //Liên kết khoa phòng
        private Sciences _Sciences;
        [Association("Sciences-OffWorks")]
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
        //Liên kết bác sỹ(công nhân viên chức)
        private Official _Official;
        [Association("Official-OffWorks")]
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
        public int number
        {
            get
            {
                TimeSpan t = TimeTo - TimeFrom;
                int num = t.Days;
                return num;
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            DateTime = DateTime.Now;
            TimeFrom = DateTime.Now;
            TimeTo = DateTime.Now.AddDays(5);
            Quyen = DateTime.Now.ToString("MM/yyyy");
            var old = work.Query<Data.OffWork>().OrderBy(p=>p.DateTime).LastOrDefault(p => p.Quyen == Quyen);
            if (old == null)
                So = "0001";
            else
                So = old.So.IntID();

        }

    }

}