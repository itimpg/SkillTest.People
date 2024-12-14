using System.ComponentModel.DataAnnotations;

namespace SkillTest.Core.Entities
{
    public class People
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RandomNumber { get; set; }
        public bool Active { get; set; }
    }
}
