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
    public class GetParents
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<ParentDto> Parents { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAfterSchoolClubDbContext _context;
        
            public Handler(IAfterSchoolClubDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Parents = await _context.Parents.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
