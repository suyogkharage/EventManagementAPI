using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.DTOs
{
    public class EventDto
    {
        public int MemberId { get; private set; }

        public EventType Type { get; private set; }

        public string Name { get; private set; }

        public DateTime ScheduledAtUtc { get; private set; }

        public string? Location { get; private set; }

        public int? MaximumNumberOfAttendees { get; private set; }

        public int? InvitationsValidBeforeInHours { get; private set; }
    }
}
