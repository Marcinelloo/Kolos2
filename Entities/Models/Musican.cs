using System.Collections.Generic;

namespace kolos2.Entities.Models
{
    public class Musican
    {
        public int IdMusican { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? NickName { get; set; }

        public virtual ICollection<MusicanTrack> MusicanTrack { get; set; }
    }
}
