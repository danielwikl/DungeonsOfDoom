using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Core.Characters;

namespace DungeonsOfDoom.Items
{

    // the itemclass is the parent class to sword and potion
  public abstract class Item : ILuggable
    {
        public Item(string name)
        {
            ItemCount++;
            Name = name;
        }

        public string Name { get; set; }
        public static int ItemCount { get; set; }


        public abstract void Use(Player player);
    }
}
