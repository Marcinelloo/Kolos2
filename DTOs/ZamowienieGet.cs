using System;
using System.Collections.Generic;

namespace kolos2.DTOs
{
    public class ZamowienieGet
    {
        public int IdZamowienia { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public DateTime DataRealizacji { get; set; }
        public string Uwagi { get; set; }
        public List<Wyroby> Wyroby { get; set; }
    }

    public class Wyroby
    {
        public int IdWyrobu { get; set; }
        public string Nazwa { get; set; }
        public int Ilosc { get; set; }
        public string Uwagi { get; set; }
        public string Typ { get; set; }
        public double CenaZaSztuke { get; set; }
    }
}
