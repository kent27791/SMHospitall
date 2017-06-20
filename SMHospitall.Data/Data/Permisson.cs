using System;
using DevExpress.Xpo;

namespace SMHospitall.Data
{

    public class Permisson : XPObject
    {
        public Permisson(Session session)
            : base(session)
        {
        }
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }
        [Association("Permisson-Permissons")]
        public XPCollection<Permisson> Childrens
        {
            get
            {
                return GetCollection<Permisson>("Childrens");
            }
        }
        private Permisson _Parent;
        [Association("Permisson-Permissons")]
        public Permisson Parent
        {
            get
            {
                return _Parent;
            }
            set
            {
                SetPropertyValue("Parent", ref _Parent, value);
            }
        }
        private string _Alias;
        public string Alias
        {
            get
            {
                return _Alias;
            }
            set
            {
                SetPropertyValue("Alias", ref _Alias, value);
            }
        }
        private PermissionHow _PermissionHow;
        public PermissionHow PermissionHow
        {
            get
            {
                return _PermissionHow;
            }
            set
            {
                SetPropertyValue("PermissionHow", ref _PermissionHow, value);
                if (Parent != null)
                    Parent.PermissionHow |= PermissionHow;
            }
        }
        [Association("Permisson-PermissionSets")]
        public XPCollection<PermissionSet> PermissionSets
        {
            get
            {
                return GetCollection<PermissionSet>("PermissionSets");
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }

}