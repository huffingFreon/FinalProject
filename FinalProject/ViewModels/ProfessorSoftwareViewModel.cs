using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.ViewModels
{
    public class ProfessorSoftwareViewModel
    {
        public Professor Professor { get; set; }

        public List<Software> Softwares { get; set; }
    }
}
