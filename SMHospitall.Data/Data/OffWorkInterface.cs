using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMHospitall.Data
{
    public partial interface OffWorkInterface
    {
        string No { set; get; }
        DateTime DateTime { set; get; }
    }
}
