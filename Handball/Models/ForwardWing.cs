using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player

    { 
        private const double initialRating = 5.5;
        public ForwardWing(string name, double rating) : base(name, initialRating)
        {
        }
        //rating = math.min(10, Rating+0.75)
        public override void DecreaseRating()
        {
            this.Rating = Math.Min(10, Rating+0.75);
        }

        public override void IncreaseRating()
        {
            this.Rating = Math.Min(10, Rating+1.25);
        }
    }
}
