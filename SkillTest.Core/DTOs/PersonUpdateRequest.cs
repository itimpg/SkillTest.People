namespace SkillTest.Core.DTOs
{
    public record PersonUpdateRequest(Guid Id, string FirstName, string LastName, bool Active)
    {
        public PersonUpdateRequest() : this(default, default, default, default) { }
    }
}
