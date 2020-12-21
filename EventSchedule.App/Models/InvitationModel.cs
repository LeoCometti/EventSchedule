using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Models
{
    public class InvitationModel : IInvitationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Invitation { get; set; }
        public DateTime Date { get; set; }
        public int GuestId { get; set; }
        public int Status { get; set; }
    }
}
