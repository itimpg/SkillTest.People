using System.ComponentModel.DataAnnotations;

namespace SkillTest.UI.ViewModels
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        public bool Active { get; set; }

        public int RandomNumber { get; set; }
    }
}
