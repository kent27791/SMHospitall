using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.Repository;

namespace SMHospitall.Ctr
{
    public class RCEdit : RepositoryItemCheckEdit
    {
        public override string GetDisplayText(DevExpress.Utils.FormatInfo format,object editValue)
        {
            return "+";
        }
    }
}
