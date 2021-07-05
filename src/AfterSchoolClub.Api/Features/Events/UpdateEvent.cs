using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AfterSchoolClub.Api.Features
{
    public class UpdateEvent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Event).NotNull();
                RuleFor(request => request.Event).SetValidator(new EventValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public EventDto Event { get; set; }
        }

        public class Response: ResponseBase
        {
            public EventDto Event { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAfterSchoolClubDbContext _context;
        
            public Handler(IAfterSchoolClubDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var @event = await _context.Events.SingleAsync(x => x.EventId == request.Event.EventId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Event = @event.ToDto()
                };
            }
            
        }
    }
}
