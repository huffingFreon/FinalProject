///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: ProfessorsController.cs
/// Description: Model for associative ProfessorSoftware objects 
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
    public class ProfessorSoftware
    {
        public int ProfessorID { get; set; }

        public Professor Professor { get; set; }

        public int SoftwareID { get; set; }

        public Software Software { get; set; }
    }
}
