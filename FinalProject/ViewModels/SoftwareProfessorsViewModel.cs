using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class SoftwareProfessorsViewModel
    {
        public int SoftwareID { get; set; }

        public Software Software { get; set; }

        public List<Professor> Professors { get; set; }
    }
}
