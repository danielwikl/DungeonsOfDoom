using System;
using DungeonsOfDoom.Utils;

namespace DungeonsOfDoom.Core.Characters
{
     public class Skeleton : Monster
    {
        // skeletonclass inherits health from monster, and the health is set with a diceroll function from the randomutils class
        //so the skeleton will have HP between 1 and whatever value you set the dice to

        public Skeleton() : base(RandomUtils.DiceRoll(6), "Skeleton")
        {
        }

        // if the player is to healthy the skeleton will not attack insted try to run away
        public override AttackResult Attack(Character opponent)
        {
            int damage = 0;

            if (opponent.Health < 30)
            {
                damage = 5;
                Console.WriteLine($"{Name} attacks!");

                opponent.Health -= damage;

            }

            return new AttackResult(this, opponent, damage);


        }

    }
}
