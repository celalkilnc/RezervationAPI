
namespace TVSC.Domain.Entities.Santsg.Models
{
    public class BodyModel
    {
        public Body body { get; set; }
        public Header header { get; set; }


        public class Body
        {
            public string token { get; set; }
            public DateTime expiresOn { get; set; }
            public int tokenId { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public List<Message> messages { get; set; }
        }
        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }
    }
}