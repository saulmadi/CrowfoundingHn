using System;

namespace CrowfoundingHn.Common
{
    public static class SystemGuid
    {
        public static Func<Guid> New = () => Guid.NewGuid();
    }
}