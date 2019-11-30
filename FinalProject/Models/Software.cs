///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: Software.cs
/// Description: Model for Software objects 
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: November 23, 2019
/// 
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Software
    {
        public int SoftwareID { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public string URL { get; set; }

        public bool CSOnly { get; set; }

        public List<ProfessorSoftware> NeededBy { get; set; }

        public List<SystemSoftware> NeededOn { get; set; }
    }
}
