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
        public Hersteller Hersteller { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Lizenz> Lizenzs { get; set; }
    }
}