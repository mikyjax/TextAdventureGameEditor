using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureCommon
{
    public static class Grammar
    {
        public static string GuessPlural(string singular)
        {
            singular = singular.ToLower().Trim();

            string plural;
            char lastLetter = singular[singular.Length - 1];
            //string wordWithoutLastLetter = singular.Remove(singular.Length - 2);
            if (lastLetter == 'u')
            {
                plural = singular + "x";
            }
            else if (lastLetter == 's')
            {
                plural = singular;
            }
            else
            {
                plural = singular + "s";
            }
            return plural;
        }
        public static string GetDefiniteArticle(bool isMasc, bool hasElusion)
        {

            if (hasElusion)
            {
                return "l'";
            }
            else
            {
                if (isMasc)
                {
                    return "le";
                }
                else
                {
                    return "la";
                }
            }
        }
    }

    public enum Genre
    {
        masuclin,
        feminin
    }
}
