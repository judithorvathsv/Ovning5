using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public class ListComparerColor : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {        
            return x.Color == y.Color;
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.Color.GetHashCode();

        }
    }


    public class ListComparerWheel : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {
            return x.NumberOfWheels == y.NumberOfWheels;
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.NumberOfWheels.GetHashCode();

        }
    }

    public class ListComparerType : IEqualityComparer<Vehicle>
    {
        public bool Equals(Vehicle x, Vehicle y)
        {
            return x.GetType().Name == y.GetType().Name;
        }

        public int GetHashCode(Vehicle obj)
        {
            return obj.GetType().Name.GetHashCode();

        }
    }




}
