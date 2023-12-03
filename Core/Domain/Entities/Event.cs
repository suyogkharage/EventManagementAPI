using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event
    {
        private readonly List<Invitation> _invitations = new();
        private readonly List<Attendee> _attendees = new();

        private Event(
            //int id,
            Member creator,
            EventType type,
            DateTime scheduledAtUtc,
            string name,
            string? location)
        {
            //Id = id;
            Creator = creator;
            Type = type;
            ScheduledAtUtc = scheduledAtUtc;
            Name = name;
            Location = location;
        }

        public int Id { get; private set; }

        public Member Creator { get; private set; }

        public EventType Type { get; private set; }

        public string Name { get; private set; }

        public DateTime ScheduledAtUtc { get; private set; }

        public string? Location { get; private set; }

        public int? MaximumNumberOfAttendees { get; private set; }

        public DateTime? InvitationsExpireAtUtc { get; private set; }

        public int NumberOfAttendees { get; private set; }

        public IReadOnlyCollection<Attendee> Attendees => _attendees;

        public IReadOnlyCollection<Invitation> Invitations => _invitations;

        public static Event Create(
            //Guid id,
            Member creator,
            EventType type,
            DateTime scheduledAt,
            string name,
            string? location,
            int? maximumNumberOfAttendees,
            int? invitationsValidBeforeInHours)
        {
            // Create gathering
            var newEvent = new Event(
                //Guid.NewGuid(),
                creator,
                type,
                scheduledAt,
                name,
                location);

            // Calculate gathering type details
            switch (newEvent.Type)
            {
                case EventType.WithFixedNumberOfAttendees:
                    if (maximumNumberOfAttendees is null)
                    {
                        throw new Exception(
                            $"{nameof(maximumNumberOfAttendees)} can't be null.");
                    }

                    newEvent.MaximumNumberOfAttendees = maximumNumberOfAttendees;
                    break;
                case EventType.WithExpirationForInvitation:
                    if (invitationsValidBeforeInHours is null)
                    {
                        throw new Exception(
                            $"{nameof(invitationsValidBeforeInHours)} can't be null.");
                    }

                    newEvent.InvitationsExpireAtUtc =
                        newEvent.ScheduledAtUtc.AddHours(-invitationsValidBeforeInHours.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(EventType));
            }

            return newEvent;
        }

        public Invitation SendInvitation(Member member)
        {
            // Validate
            if (Creator.MemberId == member.MemberId)
            {
                throw new Exception("Can't send invitation to the gathering creator.");
            }

            if (ScheduledAtUtc < DateTime.UtcNow)
            {
                throw new Exception("Can't send invitation for gathering in the past.");
            }

            var invitation = new Invitation(member, this);

            _invitations.Add(invitation);

            return invitation;
        }

        public Attendee? AcceptInvitation(Invitation invitation)
        {
            // Check if expired
            var expired = (Type == EventType.WithFixedNumberOfAttendees &&
                           NumberOfAttendees == MaximumNumberOfAttendees) ||
                          (Type == EventType.WithExpirationForInvitation &&
                           InvitationsExpireAtUtc < DateTime.UtcNow);
            if (expired)
            {
                invitation.Expire();

                return null;
            }

            var attendee = invitation.Accept();

            _attendees.Add(attendee);
            NumberOfAttendees++;

            return attendee;
        }

    }
}
