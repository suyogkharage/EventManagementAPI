using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events.Commands
{
    public sealed record CreateEventCommand (
        int MemberId,
        EventType Type,
        DateTime ScheduledAt,
        string Name,
        string? Location,
        int? MaximumNumberOfAttendees,
        int? InvitationsValidBeforeInHours
        ) : IRequest<bool>;
}
