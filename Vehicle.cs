using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
 
    public class Vehicle : IVehicle
    {    

        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }

    

        public Vehicle(string registrationNumber, string color, int numberOfWheels) {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;  
        }

        public Vehicle() { }

        public override string ToString() => $"Registration number: {RegistrationNumber}, color: {Color}, number of wheels: {NumberOfWheels}";
      

    }
}
