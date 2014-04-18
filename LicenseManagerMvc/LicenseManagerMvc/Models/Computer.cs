using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LicenseManagerMvc.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        public string Hostname { get; set; }

        public virtual ApplicationUser UserProfile { get; set; }
        public virtual ICollection<Lizenz> Lizenzs { get; set; }
    }
}