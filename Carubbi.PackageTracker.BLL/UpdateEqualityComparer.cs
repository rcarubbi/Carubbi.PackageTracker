using System.Collections.Generic;

namespace Carubbi.PackageTracker.BLL
{
    public class UpdateEqualityComparer : IEqualityComparer<UpdateEntry>
    {
        #region IEqualityComparer<UpdateEntry> Members

        public bool Equals(UpdateEntry x, UpdateEntry y)
        {
            return y != null && (x != null && x.DateTime == y.DateTime);
        }

        public int GetHashCode(UpdateEntry obj)
        {
            return obj.DateTime.GetHashCode();
        }

        #endregion
    }
}
