using System;
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
            var message =
                $"A encomenda '{Alias}' esta em {update.Local} as {update.DateTime:dd/MM/yyyy - HH:mm:ss} - status: {update.State}";
            return message.Length > 137 ? message.Substring(0, 137) : message;
        }



        internal string GetVoiceMessage(UpdateEntry u)
        {
            return
                $"às {u.DateTime.Hour} horas e {u.DateTime.Minute} minutos, a encomenda {Alias} foi modificada para {u.State}.  ";
        }
    }
}
