using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManagerMvc.Models
{
    public class Hersteller
    {
        public int HerstellerId { get; set; }
        public string Name { get; set; }
        public string Homepage { get; set; }
        public string Sonstiges { get; set; }

        public virtual ICollection<Programm> Programms { get; set; }
    }
}