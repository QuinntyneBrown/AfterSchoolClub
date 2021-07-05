using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AfterSchoolClub.Api.Extensions;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;
using AfterSchoolClub.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AfterSchoolClub.Api.Features
{
    public class GetEventsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<EventDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAfterSchoolClubDbContext _context;
        
            public Handler(IAfterSchoolClubDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from @event in _context.Events
                    select @event;
                
                var length = await _context.Events.CountAsync();
                
                var events = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = events
                };
            }
            
        }
    }
}
