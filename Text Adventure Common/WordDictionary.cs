using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureCommon
{
    public class WordDictionary
    {
        public List<GNoun> nouns { get; set; }
        public List<GAdjective> adjectives { get; set; }
        static private int nounsIdCounter;
        static private int adjectivesIdCounter;
        public WordDictionary()
        {
            nounsIdCounter = 0;
            adjectivesIdCounter = 0;
            nouns = new List<GNoun>();
            adjectives = new List<GAdjective>();
        }

        public bool IsExisting(GNoun noun)
        {
            return nouns.Contains(noun);
        }
        public bool IsExisting(GAdjective adjective)
        {
            return adjectives.Contains(adjective);
        }

        public void Add(GNoun noun)
        {
            nounsIdCounter++;
            GNoun nounToAdd = new GNoun(noun.Singular, noun.Genre, nounsIdCounter, noun.IsSingular);
            nouns.Add(nounToAdd);
        }
        public void Add(GAdjective adjective)
        {
            adjectivesIdCounter++;
            GAdjective adjectiveToAdd = new GAdjective(adjective.Masc, adjective.Fem);
        }

        public GNoun GetNounById(int id)
        {
            foreach (var noun in nouns)
            {
                if(noun.ID == id)
                {
                    return noun;
                }
            }
            return null;
        }
        public GAdjective GetAdjectiveById(int id)
        {
            foreach (var adj in adjectives)
            {
                if (adj.ID == id)
                {
                    return adj;
                }
            }
            return null;
        }

        public void EditNoun(GNoun newNoun)
        {
            nounIdToEdit = newNoun.ID;
            GNoun nounToRemove = null;
            foreach(var noun in nouns)
            {
                if(nounIdToEdit == noun.ID)
                {
                    nounToRemove = noun;
                }
            }
            if(nounToRemove == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                nouns.Remove(nounToRemove);
                nouns.Add(newNoun);
                newNoun.ID = nounIdToEdit;
            }
        }
        public void EditAdjective(int adjectiveIdToEdit, GAdjective newAdjective)
        {
            GAdjective adjectiveToRemove = null;
            foreach (var adj in adjectives)
            {
                if (adjectiveIdToEdit == adj.ID)
                {
                    adjectiveToRemove = adj;
                }
            }
            if (adjectiveToRemove == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                adjectives.Remove(adjectiveToRemove);
                adjectives.Add(newAdjective);
                newAdjective.ID = adjectiveIdToEdit;
            }
        }

    }
}
