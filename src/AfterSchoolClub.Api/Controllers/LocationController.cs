using System.Net;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AfterSchoolClub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{locationId}", Name = "GetLocationByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetLocationById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetLocationById.Response>> GetById([FromRoute]GetLocationById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Location == null)
            {
                return new NotFoundObjectResult(request.LocationId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetLocationsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetLocations.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetLocations.Response>> Get()
            => await _mediator.Send(new GetLocations.Request());
        
        [HttpPost(Name = "CreateLocationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateLocation.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateLocation.Response>> Create([FromBody]CreateLocation.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetLocationsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetLocationsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetLocationsPage.Response>> Page([FromRoute]GetLocationsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateLocationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateLocation.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateLocation.Response>> Update([FromBody]UpdateLocation.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{locationId}", Name = "RemoveLocationRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveLocation.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveLocation.Response>> Remove([FromRoute]RemoveLocation.Request request)
            => await _mediator.Send(request);
        
    }
}
