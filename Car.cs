using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public class Car : Vehicle
    {
        public string Fueltype { get; set; }

        public Car(string fueltype, string RegistrationNumber, string Color) : base(RegistrationNumber, Color, 4) => Fueltype = fueltype;

        public Car() { }

        public override string ToString() => $"The car - registration number:  {RegistrationNumber} - with {Fueltype} fuel type and {Color} color";         
    }
}
