using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp
{
    public class Movie
    {
        public class Item
        {
            public bool adult { get; set; }
            public string overview { get; set; }
            public double popularity { get; set; }
            public string poster_path { get; set; }
            public string release_date { get; set; }
            public string title { get; set; }
            public bool video { get; set; }
            public double vote_average { get; set; }
            public int vote_count { get; set; }
        }

        public class Root
        {
            public string created_by { get; set; }
            public string description { get; set; }
            public int favorite_count { get; set; }
            public string id { get; set; }
            public List<Item> items { get; set; }
            public int item_count { get; set; }
            public string iso_639_1 { get; set; }
            public string name { get; set; }
            public string poster_path { get; set; }
        }

    }
}
