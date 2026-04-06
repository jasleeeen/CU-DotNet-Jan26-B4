using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBFirstSerilog.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? AuthorId { get; set; }

    [JsonIgnore]
    public virtual Author? Author { get; set; }
}
