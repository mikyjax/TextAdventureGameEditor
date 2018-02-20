using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventureEngine
{
    class Sentence
    {
        string[] rawWords;
        Verb verb;
        List<Word> nouns;

        public Sentence(string inputSentence)
        {
            inputSentence = inputSentence.Trim();
            inputSentence = inputSentence.ToLower();
            rawWords = inputSentence.Split();
        }
    }
}
