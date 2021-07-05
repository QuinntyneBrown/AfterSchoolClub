using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AfterSchoolClub.Api.Features
{
    public class GetEvents
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<EventDto> Events { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAfterSchoolClubDbContext _context;
        
            public Handler(IAfterSchoolClubDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Events = await _context.Events.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
