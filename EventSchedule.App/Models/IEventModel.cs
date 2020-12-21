using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Models
{
    public interface IEventModel
    {
        int Id { get; set; }
        int UserId { get; set; }
        string Description { get; set; }
        DateTime Date { get; set; }
        string Location { get; set; }
        bool IsExclusive { get; set; }
        int Invitation { get; set; }
        IList<int> Guests { get; set; }
    }
}
