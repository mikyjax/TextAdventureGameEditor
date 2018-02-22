using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventureCommon;

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
            List<string> verbs = new List<string>();
            Go go = new Go();
            AddRootWordsFromSynonyms(verbs,Go.synonyms);
          //AddRootWordsFromSynonyms(verbs,Take.synonyms);
          //etc.....
            return verbs.ToArray();
        }
        internal string[] GetDirections()
        {
            List<string> directions = new List<string>();
            int numberOfRow = DirectionObject.directions.GetUpperBound(0) - DirectionObject.directions.GetLowerBound(0) + 1;
            for (int i = 0; i < numberOfRow; i++)
            {
                AddRootWordsFromSynonyms(directions, DirectionObject.directions[i]);
            }
            return directions.ToArray();
        }

        private void AddRootWordsFromSynonyms(List<string> verbs,string[]synonyms)
        {
            List<string> WordsToRemove = new List<string>();
            foreach (var word in remainingWords)
            {
                
                string rootWord = FindRootWord(word, synonyms);
                if (rootWord != null)
                    verbs.Add(rootWord);
                WordsToRemove.Add(rootWord);
            }
            foreach (var word in WordsToRemove)
            {
                remainingWords.Remove(word);
            }
        }
        private string FindRootWord(string word, string[] synonyms)
        {
            string[] wordSynonyms = synonyms;
            string rootWord = TryGetRoot(word, wordSynonyms);
            if (rootWord != null)
                return rootWord;
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
