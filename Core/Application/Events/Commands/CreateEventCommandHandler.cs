using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events.Commands
{
    internal sealed class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        public Task Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
