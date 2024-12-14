namespace SkillTest.Core.DTOs
{
    public record PersonCreateRequest(string FirstName, string LastName, bool Active)
    {
        public PersonCreateRequest() : this(default, default, default) { }
    }
}
