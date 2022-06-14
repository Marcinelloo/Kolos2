using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace kolos2.Entities.Models
{
    public class MusicanTrack
    {
        public int IdTrack { get; set; }
        public int IdMusican { get; set; }
        public virtual Musican Musican { get; set; }
        public virtual Track Track { get; set; }
    }
}
