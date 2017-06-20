using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;
using System.Data;
using DevExpress.Data;
using System.Text;

namespace SMHospitall
{
    public static class PermissionWork
    {
        public static void GetPermissionWork(this UnitOfWork work, System.Reflection.Assembly assembly = null, List<Data.Permisson> Results = null)
        {
            if (Results==null)
            {
                Results = work.Query<Data.Permisson>().ToList();
            }
            if (assembly==null)
            {
                assembly = System.Reflection.Assembly.GetExecutingAssembly();
            }
            var types = assembly.GetTypes().Where(p=>p.IsSubclassOf(typeof(Forms.frmBase))).ToList();
            var fs = types.FirstOrDefault(p => p == typeof(Forms.frmEndUser));
            types.Remove(fs);
            types.Insert(0, fs);
            foreach (Type item in types)
            {
                var ip = (Forms.frmBase)Activator.CreateInstance(item);
                if (ip._PermissionAlias.IsNullOrEmpty())
                {
                    continue;
                }
                var alias = ip._PermissionAlias.Split('.');
                var a = "";
                for (int i = 0; i < alias.Length-1; i++)
                {
                    var parentAlias = a;
                    if (a=="")
                    {
                        a += alias[i];
                    }
                    else
                    {
                        a += "." + alias[i];
                    }
                    if (!Results.Any(p=>p.Alias==a))
                    {
                        Data.Permisson parent = null;
                        if (parentAlias.Length>0)
                        {
                            parent = Results.FirstOrDefault(p => p.Alias == parentAlias);
                        }
                        Results.Add(new Data.Permisson(work)
                            {
                                Parent=parent,
                                Alias=a,
                                Name=GetName(a),
                                PermissionHow=PermissionHow.None
                            });
                    }
                    else
                    {
                        Results.FirstOrDefault(p => p.Alias == a).Name = GetName(a);
                    }
                }
                if (Results.Any(p=>p.Alias==ip._PermissionAlias))
                {
                    var r = Results.FirstOrDefault(p => p.Alias == ip._PermissionAlias);
                    r.Name = ip._PermissionName;
                    r.PermissionHow |= ip._PermissionHow;
                }
                else
                {
                    Data.Permisson parent = null;
                    if (a.Length>0)
                    {
                        parent = Results.FirstOrDefault(p => p.Alias == a);
                    }
                    Results.Add(new Data.Permisson(work)
                    {
                        Parent=parent,
                        Alias=ip._PermissionAlias,
                        Name=ip._PermissionName,
                        PermissionHow=ip._PermissionHow
                    });
                }
            };
            work.CommitChanges();
        }

        static string GetName(string a)
        {
            switch (a)
            {
                case "SMHospitall":
                    return "Quản lý hệ thống";
                case "SMHospitall.System":
                    return "Cài đặt thông tin";
                case "SMHospitall.Catalogue":
                    return "Quản lý danh mục";
                case "SMHospitall.Handy":
                    return "Quản lý tiện ích";
                case "SMHospitall.Report":
                    return "Quản lý thống kê";
                case "SMHospitall.Help":
                    return "Trợ giúp";
                default:
                    return a;
            }
        }
        public static void CheckPermission(this Forms.frmBase fm, PermissionHow p)
        {
            var work = fm.work;
            if (work.LoginUser == null)
            {
                throw new Exception("Chưa đăng nhập chương trình");
            }
            else if (work.LoginUser.UserGroup == null)
            {
                throw new Exception("Chưa được phân quyền hệ thống");
            }
            var ps = fm.work.LoginUser.UserGroup.PermissionSets.FirstOrDefault(q => q.Permisson.Alias == fm._PermissionAlias);
            if (ps == null)
                return;
            switch (p)
            {
                case PermissionHow.Read:
                    if (ps.Read==false)
                    {
                        throw new Exception("Bạn không có quyền 'đọc' chức năng: " + ps.Name);
                    }
                    break;
                case PermissionHow.Add:
                    if (ps.Add == false)
                    {
                        throw new Exception("Bạn không có quyền 'thêm' chức năng: " + ps.Name);
                    }
                    break;
                case PermissionHow.Edit:
                    if (ps.Edit == false)
                    {
                        throw new Exception("Bạn không có quyền 'sửa' chức năng: " + ps.Name);
                    }
                    break;
                case PermissionHow.Delete:
                    if (ps.Delete == false)
                    {
                        throw new Exception("Bạn không có quyền 'xoá' chức năng: " + ps.Name);
                    }
                    break;
                case PermissionHow.Print:
                    if (ps.Report == false)
                    {
                        throw new Exception("Bạn không có quyền 'in' chức năng: " + ps.Name);
                    }
                    break;
            }
        }
    }
}
