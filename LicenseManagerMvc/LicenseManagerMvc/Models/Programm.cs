using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManagerMvc.Models
{
    public class Programm
    {
        public int ProgrammId { get; set; }
        public int HerstellerId { get; set; }
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }

        public virtual Hersteller Hersteller { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Lizenz> Lizenzs { get; set; }
    }
}