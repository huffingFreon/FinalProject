using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ProfessorSoftware
    {
        public int ProfessorID { get; set; }

        public Professor Professor { get; set; }

        public int SoftwareID { get; set; }

        public Software Software { get; set; }
    }
}
