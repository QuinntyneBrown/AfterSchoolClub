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
    public class RemoveChild
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
                var child = await _context.Children.SingleAsync(x => x.ChildId == request.ChildId);
                
                _context.Children.Remove(child);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Child = child.ToDto()
                };
            }
            
        }
    }
}
