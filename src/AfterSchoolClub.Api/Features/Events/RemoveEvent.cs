using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using AfterSchoolClub.Api.Models;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;

namespace AfterSchoolClub.Api.Features
{
    public class RemoveEvent
    {
        public class Request: IRequest<Response>
        {
            public Guid EventId { get; set; }
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
                var @event = await _context.Events.SingleAsync(x => x.EventId == request.EventId);
                
                _context.Events.Remove(@event);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Event = @event.ToDto()
                };
            }
            
        }
    }
}
