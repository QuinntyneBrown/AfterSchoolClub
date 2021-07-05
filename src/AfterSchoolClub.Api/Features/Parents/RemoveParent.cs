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
    public class RemoveParent
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
                var parent = await _context.Parents.SingleAsync(x => x.ParentId == request.ParentId);
                
                _context.Parents.Remove(parent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Parent = parent.ToDto()
                };
            }
            
        }
    }
}
