using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SMHospitall
{
    public class bindingSource : System.Windows.Forms.BindingSource
    {
        public bindingSource()
        {
        }
        public bindingSource(object datasource, string dataMember)
            :base(datasource,dataMember)
        {

        }
        public bindingSource(IContainer container):base(container)
        {
        }
    }
}
