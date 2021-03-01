﻿using System;
using System.Collections.Generic;

namespace MovieRater.Database
{
    public partial class Korisnici
    {
        public int KorisnikId { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaSalt { get; set; }
        public string LozinkaHash { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
    }
}
