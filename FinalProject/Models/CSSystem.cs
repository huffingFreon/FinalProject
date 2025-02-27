﻿///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: CSSystem.cs
/// Description: Model for CSSystem objects
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
