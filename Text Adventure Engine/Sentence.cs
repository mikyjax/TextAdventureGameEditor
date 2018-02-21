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
        List<string> remainingWords = new List<string>();
        public Sentence(string inputSentence)
        {
            inputSentence = inputSentence.Trim();
            inputSentence = inputSentence.ToLower();
            rawWords = inputSentence.Split();
            remainingWords.AddRange(rawWords);
        }

        internal string[] GetVerbs()
        {
            List <string> verbs = new List<string>();

            foreach (var word in remainingWords)
            {
                string rootVerb = FindRootVerb(word);
                if (rootVerb != null)
                    verbs.Add(rootVerb);
            }

            return verbs.ToArray();
        }

        private string FindRootVerb(string word)
        {
            //is the rootVerb go?
            string[] verbSynonyms = Go.synonyms;
            string rootVerb = TryGetRoot(word,verbSynonyms);
            if (rootVerb != null)
                return rootVerb;

            //is the rootVerb take?
            //...

            return null;
        }

        private string TryGetRoot(string word, string[] verbSynonyms)
        {
            foreach (var Synonym in verbSynonyms)
            {
                if (word == Synonym)
                {
                    return verbSynonyms[0];
                }
            }
            return null;
        }
    }
}
