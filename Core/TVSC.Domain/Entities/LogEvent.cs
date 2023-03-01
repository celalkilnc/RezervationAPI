using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSC.Domain.Entities.Common;

namespace TVSC.Domain.Entities
{
    public class LogEvent : BaseEntity
    {
        public string LogDetail { get; set; }
    }
}
