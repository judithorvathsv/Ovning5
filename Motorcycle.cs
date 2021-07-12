using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{  
    public class Motorcycle : Vehicle
    {       
        public int Lenght { get; set; }

        public Motorcycle(int lenght, string RegistrationNumber, string Color, int NumberOfWheels) : base(RegistrationNumber, Color, NumberOfWheels)  => Lenght = lenght;    

        public Motorcycle() { }

        public override string ToString() => $"The motorcycle - registration number:  {RegistrationNumber} - with {Lenght} lenght and {Color} color, the number of wheels: {NumberOfWheels}";
        
    }
}