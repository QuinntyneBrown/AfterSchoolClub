using System.Net;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AfterSchoolClub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParentController
    {
        private readonly IMediator _mediator;

        public ParentController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{parentId}", Name = "GetParentByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetParentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetParentById.Response>> GetById([FromRoute]GetParentById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Parent == null)
            {
                return new NotFoundObjectResult(request.ParentId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetParentsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetParents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetParents.Response>> Get()
            => await _mediator.Send(new GetParents.Request());
        
        [HttpPost(Name = "CreateParentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateParent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateParent.Response>> Create([FromBody]CreateParent.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetParentsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetParentsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetParentsPage.Response>> Page([FromRoute]GetParentsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateParentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateParent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateParent.Response>> Update([FromBody]UpdateParent.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{parentId}", Name = "RemoveParentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveParent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveParent.Response>> Remove([FromRoute]RemoveParent.Request request)
            => await _mediator.Send(request);
        
    }
}
