using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Services
{
    public interface ISqlService
    {
        bool Create(string procedure);

        bool Read(string procedure);

        bool Update(string procedure);

        bool Delete(string procedure);
    }
}
