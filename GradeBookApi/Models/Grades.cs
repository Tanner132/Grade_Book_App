using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GradeBookApi.Models
{
    public class Grades
    {
            [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Grade { get; set; }

        public string Subject { get; set; }

        public string Date { get; set; }

        public string Status { get; set; }
    }
}
