using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double InitialRating = 4;
        private const double IncreaseRatingValue = 1;
        private const double DecreaseRatingValue = 1;
        public CenterBack(string name) : base(name, InitialRating)
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
