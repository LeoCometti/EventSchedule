using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Models
{
    public interface IUserModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        string Email { get; set; }
    }
}
