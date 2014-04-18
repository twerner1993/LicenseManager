using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManagerMvc.Models
{
    public class Lizenz
    {
        public int LizenzId { get; set; }
        public int ProgrammId { get; set; }
        public string Edition { get; set; }
        public string Schluessel { get; set; }

        public virtual Programm Programm { get; set; }
        public virtual ICollection<Computer> Verwendung { get; set; }
    }
}