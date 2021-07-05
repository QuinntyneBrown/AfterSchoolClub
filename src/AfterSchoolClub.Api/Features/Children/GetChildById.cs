using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AfterSchoolClub.Api.Features
{
    public class GetChildById
    {
        public class Request: IRequest<Response>
        {
            public Guid ChildId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ChildDto Child { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAfterSchoolClubDbContext _context;
        
            public Handler(IAfterSchoolClubDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Child = (await _context.Children.SingleOrDefaultAsync(x => x.ChildId == request.ChildId)).ToDto()
                };
            }
            
        }
    }
}
