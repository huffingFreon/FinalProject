///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: SoftwareProfessorsViewModel.cs
/// Description: Model for when views require one software to many professors and systems
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: November 23, 2019
/// 
///////////////////////////////////////////////////////////
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
        public List<CSSystem> Systems { get; set; }
    }
}
