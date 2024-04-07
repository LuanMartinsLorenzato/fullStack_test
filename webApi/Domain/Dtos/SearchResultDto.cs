using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using webApi.Domain.Entities;

namespace webApi.Domain.Dtos
{
    public record SearchResultDto
    {
        [JsonPropertyName("Search")]
        public IEnumerable<Movie>? Search { get; set; }
    }
}