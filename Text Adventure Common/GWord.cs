using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureCommon
{
    public abstract class GWord
    {
        public string Plural { get; set; }
        public bool Elision { get; set; }
        public int ID { get; set; }
        static public int IdCounter;
    }

    public class GNoun : GWord
    {
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public bool IsSingular { get; set; }

        public GNoun(string name, Genre genre,int id,bool isSingular = true)
        {
            Name = name;
            Genre = genre;
            IsSingular = isSingular;
            ID = id;
        }
    }

    public class GAdjective : GWord
    {
        public string Masc { get; set; }
        public string Fem { get; set; }
        public GAdjective(string masc,string fem,bool isMasc = true)
        {
            Masc = masc;
            Fem = fem;
        }
    }



}
