using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Models;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;

namespace AfterSchoolClub.Api.Features
{
    public class CreateParent
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Parent).NotNull();
                RuleFor(request => request.Parent).SetValidator(new ParentValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ParentDto Parent { get; set; }
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
                var parent = new Parent();
                
                _context.Parents.Add(parent);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Parent = parent.ToDto()
                };
            }
            
        }
    }
}
