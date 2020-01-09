///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: SystemSoftwareViewModel.cs
/// Description: Model for when views require one CSSystem to many software
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: December 06, 2019
/// 
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class SystemSoftwareViewModel
    {
        public int CSSystemID { get; set; }

        public CSSystem CSSystem { get; set; }

        public List<Software> Software { get; set; }
    }
}
