using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureEngine
{
    static class Display
    {

        public static void ClearConsole()
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
        public static void TextAndReturn(string textToDisplay, int numberOfReturn = 1)
        {
            Text(textToDisplay);
            
            AddNReturn(numberOfReturn);
            
        }
        public static void TextUnderlinedAndReturn(string textToDisplay, int numberOfReturn = 1)
        {
            int charCount = textToDisplay.Length;
            TextAndReturn(textToDisplay);
            for (int i = 0; i < charCount; i++)
            {
                Text("*");
            }
            AddNReturn(numberOfReturn);
        }
        public static void AddNReturn(int numberOfReturn = 1)
        {
            if (numberOfReturn < 1)
            {
                numberOfReturn = 1;
            }
            for (int i = 0; i < numberOfReturn; i++)
            {
                Text("\n");
            }
        }
        public static string RequestPlayerInput()
        {
            string playerInput = Console.ReadLine();
            return playerInput;
        }


        

        
        
    }
}
