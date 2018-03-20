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
        
        public const string TOO_MANY_DIRECTIONS = "TOO_MANY_DIRECTIONS";
        public const string DIRECTION_NOT_EXISTING = "DIRECTION_NOT_EXISTING";

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
        internal string GetDirection()
        {
            List<string> directions = new List<string>();
            List<string> wordToRemove = new List<string>();
            int numberOfRow = DirectionObject.directions.GetUpperBound(0) - DirectionObject.directions.GetLowerBound(0) + 1;

            foreach (var word in remainingWords)
            {
                
                for (int i = 0; i < numberOfRow; i++)
                {
                    string directionToAdd = getRootWordFromSynonyms(word,DirectionObject.directions[i]);
                    if(directionToAdd != null)
                    {
                        directions.Add(getRootWordFromSynonyms(word, DirectionObject.directions[i]));
                        wordToRemove.Add(word);
                    }
                }
            }

            foreach (var word in wordToRemove)
            {
                remainingWords.Remove(word);
            }
            if (directions.Count == 1)
            {
                return directions[0];
            }
            if(directions.Count < 1)
            {
                return DIRECTION_NOT_EXISTING;
            }
            if(directions.Count > 2)
            {
                return TOO_MANY_DIRECTIONS;
            }
            else
            {
                return GetDirection(directions[0],directions[1]);
            }
            
        }

        internal List<Oobject> GetObjectsInSentence(List<Oobject> availlableObjects)
        {
            List<Oobject> objectsInSentence = new List<Oobject>();
            List<String> wordToRemove = new List<string>();
            foreach (var word in remainingWords)
            {
                foreach (var availlableObject in availlableObjects)
                {
                    if (availlableObject.IsWordExistingInSynonyms(word))
                    {
                        wordToRemove.Add(word);
                        objectsInSentence.Add(availlableObject);
                    }
                    
                }
            }

            foreach (var word in wordToRemove)
            {
                remainingWords.Remove(word);
            }

            return objectsInSentence;
        }

        private string getRootWordFromSynonyms(string word, string[] synonyms)
        {
            foreach (var synonym in synonyms)
            {
                if(word == synonym)
                {
                    return synonyms[0];
                }
            }
            return null;
        }

        private string GetDirection(string dir1, string dir2)
        {
            string concatenateDirection = dir1 + dir2;
            if (DirectionObject.isDirectionExisting(concatenateDirection))
            {
                return concatenateDirection;
            }
            else
            {
                return DIRECTION_NOT_EXISTING;
            }
            
        }

        private void AddRootWordsFromSynonyms(List<string> words,string[]synonyms)
        {
            List<string> WordsToRemove = new List<string>();
            foreach (var word in remainingWords)
            {
                
                string rootWord = FindRootWord(word, synonyms);
                if (rootWord != null)
                {
                    words.Add(rootWord);
                    WordsToRemove.Add(rootWord);
                }
                    
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
        private string TryGetRoot(string word, string[] wordSynonyms)
        {
            foreach (var Synonym in wordSynonyms)
            {
                if (word == Synonym)
                {
                    return wordSynonyms[0];
                }
            }
            return null;
        }

        

        

        
    }
}
