using System;
using System.Linq;
using DevExpress.Xpo;

namespace SMHospitall.Data
{

    public class User : Person
    {
        public User(Session session)
            : base(session)
        {

        }
        private string _PassWord;
        public string PassWord
        {
            get
            {
                return _PassWord;
            }
            set
            {
                value = value ?? "";
                if (!IsLoading && value.Count() < 20)
                    throw new Exception("Mật khẩu phải được mã hoá trước khi lưu");
                SetPropertyValue("PassWord", ref _PassWord, value);
            }
        }
        private string _PassNew;
        [NonPersistent]
        public string PassNew
        {
            get
            {
                return _PassNew;
            }
            set
            {
                _PassNew = value;
                PassWord = value.Hash();
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
        public string RepeatPass { set; get; }
        public static XPCollection Users;
        protected override bool SetPropertyValue<T>(string propertyName, ref T propertyValueHolder, T newValue)
        {
            if (!IsLoading && Id > 0 && Code == "Admin")
            {
                throw new Exception("Bạn không thể thay đổi thông tin nhân viên quản trị");
            }
            else if (!IsLoading && propertyName == "Code" && Users != null)
            {
                var c = newValue as string;
                if (Users.Cast<User>().FirstOrDefault(p=>p!=this && p.Code == c)!= null)
                {
                    throw new Exception("Đã có nhân viên sử dụng mã này");    
                }
            }
            return base.SetPropertyValue<T>(propertyName, ref propertyValueHolder, newValue);
        }
        private UserGroup _UserGroup;
        [Association("UserGroup-Users")]
        public UserGroup UserGroup
        {
            get
            {
                return _UserGroup;
            }
            set
            {
                SetPropertyValue("UserGroup", ref _UserGroup, value);
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            PassWord = "123456".Hash();
        }
    }

}