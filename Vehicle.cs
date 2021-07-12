using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{ 
    public class Vehicle : IVehicle
    {
        private string registrationNumber;
        private string color;
        private int numberOfWheels;
      
    
        public string RegistrationNumber 
        {
            get => registrationNumber;
            set => registrationNumber = value;
        }
      
        public string Color  
        {
            get => color;
            set => color = value;
        }
       
        public int NumberOfWheels  
        {
            get => numberOfWheels;
            set => numberOfWheels = value;
        }


        public Vehicle(string registrationNumber, string color, int numberOfWheels) {
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;  
        }

        public Vehicle() { }

        public override string ToString() => $"Registration number: {RegistrationNumber}, color: {Color}, number of wheels: {NumberOfWheels}";

    }
}
