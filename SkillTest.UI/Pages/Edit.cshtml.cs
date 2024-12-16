using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillTest.UI.Models;
using SkillTest.UI.ProxyContracts;
using SkillTest.UI.ViewModels;

namespace SkillTest.UI.Pages
{
    public class EditModel : PageModel
    {
        private readonly IPeopleServiceProxy _proxy;
        private readonly IMapper _mapper;

        public EditModel(IPeopleServiceProxy proxy, IMapper mapper)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _proxy.UpdatePersonAsync(_mapper.Map<Person>(Person));

            return RedirectToPage("./Index");
        }
    }
}
