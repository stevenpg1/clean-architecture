using CleanTeeth.API.DTOs.Dentists;
using CleanTeeth.Application.Features.Dentists.Commands.CreateDentist;
using CleanTeeth.Application.Features.Dentists.Commands.DeleteDentist;
using CleanTeeth.Application.Features.Dentists.Commands.UpdateDentist;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentistDetail;
using CleanTeeth.Application.Features.Dentists.Queries.GetDentistsList;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/dentists")]
    public class DentistsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DentistsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentistDetailDTO>> Get(Guid id)
        {
            var query = new GetDentistDetailQuery { Id = id };
            var result = await mediator.Send(query);
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<DentistsListDTO>> Get()
        {
            var query = new GetDentistsListQuery { };
            var result = await mediator.Send(query);
            return result;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDentistDTO createDentistDTO)
        {
            var command = new CreateDentistCommand(); // { Name = createDentistDTO.Name };
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateDentistDTO updateDentistDTO)
        {
            var command = new UpdateDentistCommand { Id = id }; //, Name = updateDentistDTO.Name
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDentistCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
