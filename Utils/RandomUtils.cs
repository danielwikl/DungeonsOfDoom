using System;
namespace DungeonsOfDoom.Utils
{

    // this class does not need to be instantiated or inherited
    //this is just a collection of ultillities
    public static class RandomUtils
    {
        static Random random = new Random();

        public static int Percentage()
        {
            return random.Next(1, 100 +1);
        }

        public static int DiceRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }
    }
}
