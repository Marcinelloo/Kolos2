using System;
using System.Collections.Generic;
using kolos2.Entities.Models;

namespace kolos2.DTOs
{
    public class MusicanGet
    {
        public Musican Musican { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
