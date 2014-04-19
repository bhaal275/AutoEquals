using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEquals.Lib
{
    public class DerivedClass : BaseClass
    {
        [EqualsProperty]
        public int SecondProperty { get; set; }
    }
}
