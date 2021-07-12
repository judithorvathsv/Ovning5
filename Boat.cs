using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{  
    public class Boat : Vehicle
    {      
        public int CylinderVolume { get; set; }

        public Boat(int cylinderVolume, string RegistrationNumber, string Color) : base(RegistrationNumber, Color, 0) => CylinderVolume = cylinderVolume;   

        public Boat() { }

        public override string ToString() => $"The boat - registration number:  {RegistrationNumber} - with {CylinderVolume} cylinder volume and {Color} color";   

    }
}
