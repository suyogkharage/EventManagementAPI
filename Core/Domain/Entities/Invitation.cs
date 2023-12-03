using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invitation
    {
        internal Invitation(Member member, Event newEvent) 
        {
            MemberId = member.MemberId;
            EventId = newEvent.Id;
            Status = InvitationStatus.Pending;
            CreatedOn = DateTime.Now;
        }
        public int Id { get; private set; }

        public int EventId { get; private set; }

        public int MemberId { get; private set; }

        public InvitationStatus Status { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        internal Attendee Accept()
        {
            Status = InvitationStatus.Accepted;
            ModifiedOn = DateTime.Now;

            var attendee = new Attendee(this);

            return attendee;
        }

        internal void Expire()
        {
            Status = InvitationStatus.Expired;
            ModifiedOn = DateTime.Now;
        }


    }
}
