///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: Professor.cs
/// Description: Model for Professor objects
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
    public class Professor
    {
        public int ProfessorID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<ProfessorSoftware> NeededSoftware { get; set; }

        public List<InventoryItem> CheckedOutItems { get; set; }

        public List<CSSystem> PrimaryUserSystems { get; set; }
    }
}
