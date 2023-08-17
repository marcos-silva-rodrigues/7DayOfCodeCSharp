using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Day1.Model
{
    public class ResponseSchema<T>
    {
        [property: JsonPropertyName("count")]
        public int? Count { get; set; }

        [property: JsonPropertyName("next")]
        public string? Next { get; set; }

        [property: JsonPropertyName("previous")]
        public string? Previous { get; set; }

        [property: JsonPropertyName("results")]
        public List<T> Results { get; set; }
    }
}
