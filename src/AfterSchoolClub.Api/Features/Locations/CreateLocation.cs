using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AfterSchoolClub.Api.Models;
using AfterSchoolClub.Api.Core;
using AfterSchoolClub.Api.Interfaces;

namespace AfterSchoolClub.Api.Features
{
    public class CreateLocation
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Location).NotNull();
                RuleFor(request => request.Location).SetValidator(new LocationValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public LocationDto Location { get; set; }
        }

        public class Response: ResponseBase
        {
            public LocationDto Location { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAfterSchoolClubDbContext _context;
        
            public Handler(IAfterSchoolClubDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var location = new Location();
                
                _context.Locations.Add(location);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Location = location.ToDto()
                };
            }
            
        }
    }
}
