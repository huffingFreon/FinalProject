///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: InventoryItem.cs
/// Description: Model for items in the inventory 
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: November 27, 2019
/// 
///////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class InventoryItem
    {
        public int InventoryItemID { get; set; }

        public string Description { get; set; }

        public bool CheckedOut { get; set; }

        //Allowed this relationship to be nullable, for when items are not checked out
        public int? UserID { get; set; }

        public Professor User { get; set; }
    }
}
