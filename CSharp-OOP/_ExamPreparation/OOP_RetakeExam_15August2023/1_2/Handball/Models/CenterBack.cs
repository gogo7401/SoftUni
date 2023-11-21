using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        private static double initialRating = 4.00;
        public CenterBack(string name) : base(name, initialRating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 1.00;
        }

        public override void IncreaseRating()
        {
            Rating += 1.00;
        }
    }
}
