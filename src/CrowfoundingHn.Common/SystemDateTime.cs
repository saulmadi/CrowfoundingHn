using System;

namespace CrowfoundingHn.Common
{
    public  static class SystemDateTime
    {
        static Func<DateTime> _now = () => DateTime.Now;

        public static Func<DateTime>Now
        {
            get
            {
                return _now;
            }
            set
            {
                _now = value;
            }
        }
    }
}