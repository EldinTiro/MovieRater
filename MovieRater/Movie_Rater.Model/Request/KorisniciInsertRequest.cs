using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Movie_Rater.Model.Request
{
    public class KorisniciInsertRequest
    {
        [Required]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }
        [Required]
        [MinLength(4)]
        public string Ime { get; set; }
        [Required]
        [MinLength(4)]
        public string Prezime { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public DateTime? DatumRodjenja { get; set; }
    }
}
