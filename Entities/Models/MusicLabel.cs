using System;
using System.Collections.Generic;

namespace kolos2.Entities.Models
{
    public class MusicLabel
    {
        public int IdMusicLabel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
