using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;

namespace famcook.Models
{
    public class Recipe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("RecipeName")]
        public string RecipeName { get; set; }

        [BsonElement("PrepTime")]
        public string PrepTime { get; set; }

        [BsonElement("FoodCat")]
        public string FoodCat { get; set; }

        [BsonElement("Ingredients")]
        public List<string> Ingredients { get; set; }

        [BsonElement("Instruction")]
        public List<string> Instructions { get; set; }

        [BsonElement("ImageName")]
        public string ImageName { get; set; }

        [BsonElement("TimeSubmitted")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime TimeSubmitted { get; set; }
    }
}
