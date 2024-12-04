using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PIS_Lab1
{
    public class Sea
    {
        public string name;
        public double depth;
        public double salinity;

        public virtual void Print()
        {
            Console.WriteLine($"Море с назанием \"{name}\", глубиной {depth}, " +
                          $"соленостью {salinity} ");
        }
        public Sea( string _name, double _depth, double _salinity)
        {
            this.name = _name;
            this.depth = _depth;
            this.salinity = _salinity;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Sea other = (Sea)obj;
            return name == other.name && depth == other.depth && salinity == other.salinity;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ depth.GetHashCode() ^ salinity.GetHashCode();
        }
    }
}
