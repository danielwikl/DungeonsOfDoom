using System;
namespace DungeonsOfDoom.Core.Characters
{

    // character class. this is the parent of which monster and player inherits from
    // 
    public abstract class Character
    {
        public Character(int health)
        {
            Health = health;
        }

        public virtual AttackResult Attack(Character opponent)
        {
            int damage = 10;
            opponent.Health -= damage;
            return new AttackResult(this, opponent, damage);
        }
        // viritual means optional overridable
        public virtual int Health { get; set; }
        // true if health is more than 0
        public bool IsAlive { get { return Health > 0; } }
    }
}
