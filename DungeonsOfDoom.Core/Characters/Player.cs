using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Items;

namespace DungeonsOfDoom.Core.Characters
{

    // the player inherits health from the character class, when the player is instantiated the value and the cooardinates is set in Consolegame.cs 
    public class Player : Character
    {
        public Player(int health, int x, int y) : base(health)
        {
            X = x;
            Y = y;
            Backpack = new List<ILuggable>();
            
        }

        public int X { get; set; }
        public int Y { get; set; }
        public List<ILuggable> Backpack { get; set; }

    }
}
