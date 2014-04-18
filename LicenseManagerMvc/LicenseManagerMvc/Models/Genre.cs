using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManagerMvc.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Programm> Programms { get; set; }
    }
}