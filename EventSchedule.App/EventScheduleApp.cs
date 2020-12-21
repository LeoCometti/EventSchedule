using EventSchedule.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App
{
    public static class EventScheduleApp
    {
        private static AppService eventService;

        public static IAppService Initialize()
        {
            return eventService = new AppService();
        }
    }
}
