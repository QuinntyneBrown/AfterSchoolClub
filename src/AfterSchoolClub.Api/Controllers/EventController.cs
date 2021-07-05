using System.Net;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AfterSchoolClub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{eventId}", Name = "GetEventByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEventById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEventById.Response>> GetById([FromRoute]GetEventById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Event == null)
            {
                return new NotFoundObjectResult(request.EventId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetEventsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEvents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEvents.Response>> Get()
            => await _mediator.Send(new GetEvents.Request());
        
        [HttpPost(Name = "CreateEventRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateEvent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateEvent.Response>> Create([FromBody]CreateEvent.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetEventsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetEventsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetEventsPage.Response>> Page([FromRoute]GetEventsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateEventRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateEvent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateEvent.Response>> Update([FromBody]UpdateEvent.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{eventId}", Name = "RemoveEventRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveEvent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveEvent.Response>> Remove([FromRoute]RemoveEvent.Request request)
            => await _mediator.Send(request);
        
    }
}
