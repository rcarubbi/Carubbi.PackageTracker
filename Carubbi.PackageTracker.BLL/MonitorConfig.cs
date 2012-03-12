using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.PackageTracker.BLL
{
    [Serializable]
    public class MonitorConfig
    {
        internal void ValidateProxy()
        {
            if (string.IsNullOrEmpty(ProxyUserName) || string.IsNullOrEmpty(ProxyPassword) || string.IsNullOrEmpty(ProxyDomain))
                throw new ApplicationException("Preencha as configurações de proxy");
        }


        public string ProxyUserName
        {
            get;
            set;
        }

        public string ProxyPassword
        {
            get;
            set;
        }

        public string ProxyDomain
        {
            get;
            set;
        }

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
