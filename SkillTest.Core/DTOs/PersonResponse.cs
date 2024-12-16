namespace SkillTest.Core.DTOs
{
    public record PersonResponse(Guid Id, string FirstName, string LastName, int RandomNumber, bool Active)
    {
        public PersonResponse() : this(default, default, default, default, default) { }
    }
}