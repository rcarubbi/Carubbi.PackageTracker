using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
