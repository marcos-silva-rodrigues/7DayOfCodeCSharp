﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Day4.Model
{
    public class Pokemon
    {
        [property: JsonPropertyName("name")]
        public string Name { get; set; }

        [property: JsonPropertyName("weight")]
        public int Weight { get; set; }

        [property: JsonPropertyName("height")]
        public int Height { get; set; }
    }
}
