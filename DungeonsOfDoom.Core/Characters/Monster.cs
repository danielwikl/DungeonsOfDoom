using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom.Items;

namespace DungeonsOfDoom.Core.Characters

    // the monsterclass inherts props from Character and iluggable since the monster remains can be carried in backpack
    //monster class will further be a parent class to the different monsters
{
    public abstract class Monster : Character, ILuggable
    {
        public Monster(int health, string name) : base(health)
        {
            Name = name;
            MonsterCount++;
        }
        public string Name { get; set; }
        //whenever a monster is created the monstercount should be incremented
        public static int MonsterCount { get; set; }

        //override viritual health prop from character
        //keeps track of how many monsters there are left on the map.
        //if the monsters health is less than or equal to 0 the monstercount goes down
        public override int Health
        {
            get => base.Health;

            set
            {
                base.Health = value;

                if(base.Health <= 0)
                {
                    MonsterCount--;
                }
            }

        }
    }
}
