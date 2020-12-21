using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Models
{
    public class EventModel : IEventModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public bool IsExclusive { get; set; }
        public int Invitation { get; set; }
        public IList<int> Guests { get; set; } = new List<int>();
    }
}
