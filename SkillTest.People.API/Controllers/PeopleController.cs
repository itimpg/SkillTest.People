using Microsoft.AspNetCore.Mvc;
using SkillTest.Core.DTOs;
using SkillTest.Core.ServiceContracts;

namespace SkillTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _peopleService.GetAllPeople());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            PersonResponse? response = await _peopleService.GetPerson(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonCreateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid people data");
            }

            PersonResponse? response = await _peopleService.CreatePerson(request);
            if (response != null)
            {
                return Created($"api/people/{response.Id}", response);
            }

            return Problem("Error in adding people");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(PersonUpdateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid people data");
            }

            PersonResponse? response = await _peopleService.UpdatePerson(request);
            if (response != null)
            {
                return Ok(response);
            }

            return Problem("Error in updating people");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid Id");
            }

            bool isDeleted = await _peopleService.DeletePerson(id);
            if (isDeleted)
            {
                return Ok();
            }

            return Problem("Error in deleting people");
        }
    }
}
