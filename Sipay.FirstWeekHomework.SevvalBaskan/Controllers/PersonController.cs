using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Sipay.FirstWeekHomework.SevvalBaskan.Models;
using Sipay.FirstWeekHomework.SevvalBaskan.Validators;

namespace Sipay.FirstWeekHomework.SevvalBaskan.Controllers
{
	[Route("Sipay/api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
    {
        private readonly IValidator<Person> _validator;

        public PersonController(IValidator<Person> validator)
        {
            _validator = validator;
        }

    }


}


[Route("Sipay/api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{

	public PersonController() { }


	[HttpPost]
	public IActionResult Post([FromBody] Person person)
	{
		PersonValidator validator = new PersonValidator();
		var result = validator.Validate(person);
		if (!result.IsValid)
			return BadRequest();
		return Ok(person);
	}
}

