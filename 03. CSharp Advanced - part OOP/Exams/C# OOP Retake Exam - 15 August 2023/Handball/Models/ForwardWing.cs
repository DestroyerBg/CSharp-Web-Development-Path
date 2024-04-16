using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double InitialRating = 5.5;
        private const double IncreaseRatingValue = 1.25;
        private const double DecreaseRatingValue = 0.75;
        public ForwardWing(string name) : base(name, InitialRating)
        {
        }

        public override void IncreaseRating()
        {
            Rating += IncreaseRatingValue;
            if (Rating > 10)
            {
                Rating = 10;
            }
        }

        public override void DecreaseRating()
        {
            Rating -= DecreaseRatingValue;
            if (Rating < 1)
            {
                Rating = 1;
            }
        }
    }
}
