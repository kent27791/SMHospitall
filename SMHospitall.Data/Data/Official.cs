using System;
using DevExpress.Xpo;

namespace SMHospitall.Data
{

    public class Official : Person
    {
        //Công nhân viên chức
        public Official(Session session)
            : base(session)
        {
        }
        private OfficialGroup _OfficialGroup;
        [Association("OfficialGroup-Officials")]
        public OfficialGroup OfficialGroup
        {
            get
            {
                return _OfficialGroup;
            }
            set
            {
                SetPropertyValue("OfficialGroup", ref _OfficialGroup, value);
            }
        }
        private Sciences _Sciences;
        [Association("Sciences-Officials")]
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
        private Medicall _Medicall;
        [Association("Medicall-Officials")]
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
        //Liên kết nghỉ ốm
        [Association("Official-OffWorks")]
        public XPCollection<OffWork> OffWorks
        {
            get
            {
                return GetCollection<OffWork>("OffWorks");
            }
        }
        //Liên kết chuyển viện
        [Association("Official-ToHospitalls")]
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