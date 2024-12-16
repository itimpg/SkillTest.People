using Microsoft.AspNetCore.Mvc.RazorPages;
using SkillTest.Proxy.Models;
using SkillTest.Proxy.ProxyContracts;

namespace SkillTest.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPeopleServiceProxy _proxy;

        public IndexModel(IPeopleServiceProxy proxy)
        {
            _proxy = proxy;
        }

        public IList<Person> Persons { get; set; }

        public async Task OnGetAsync()
        {
            Persons = await _proxy.GetAllPeopleAsync();
        }
    }
}