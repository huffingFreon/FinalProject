///////////////////////////////////////////////////////////
///
/// Project: Final Project 
/// File Name: Software.cs
/// Description: Model for ErrorViewModel objects 
/// Course: CSCI 2910-201
/// Author: Ben Higgins, higginsba@etsu.edu
/// Created: November 23, 2019
/// 
///////////////////////////////////////////////////////////
using System;

namespace FinalProject.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
