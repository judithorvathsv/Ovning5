using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{ 
    public class Bus : Vehicle
    {      
        public int NumberOfSeats { get; set; }

        public Bus(int numberOfSeats, string RegistrationNumber, string Color) : base(RegistrationNumber, Color, 6) => NumberOfSeats = numberOfSeats;  

        public Bus() { }

        public override string ToString() => $"The bus - registration number:  {RegistrationNumber} - with {NumberOfSeats} seats and {Color} color";

    }
}
