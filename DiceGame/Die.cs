using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    // Die object
    internal class Die
    {
        // Initialising variables
        private Random rnd = new Random();
        public int sides { get; set; }

        // Method to roll using a random number generator between
        // one and the number of sides on the die
        public int Roll()
        {
            return rnd.Next(1, sides + 1);
        }

        // Constructor
        public Die(int sides)
        {
            this.sides = sides;
        }
    }
}
