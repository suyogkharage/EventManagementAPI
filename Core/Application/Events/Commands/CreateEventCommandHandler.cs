using Domain.Abstractions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events.Commands
{
    internal sealed class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, bool>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandHandler(IMemberRepository memberRepository, IEventRepository gatheringRepository)
        {
            _memberRepository = memberRepository;
            _eventRepository = gatheringRepository;
        }
        public async Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(request.MemberId, cancellationToken);

            if (member == null)
            {
                return false;
            }

            var newEvent = Event.Create(member, request.Type, request.ScheduledAt, request.Name, request.Location, request.MaximumNumberOfAttendees,
                request.InvitationsValidBeforeInHours);

            var isAdded = await _eventRepository.Add(newEvent);

            return isAdded;
        }

        
    }
}
