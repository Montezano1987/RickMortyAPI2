﻿using System.Text.Json.Serialization;

namespace RickMortyAPI2.Entidades
{
    public class Info
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        [JsonPropertyName("next")]
        public string Next { get; set; }

        [JsonPropertyName("prev")]
        public string Prev { get; set; }
    }
}
