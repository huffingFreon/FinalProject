using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class CSSystem 
    {
        public int CSSystemID { get; set; }

        public string Name { get; set; }

        public string IPAddress { get; set; }

        public int PrimaryUserID { get; set; }

        public Professor PrimaryUser { get; set; }

        public  List<SystemSoftware> NeededSoftware { get; set; }
    }
}
