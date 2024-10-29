using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities
{
    public class NewsArticle
    {
        public ObjectId Id { get; set; }
        [BsonElement("title")]
        public string? Title { get; set; }
        [BsonElement("content")]
        public string? Content { get; set; }
        [BsonElement("author")]
        public string? Author { get; set; }
        [BsonElement("publishedAt")]
        public DateTime PublishedDate { get; set; }
    }
}