using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace VoltGearSystems.Models
{
    public class Laptop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BindNever]
        public string? ID { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be positive")]
        public int Price { get; set; }

    }
}