using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillTest.Proxy.ProxyContracts;
using SkillTest.UI.Models;

namespace SkillTest.UI.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IPeopleServiceProxy _proxy;
        private readonly IMapper _mapper;

        public DeleteModel(IPeopleServiceProxy proxy, IMapper mapper)
        {
            _proxy = proxy;
            _mapper = mapper;
        }

        [BindProperty]
        public PersonViewModel Person { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Person = _mapper.Map<PersonViewModel>(await _proxy.GetPersonByIdAsync(id));

            if (Person == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Person != null)
            {
                await _proxy.DeletePersonAsync(Person.Id);
            }

            return RedirectToPage("./Index");
        }
    }
}
