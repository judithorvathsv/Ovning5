using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
    public class Airplane : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Airplane(int numberOfEngines, string RegistrationNumber, string Color) : base(RegistrationNumber, Color, 0) => NumberOfEngines = numberOfEngines;  

        public Airplane()   {   }

        public override string ToString() => $"The airplane - registration number:  {RegistrationNumber} - with {NumberOfEngines} engines and {Color} color";    

    }
}
