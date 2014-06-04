using System;

namespace CrowfoundingHn.Common.Authentication
{
    [Serializable]
    public class MissingUserFieldException : Exception
    {
        public MissingUserFieldException(string field)
            : base(string.Format("The following field {0} is necesary to create a new user profile", field))
        {
        }
    }
}