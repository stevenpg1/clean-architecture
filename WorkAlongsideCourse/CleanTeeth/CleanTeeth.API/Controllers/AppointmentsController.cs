using CleanTeeth.API.DTOs.Appointments;
using CleanTeeth.Application.Features.Appointments.Commands.CreateAppointment;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentDetail;
using CleanTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;
using CleanTeeth.Application.Features.Appointments.Queries.GetAppointmentsList;
using CleanTeeth.Application.Features.Appointments.Commands.UpdateAppointment;
using CleanTeeth.Application.Features.Appointments.Commands.CancelAppointment;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/appointments")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDetailDTO>> Get(Guid id)
        {
            var query = new GetAppointmentDetailQuery { Id = id };
            var result = await mediator.Send(query);
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<AppointmentsListDTO>> Get([FromQuery] GetAppointmentsListQuery query)
        {
            var result = await mediator.Send(query);
            return result;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAppointmentDTO createAppointmentDTO)
        {
            var command = new CreateAppointmentCommand
            { 
                PatientId = createAppointmentDTO.PatientId,
                DentistId = createAppointmentDTO.DentistId,
                DentalOfficeId = createAppointmentDTO.DentalOfficeId,
                StartDate = createAppointmentDTO.StartDate,
                EndDate = createAppointmentDTO.EndDate
            };
            await mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateAppointmentDTO updateAppointmentDTO)
        {
            var command = new UpdateAppointmentCommand { Id = id }; //, Name = updateAppointmentDTO.Name
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new CancelAppointmentCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
