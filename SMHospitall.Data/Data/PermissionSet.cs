using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using DevExpress.Xpo;

namespace SMHospitall.Data
{

    public class PermissionSet : XPObject
    {
        public PermissionSet(Session session)
            : base(session)
        {
            ((INotifyPropertyChanged)this).PropertyChanged += (s1, e1) =>
            {
                if (e1.PropertyName == "PermissionHow")
                {
                    if (Parent!=null)
                    {
                        Parent.OnPropertyChanged(e1.PropertyName);
                    }
                    OnPropertyChanged("Full");
                    OnPropertyChanged("Read");
                    OnPropertyChanged("Add");
                    OnPropertyChanged("Edit");
                    OnPropertyChanged("Delete");
                    OnPropertyChanged("Report");
                }
            };
        }
        private Permisson _Permisson;
        [Association("Permisson-PermissionSets")]
        public Permisson Permisson
        {
            get
            {
                return _Permisson;
            }
            set
            {
                SetPropertyValue("Permisson", ref _Permisson, value);
            }
        }
        private UserGroup _UserGroup;
        [Association("UserGroup-PermissionSets")]
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
        [NonPersistent]
        public PermissionSet Parent
        {
            get
            {
                if (IsLoading) return null;
                if (Permisson!=null && Permisson.Parent != null && UserGroup != null)
                {
                    return UserGroup.PermissionSets.FirstOrDefault(p => p.Permisson == Permisson.Parent);
                }
                else
                {
                    return null;
                }
            }
        }
        [NonPersistent]
        public List<PermissionSet> Children
        {
            get
            {
                return UserGroup.PermissionSets.Where(p => p.Parent == this).ToList();
            }
        }
        public string Name
        {
            get
            {
                return Permisson.Name;
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
            }
        }
        [NonPersistent]
        public bool Fulls
        {
            get
            {
                return Permisson.PermissionHow != SMHospitall.PermissionHow.None;
            }
        }
        [NonPersistent]
        public bool? Full
        {
            get
            {
                if (!Fulls) return false;
                if (Children.Any())
                {
                    if (Children.All(p=>p.Full==true || !p.Fulls))
                    {
                        return true;
                    }
                    else if (Children.All(p=>p.Full==false || !p.Fulls))
                    {
                        return false;
                    }
                    else
                    {
                        return null as bool?;
                    }
                }
                else
                {
                    return (PermissionHow & Permisson.PermissionHow) == Permisson.PermissionHow
                        ? true
                        : PermissionHow == SMHospitall.PermissionHow.None
                        ? false
                        : null as bool?;
                }
            }
            set
            {
                if (Children.Any())
                {
                    if (value==true)
                    {
                        Children.ForEach(p => p.Full = true);
                    }
                    else if (value==false)
                    {
                        Children.ForEach(p => p.Full = false);
                    }
                    OnPropertyChanged("PermisionHow");
                }
                else
                {
                    if (value==true)
                    {
                        PermissionHow = Permisson.PermissionHow;
                    }
                    else if (value==false)
                    {
                        PermissionHow = SMHospitall.PermissionHow.None;
                    }
                }
            }
        }
        [NonPersistent]
        public bool ReadS
        {
            get
            {
                return (Permisson.PermissionHow | SMHospitall.PermissionHow.Read) == Permisson.PermissionHow;
            }
        }
        [NonPersistent]
        public bool? Read
        {
            set
            {
                if (!ReadS)
                    value = false;
                if (Children.Any())
                {
                    if (value == true)
                        Children.ForEach(p => p.Read = true);
                    else if (value == false)
                        Children.ForEach(p => p.Read = false);
                    OnPropertyChanged("PermissionHow");
                }
                else
                {
                    if (value == true)
                        PermissionHow |= SMHospitall.PermissionHow.Read;
                    else if (value == false)
                        PermissionHow &= ~SMHospitall.PermissionHow.Read;
                }
            }
            get
            {
                if (!ReadS)
                    return false;
                if (Children.Any())
                {
                    if (Children.All(p => p.Read == true || !p.ReadS))
                        return true;
                    else if (Children.All(p => p.Read == false || !p.ReadS))
                        return false;
                    else
                        return null as bool?;
                }
                return (PermissionHow | SMHospitall.PermissionHow.Read) == PermissionHow;
            }
        }
        [NonPersistent]
        public bool AddS
        {
            get
            {
                return (Permisson.PermissionHow | SMHospitall.PermissionHow.Add) == Permisson.PermissionHow;
            }
        }
        [NonPersistent]
        public bool? Add
        {
            set
            {
                if (!AddS)
                    value = false;
                if (Children.Any())
                {
                    if (value == true)
                        Children.ForEach(p => p.Add = true);
                    else if (value == false)
                        Children.ForEach(p => p.Add = false);
                    OnPropertyChanged("PermissionHow");
                }
                else
                {
                    if (value == true)
                        PermissionHow |= SMHospitall.PermissionHow.Add;
                    else if (value == false)
                        PermissionHow &= ~SMHospitall.PermissionHow.Add;
                }
            }
            get
            {
                if (!AddS)
                    return false;
                if (Children.Any())
                {
                    if (Children.All(p => p.Add == true || !p.AddS))
                        return true;
                    else if (Children.All(p => p.Add == false || !p.AddS))
                        return false;
                    else
                        return null as bool?;
                }
                return (PermissionHow | SMHospitall.PermissionHow.Add) == PermissionHow;
            }
        }
        [NonPersistent]
        public bool EditS
        {
            get
            {
                return (Permisson.PermissionHow | SMHospitall.PermissionHow.Edit) == Permisson.PermissionHow;
            }
        }
        [NonPersistent]
        public bool? Edit
        {
            set
            {
                if (!EditS)
                    value = false;
                if (Children.Any())
                {
                    if (value == true)
                        Children.ForEach(p => p.Edit = true);
                    else if (value == false)
                        Children.ForEach(p => p.Edit = false);
                    OnPropertyChanged("PermissionHow");
                }
                else
                {
                    if (value == true)
                        PermissionHow |= SMHospitall.PermissionHow.Edit;
                    else if (value == false)
                        PermissionHow &= ~SMHospitall.PermissionHow.Edit;
                }
            }
            get
            {
                if (!EditS)
                    return false;
                if (Children.Any())
                {
                    if (Children.All(p => p.Edit == true || !p.EditS))
                        return true;
                    else if (Children.All(p => p.Edit == false || !p.EditS))
                        return false;
                    else
                        return null as bool?;
                }
                return (PermissionHow | SMHospitall.PermissionHow.Edit) == PermissionHow;
            }
        }
        [NonPersistent]
        public bool DeleteS
        {
            get
            {
                return (Permisson.PermissionHow | SMHospitall.PermissionHow.Delete) == Permisson.PermissionHow;
            }
        }
        [NonPersistent]
        public bool? Delete
        {
            set
            {
                if (!DeleteS)
                    value = false;
                if (Children.Any())
                {
                    if (value == true)
                        Children.ForEach(p => p.Delete = true);
                    else if (value == false)
                        Children.ForEach(p => p.Delete = false);
                    OnPropertyChanged("PermissionHow");
                }
                else
                {
                    if (value == true)
                        PermissionHow |= SMHospitall.PermissionHow.Delete;
                    else if (value == false)
                        PermissionHow &= ~SMHospitall.PermissionHow.Delete;
                }
            }
            get
            {
                if (!DeleteS)
                    return false;
                if (Children.Any())
                {
                    if (Children.All(p => p.Delete == true || !p.DeleteS))
                        return true;
                    else if (Children.All(p => p.Delete == false || !p.DeleteS))
                        return false;
                    else
                        return null as bool?;
                }
                return (PermissionHow | SMHospitall.PermissionHow.Delete) == PermissionHow;
            }
        }
        [NonPersistent]
        public bool ReportS
        {
            get
            {
                return (Permisson.PermissionHow | SMHospitall.PermissionHow.Print) == Permisson.PermissionHow;
            }
        }
        [NonPersistent]
        public bool? Report
        {
            set
            {
                if (!ReportS)
                    value = false;
                if (Children.Any())
                {
                    if (value == true)
                        Children.ForEach(p => p.Report = true);
                    else if (value == false)
                        Children.ForEach(p => p.Report = false);
                    OnPropertyChanged("PermissionHow");
                }
                else
                {
                    if (value == true)
                        PermissionHow |= SMHospitall.PermissionHow.Print;
                    else if (value == false)
                        PermissionHow &= ~SMHospitall.PermissionHow.Print;
                }
            }
            get
            {
                if (!ReportS)
                    return false;
                if (Children.Any())
                {
                    if (Children.All(p => p.Report == true || !p.ReportS))
                        return true;
                    else if (Children.All(p => p.Report == false || !p.ReportS))
                        return false;
                    else
                        return null as bool?;
                }
                return (PermissionHow | SMHospitall.PermissionHow.Print) == PermissionHow;
            }
        }
        public override string ToString()
        {
            return Name;
        }
        protected override bool SetPropertyValue<T>(string propertyName, ref T propertyValueHolder, T newValue)
        {
            if (!IsLoading && Id > 0 && UserGroup != null && UserGroup.Code == "Administrator")
                throw new Exception("Bạn không được thay đổi nhóm quản trị");
            return base.SetPropertyValue<T>(propertyName, ref propertyValueHolder, newValue);
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }

}