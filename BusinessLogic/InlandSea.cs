using PIS_Lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class InlandSea : Sea
    {
        public int countCountries;
        public InlandSea(string _name, double _depth, double _salinity, int _countCountries) : 
            base( _name, _depth, _salinity)
        {
            this.countCountries = _countCountries;
        }
        public override void Print()
        {
            Console.WriteLine($"Море с назанием \"{name}\", глубиной {depth}, " +
                         $"соленостью {salinity} и числом прилегающих стран равным {countCountries} ");
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            InlandSea other = (InlandSea)obj;
            return name == other.name && depth == other.depth && salinity == other.salinity && countCountries == other.countCountries;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() ^ depth.GetHashCode() ^ salinity.GetHashCode();
        }


    }
}
