using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Sample.ViewModels;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpPost("Person")]
        public IActionResult Post([FromBody] PersonViewModel value)
        {
            if (ModelState.IsValid)
                return Ok();
            return BadRequest(ModelState);
        }

        [HttpPost("PersonRule")]
        public IActionResult PostRule(
            [CustomizeValidator(RuleSet = Validators.PersonValidator.ValidaNumeriTelefono)]
            [FromBody] PersonViewModel value)
        {
            if (ModelState.IsValid)
                return Ok();
            return BadRequest(ModelState);
        }

        [HttpPost("Address")]
        public IActionResult Post([FromBody] AddressViewModel value)
        {
            if(ModelState.IsValid)
                return Ok();
            return BadRequest(ModelState);
        }
    }
}
