using System;

namespace Carubbi.PackageTracker.BLL
{
    [Serializable]
    public class MonitorConfig
    {
       

        public string SmsPassword
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public int Cycle
        {
            get;
            set;
        }
    }
}
