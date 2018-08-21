using System;

namespace Carubbi.PackageTracker.BLL
{
    public class NotifyUpdateEventArgs : EventArgs
    {
        public UpdateEntry Update
        {
            get;
            set;
        }

        public Package Package
        {
            get;
            set;
        }

    }
}
