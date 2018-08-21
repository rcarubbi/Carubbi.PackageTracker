using System.Collections.Generic;

namespace Carubbi.PackageTracker.BLL
{
    public class UpdateComparer : IComparer<UpdateEntry>
    {
        #region IComparer<UpdateEntry> Members

        public int Compare(UpdateEntry x, UpdateEntry y)
        {
            if (y != null && (x != null && x.DateTime > y.DateTime))
                return 1;
            if (y != null && (x != null && x.DateTime < y.DateTime))
                return -1;
            return 0;
        }

        #endregion
    }
}
