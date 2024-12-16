using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillTest.Proxy.Models;
using SkillTest.Proxy.ProxyContracts;
using SkillTest.UI.Models;

namespace SkillTest.UI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IPeopleServiceProxy _proxy;
        private readonly IMapper _mapper;

        public CreateModel(IPeopleServiceProxy proxy, IMapper mapper)
        {
            _proxy = proxy;
            _mapper = mapper;
        }

        [BindProperty]
        public PersonViewModel Person { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _proxy.CreatePersonAsync(_mapper.Map<Person>(Person));

            return RedirectToPage("./Index");
        }
    }
}
