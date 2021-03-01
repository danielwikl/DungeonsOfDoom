using System;
using DungeonsOfDoom.Utils;

namespace DungeonsOfDoom.Core.Characters
 
{

    //ogre class inherits from monster, which the health is set randomly with a function from the Utils Class
     public class Ogre : Monster
    {

        // if the random percent is below 70 the monster hp will be set to 10, otherwise it will be 20 making it a harder monster to beat.
        public Ogre() : base(RandomUtils.Percentage() < 70 ? 10 : 20, "Ogre")
        {
            
        }

        //
        public override AttackResult Attack(Character opponent)
        {
            int damage = 0;
            if (opponent.Health > 0)
            {
                
                damage = 10;
                Console.WriteLine($"{Name} attacks");
                opponent.Health -= damage;
            }

            return new AttackResult(this, opponent, damage);

        }


    }
}
