using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace webApi.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public required List<User> Users { get; set; } = [];
        public required string Title { get; set; }
        public required string Runtime { get; set; }
        public required string Released { get; set; }
        public required string Poster { get; set; }
    }
}