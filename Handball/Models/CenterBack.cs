﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player

    { 
        private const double initialRating = 4;
        public CenterBack(string name) : base(name, initialRating)
        {
        }

        public override void DecreaseRating()
        {
            this.Rating=Math.Min(10,Rating + 1);
        }

        public override void IncreaseRating()
        {
            this.Rating = Math.Min(10, Rating + 1);
        }
    }
}
