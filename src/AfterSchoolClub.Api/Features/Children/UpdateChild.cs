using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AfterSchoolClub.Api.Features
{
    public class UpdateChild
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Child).NotNull();
                RuleFor(request => request.Child).SetValidator(new ChildValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ChildDto Child { get; set; }
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
                var child = await _context.Children.SingleAsync(x => x.ChildId == request.Child.ChildId);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Child = child.ToDto()
                };
            }
            
        }
    }
}
