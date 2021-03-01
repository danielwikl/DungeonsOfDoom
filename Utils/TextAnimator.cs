using System;
using System.Threading;

namespace DungeonsOfDoom.Utils
{
   public static class TextAnimator
    {

        //trying to make a text animator, that animates the text with a delay
        public static void AnimateText(string text, int delay)
        {
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
}
