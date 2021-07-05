using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Models;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;

namespace AfterSchoolClub.Api.Features
{
    public class CreateChild
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
                var child = new Child();
                
                _context.Children.Add(child);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Child = child.ToDto()
                };
            }
            
        }
    }
}
