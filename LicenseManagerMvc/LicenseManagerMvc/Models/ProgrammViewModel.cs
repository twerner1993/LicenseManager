using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManagerMvc.Models
{
    public class ProgrammViewModel
    {
        public int ProgrammId { get; set; }
        public string HerstellerName { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public int GenreId { get; set; }
        public virtual Hersteller Hersteller { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Lizenz> Lizenzs { get; set; }
    }
}