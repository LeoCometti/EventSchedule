using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Models
{
    public interface IInvitationModel
    {
        int Id { get; set; }
        int UserId { get; set; }
        int Invitation { get; set; }
        DateTime Date { get; set; }
        int GuestId { get; set; }
        int Status { get; set; }
    }
}
