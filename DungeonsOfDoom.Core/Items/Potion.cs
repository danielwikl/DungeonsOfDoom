using System;
using DungeonsOfDoom.Core.Characters;

namespace DungeonsOfDoom.Items
{
    public class Potion : Item
    {
        public Potion() : base("Potion")
        {
        }

        //the Use method that takes in player and its props
        // in this case we want to manipulate the health with a potion
        public override void Use(Player player)
        {
            if (player.Health <= 20)
                player.Health += 10;
            player.X = 0;
            player.Y = 0;
            Console.WriteLine("Refreshing!");
        }

    }
}
