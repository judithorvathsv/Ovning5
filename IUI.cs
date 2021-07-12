using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
  public  interface IUI
    {
     
        int CapacityIntInput { get; set; }


        void Menu();    


        string AskSendOutAVehicleFromTheGarage();

        string SearchedType();
        string SearchedColor();    
        string SearchedWheels();

        string CorrectInput();
       
    }
}
