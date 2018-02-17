using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureEngine
{
    static class Display
    {

        public static void Clear()
        {
            for (int i = 0; i< 100; i++)
            {
                Console.WriteLine("");
            }
            
        }

        public static void Text(string textToDisplay)
        {
            Console.Write(textToDisplay);
        }
        public static void TextAndReturn(string textToDisplay)
        {
            Text(textToDisplay);
            Text("\n");
            
        }
        public static string RequestPlayerInput()
        {
            string playerInput = Console.ReadLine();
            return playerInput;
        }
    }
}
