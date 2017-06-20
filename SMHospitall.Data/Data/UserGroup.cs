using System;
using System.Linq;
using DevExpress.Xpo;
using System.Globalization;

namespace SMHospitall.Data
{

    public class UserGroup : XPObject
    {

        public UserGroup(Session session)
            : base(session)
        {
        }
        private string _Code;
        public string Code
        {
            get
            {
                return _Code;
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
        [Association("UserGroup-Users")]
        public XPCollection<User> Users
        {
            get
            {
                return GetCollection<User>("Users");
            }
        }
        [Association("UserGroup-PermissionSets")]
        public XPCollection<PermissionSet> PermissionSets
        {
            get
            {
                return GetCollection<PermissionSet>("PermissionSets");
            }
        }
        public override string ToString()
        {
            return Name;
        }
        protected override bool SetPropertyValue<T>(string propertyName, ref T propertyValueHolder, T newValue)
        {
            if (!IsLoading && Id>0 && Code=="Administrator")
            {
                throw new Exception("Bạn không thể thay đổi thông tin nhóm quản trị");
            }
            return base.SetPropertyValue<T>(propertyName, ref propertyValueHolder, newValue);
        }
        public override void Delete()
        {
            if (Users.Any())
            {
                throw new Exception(String.Format("Tồn tại nhân viên trong nhóm này\nBao gồm:('{0}')",Users.Select(p=>p.Code).Aggregate((a,b)=>String.Format("{0};{1}",a,b))));
            }
            PermissionSets.ToList().ForEach(p => p.Delete());
            base.Delete();
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }

}