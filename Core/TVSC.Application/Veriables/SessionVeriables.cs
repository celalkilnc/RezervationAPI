using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Application.Veriables
{
    public class SessionVeriables<T> where T : class
    {
        public string Key { get; set; }

        public T Value { get; set; }
    }
}
