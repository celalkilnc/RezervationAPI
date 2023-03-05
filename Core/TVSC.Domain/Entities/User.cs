using System.ComponentModel.DataAnnotations;
using TVSC.Domain.Entities.Common;
using TVSC.Domain.Enumerations;

namespace TVSC.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
       
        public string? Password { get; set; }
       
        public StatusEnum? Status { get; set; } 

    }
}
