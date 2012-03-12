using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Carubbi.PackageTracker.BLL
{
    public class PackageEqualityComparer : IEqualityComparer<Package>
    {
        public bool Equals(Package x, Package y)
        {
            return (x.TrackNumber == y.TrackNumber);
        }

        public int GetHashCode(Package obj)
        {
            return  obj.TrackNumber.GetHashCode();
        }

  
    }


    [Serializable]
    public class Package
    {
        [NonSerialized]
        public static PackageEqualityComparer CompararPorTrackNumber = new PackageEqualityComparer();

        public Package()
        {
            Updates = new List<UpdateEntry>();
        }

        public string Alias
        {
            get;
            set;
        }

        public string TrackNumber
        {
            get;
            set;
        }


        public List<UpdateEntry> Updates
        {
            get;
            set;
        }

        public string GetMessage(UpdateEntry update)
        {
            string message = string.Format("A encomenda '{0}' esta em {1} as {2} - status: {3}", Alias, update.Local, update.DateTime.ToString("dd/MM/yyyy - HH:mm:ss"), update.State);
            return message.Length > 137 ? message.Substring(0, 137) : message;
        }



        internal string GetVoiceMessage(UpdateEntry u)
        {
            return string.Format("às {0} horas e {1} minutos, a encomenda {2} foi modificada para {3}.  ", u.DateTime.Hour, u.DateTime.Minute, Alias, u.State);
        }
    }
}
