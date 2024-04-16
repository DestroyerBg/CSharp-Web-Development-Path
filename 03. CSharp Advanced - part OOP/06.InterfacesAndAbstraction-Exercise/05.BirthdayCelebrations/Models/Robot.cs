﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.BorderControl.Models.Interfaces;

namespace _05.BirthdayCelebrations.Models
{
    public class Robot : IIdentifier
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Model { get; private set; }
        public string Id { get; private set; }
    }
}
