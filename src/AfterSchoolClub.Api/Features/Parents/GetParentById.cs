using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AfterSchoolClub.Api.Features
{
    public class GetParentById
    {
        public class Request: IRequest<Response>
        {
            public Guid ParentId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ParentDto Parent { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAfterSchoolClubDbContext _context;
        
            public Handler(IAfterSchoolClubDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Parent = (await _context.Parents.SingleOrDefaultAsync(x => x.ParentId == request.ParentId)).ToDto()
                };
            }
            
        }
    }
}
