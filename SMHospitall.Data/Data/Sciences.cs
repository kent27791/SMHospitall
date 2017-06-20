using System;
using DevExpress.Xpo;
using System.Globalization;

namespace SMHospitall.Data
{
    //Khoa phòng
    public class Sciences : XPObject
    {
        public Sciences(Session session)
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
        private Medicall _Medicall;
        [Association("Medicall-Sciencess")]
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
        //Liên kết công nhân viên chức
        [Association("Sciences-Officials")]
        public XPCollection<Official> Officials
        {
            get
            {
                return GetCollection<Official>("Officials");
            }
        }
        //Liên kết nghỉ ốm
        [Association("Sciences-OffWorks")]
        public XPCollection<OffWork> OffWorks
        {
            get
            {
                return GetCollection<OffWork>("OffWorks");
            }
        }
        //Liên kết bệnh nhân
        [Association("Sciences-Sicks")]
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