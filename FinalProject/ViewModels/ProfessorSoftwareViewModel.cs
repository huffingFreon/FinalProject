///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: ProfessorSoftwareViewModel.cs
/// Description: Model for when views require one professor to many software, systems, and inventory items.
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
    public class ProfessorSoftwareViewModel
    {
        public Professor Professor { get; set; }

        public List<Software> Softwares { get; set; }

        public List<InventoryItem> InventoryItems { get; set; }
    }
}
