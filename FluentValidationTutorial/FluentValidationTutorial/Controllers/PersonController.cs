using FluentValidation;
using FluentValidationTutorial.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IValidator<Person> validation;

        public PersonController(IValidator<Person> validation)
        {
            this.validation = validation;
        }

        [HttpPost("createperson")]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            var result = await this.validation.ValidateAsync(person);

            if (!result.IsValid)
            {
                return BadRequest(result.ToDictionary());
            }

            return Ok("Person created successfully!");
        }
    }
}
