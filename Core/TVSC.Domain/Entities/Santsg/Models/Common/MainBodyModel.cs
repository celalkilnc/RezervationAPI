using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSC.Domain.Entities.Santsg.Models.Common
{
    public class MainBodyModel<T> where T : class
    {
        public List<T> ModelList { get; set; }

    }
}
