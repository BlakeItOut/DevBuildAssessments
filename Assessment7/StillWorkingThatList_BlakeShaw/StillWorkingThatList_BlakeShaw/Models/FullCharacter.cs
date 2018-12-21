using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public string GetAllegiances()
        {
            var allegiances = new List<House>();
            foreach (var url in Allegiances)
            {
                var serializer = new JsonSerializer();

                HttpWebRequest characterRequest = WebRequest.CreateHttp(url);

                characterRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

                HttpWebResponse characterResponse = (HttpWebResponse)characterRequest.GetResponse();

                if (characterResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var data = new StreamReader(characterResponse.GetResponseStream()))
                    using (var jsonReader = new JsonTextReader(data))
                    {
                        allegiances.Add(serializer.Deserialize<House>(jsonReader));
                    }

                }
            }
            return string.Join(", ", allegiances.Select(h => h.name).ToArray());
        }

        public string GetBooks()
        {
            var books = new List<Book>();
            foreach (var url in Books)
            {
                var serializer = new JsonSerializer();

                HttpWebRequest characterRequest = WebRequest.CreateHttp(url);

                characterRequest.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

                HttpWebResponse characterResponse = (HttpWebResponse)characterRequest.GetResponse();

                if (characterResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var data = new StreamReader(characterResponse.GetResponseStream()))
                    using (var jsonReader = new JsonTextReader(data))
                    {
                        books.Add(serializer.Deserialize<Book>(jsonReader));
                    }

                }
            }
            return string.Join(", ", books.Select(h => h.name).ToArray());
        }

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
                Book = GetBooks(),
                Allegiance = GetAllegiances(),
            };
        }
    }
}