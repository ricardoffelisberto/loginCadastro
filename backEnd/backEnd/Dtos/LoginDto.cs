using System.Runtime.Serialization;

namespace backEnd.Dtos
{
    [DataContract]
    public class LoginDto
    {
        [DataMember(Name = "username")]
        public string username { get; set; }
        public string password { get; set; }
    }
}
