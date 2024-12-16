using System.Text.Json.Serialization;

namespace SkillTest.Proxy.Models
{
    public class Person
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("randomNumber")]
        public int RandomNumber { get; set; }
    }
}
