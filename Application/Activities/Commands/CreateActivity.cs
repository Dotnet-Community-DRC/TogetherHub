using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Command : IRequest<string>
    {
        public required Activity Activity { get; set; }
    }
    
    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            await context.Activities.AddAsync(request.Activity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            // we are returning the id of the activity because we are going to use it in the response, and we don't want to relay on the frontend to generate the id
            return request.Activity.Id; 
        }
    }
}