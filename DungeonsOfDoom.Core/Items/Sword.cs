using System;
using DungeonsOfDoom.Core;
using DungeonsOfDoom.Core.Characters;

namespace DungeonsOfDoom.Items
{
    // inherits from item, where the base is Name of the item
    public class Sword : Item
    {
        public Sword() : base("Sword")
        {
        }

        public override void Use(Player player)
        {
            player.Health++;
            Console.WriteLine("Your attack damage has increesed by 5");
        }
    }
}
