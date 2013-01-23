using System;

namespace Facebook.Business.Domain.Facade
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}