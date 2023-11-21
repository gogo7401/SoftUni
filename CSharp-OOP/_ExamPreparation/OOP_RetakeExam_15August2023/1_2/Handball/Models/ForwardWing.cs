using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private static double initialRating = 5.50;
        public ForwardWing(string name) : base(name, initialRating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 0.75;
        }

        public override void IncreaseRating()
        {
            Rating += 1.25;
        }
    }
}
