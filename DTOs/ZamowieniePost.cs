using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kolos2.DTOs
{
    public class ZamowieniePost
    {
        [Required]
        public int IdPracownik { get; set; }
        [Required]
        public DateTime DataPrzyjecia { get; set; }
        public string Uwagi { get; set; }
        [Required]
        public List<Wyrob> Wyroby { get; set; }
    }

    public class Wyrob
    {
        [Required]
        public int IdWyrobu { get; set; }
        [Required]
        [Range(1, 1000)]
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }

    }
}
