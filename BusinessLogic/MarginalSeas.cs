using PIS_Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MarginalSeas : Sea
    {
        public bool portАvailability;

        public MarginalSeas( string _name, double _depth, double _salinity, bool _portАvailability) : 
            base( _name, _depth, _salinity)
        {
            this.portАvailability = _portАvailability;
        }
        public override void Print()
        {
            Console.WriteLine($"Море с назанием \"{name}\", глубиной {depth}, " +
                             $"соленостью {salinity} и наличием международного порта: {portАvailability}");
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            MarginalSeas other = (MarginalSeas)obj;
            return name == other.name && depth == other.depth && salinity == other.salinity && portАvailability == other.portАvailability;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ depth.GetHashCode() ^ salinity.GetHashCode() ^ portАvailability.GetHashCode();
        }
    }
}
