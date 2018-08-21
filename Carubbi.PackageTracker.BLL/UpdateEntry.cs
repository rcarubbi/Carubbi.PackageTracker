using System;

namespace Carubbi.PackageTracker.BLL
{
    [Serializable]
    public class UpdateEntry
    {
        public DateTime DateTime
        {
            get;
            set;
        }

        public string Local
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }
    }
}
