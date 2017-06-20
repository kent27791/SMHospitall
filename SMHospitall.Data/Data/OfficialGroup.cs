using System;
using DevExpress.Xpo;
using System.Globalization;

namespace SMHospitall.Data
{
    //Nhóm công nhân viên chức
    public class OfficialGroup : XPObject
    {
        public OfficialGroup(Session session)
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
        [Association("Medicall-OfficialGroups")]
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
        [Association("OfficialGroup-Officials")]
        public XPCollection<Official> Officials
        {
            get
            {
                return GetCollection<Official>("Officials");
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