using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;
using System.ComponentModel;

namespace SMHospitall
{
    public static class Libs
    {
        public static void SetFocuseRow(this DevExpress.XtraGrid.Views.Grid.GridView gridview, object obj)
        {
            if (gridview.DataSource is IList)
                gridview.FocusedRowHandle = gridview.GetRowHandle((gridview.DataSource as IList).IndexOf(obj));
        }
    }
}
