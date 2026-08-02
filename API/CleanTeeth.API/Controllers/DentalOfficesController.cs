using CleanTeeth.API.DTOs.DentalOffices;
using CleenTeeth.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using CleenTeeth.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using CleenTeeth.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using CleenTeeth.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using CleenTeeth.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CleanTeeth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DentalOfficesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<DentalOfficeDetailDTO>> Get(Guid id)
        {
            var query = new GetDentalOfficeDetailQuery{ Id = id };
            var result = await mediator.Send(query);

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDentalOfficeDTO createDentalOfficeDTO)
        {
            var command = new CreateDentalOfficeCommand { Name = createDentalOfficeDTO.Name };
            await mediator.Send(command);
            
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<DentalOfficesListDTO>>> List()
        {
            var query = new GetDentalOfficesListQuery();
            var result = await mediator.Send(query);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateDentalOfficeDTO updateDentalOfficeDTO)
        {
            var command = new UpdateDentalOfficeCommand { Id = id, Name = updateDentalOfficeDTO.Name };
            await mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteDentalOfficeCommand { Id = id };
            await mediator.Send(command);

            return NoContent();
        }
    }
}
