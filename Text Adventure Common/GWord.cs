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
        public string Singular { get; set; }
        public Genre Genre { get; set; }
        public bool IsSingular { get; set; }

        public GNoun(string singular, Genre genre,int id=0,bool isSingular = true)
        {
            Singular = singular;
            Plural = "";
            Genre = genre;
            IsSingular = isSingular;
            ID = id;
            if(Genre == null)
            {
                Genre = Genre.masuclin;
            }
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
