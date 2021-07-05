using System.Net;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AfterSchoolClub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChildController
    {
        private readonly IMediator _mediator;

        public ChildController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{childId}", Name = "GetChildByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetChildById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetChildById.Response>> GetById([FromRoute]GetChildById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Child == null)
            {
                return new NotFoundObjectResult(request.ChildId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetChildrenRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetChildren.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetChildren.Response>> Get()
            => await _mediator.Send(new GetChildren.Request());
        
        [HttpPost(Name = "CreateChildRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateChild.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateChild.Response>> Create([FromBody]CreateChild.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetChildrenPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetChildrenPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetChildrenPage.Response>> Page([FromRoute]GetChildrenPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateChildRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateChild.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateChild.Response>> Update([FromBody]UpdateChild.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{childId}", Name = "RemoveChildRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveChild.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveChild.Response>> Remove([FromRoute]RemoveChild.Request request)
            => await _mediator.Send(request);
        
    }
}
