using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Services
{
    public interface ITableService
    {
        string TableName { get; }

        string CmdCreateTable { get; }
    }
}
