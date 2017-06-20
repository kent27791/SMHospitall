using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace SMHospitall
{
    public enum PermissionHow
    {
        None=0,
        [Description("Xem")]
        Read=1,
        [Description("Thêm")]
        Add=2,
        [Description("Sửa")]
        Edit=4,
        [Description("Xoá")]
        Delete=8,
        [Description("Xem báo cáo")]
        Print=16,
        ReadEdit=Read|Edit,
        ReadEAddEditDelete=Read|Add|Edit|Delete,
        Full=1|2|4|8|16
    }
}
