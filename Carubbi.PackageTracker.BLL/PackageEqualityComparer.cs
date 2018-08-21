using System.Collections.Generic;

namespace Carubbi.PackageTracker.BLL
{
    public class PackageEqualityComparer : IEqualityComparer<Package>
    {
        public bool Equals(Package x, Package y)
        {
            return y != null && (x != null && (x.TrackNumber == y.TrackNumber));
        }

        public int GetHashCode(Package obj)
        {
            return obj.TrackNumber.GetHashCode();
        }
    }
}
