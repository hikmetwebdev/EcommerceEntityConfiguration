using Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Classes
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
    public partial class UtcDateTimeService : IDateTimeService
    {
        public DateTime ExecutingTime
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }

}
