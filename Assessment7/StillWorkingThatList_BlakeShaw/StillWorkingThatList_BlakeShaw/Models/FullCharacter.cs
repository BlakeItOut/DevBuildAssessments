using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillWorkingThatList_BlakeShaw.Models
{
    public class FullCharacter
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Culture { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public List<string> Titles { get; set; }
        public List<string> Aliases { get; set; }
        public string Father { get; set; }
        public string Mother { get; set; }
        public string Spouse { get; set; }
        public List<string> Allegiances { get; set; }
        public List<string> Books { get; set; }
        public List<object> PovBooks { get; set; }
        public List<string> TvSeries { get; set; }
        public List<string> PlayedBy { get; set; }

        public Character ToModel()
        { 
            return new Character()
            {
                Url = Url,
                Name = Name,
                Gender = Gender,
                Culture = Culture,
                Born = Born,
                Died = Died,
                Father = Father,
                Mother = Mother,
                Spouse = Spouse,
                Book = string.Join(", ", Books.ToArray()),
                Allegiance = string.Join(", ", Allegiances.ToArray()),
            };
        }
    }
}