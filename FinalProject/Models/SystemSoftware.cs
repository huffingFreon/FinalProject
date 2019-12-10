using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class SystemSoftware
    {
        public int CSSystemID { get; set; }

        public CSSystem CSSystem { get; set; }

        public int SoftwareID { get; set; }

        public Software Software { get; set; }

    }
}
