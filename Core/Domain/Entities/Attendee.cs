using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attendee
    {
        public Attendee(Invitation invitation)
        {
            EventId = invitation.EventId;
            MemberId = invitation.MemberId;
            CreatedOn = DateTime.Now;
        }

        public int EventId{ get; set; }
        public int MemberId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
