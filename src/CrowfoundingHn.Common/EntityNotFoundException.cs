using System;

namespace CrowfoundingHn.Common
{
    public class EntityNotFoundException<T> : Exception
    {
        public EntityNotFoundException()
            : base(string.Format("The  {0} could not be found", typeof(T).Name))

        {
        }
    }
}