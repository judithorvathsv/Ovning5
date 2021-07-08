using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5
{
  public  interface IUI
    {


        static List<Vehicle> VehicleList { get; set; } = new List<Vehicle>();
        int capacityIntInput { get; set; }

        void Menu();


   

        Vehicle AddVehicleInTheGarage();
        void AskBasicInformation();
        void AskRegistrationNumber();
        void AskColor();

        void ListOutTheVehiclesInTheGarage();

        void SendOutCarFormGarage();

        void SearchForVehicle();

        void GetVehicleByRegNumber();

        void VehicleTypesWithNumberOfVehicles();


        static string AskSendOutAVehicleFromTheGarage() => throw new NotImplementedException();

        string SearchedType();
        string SearchedColor();
        int SearchedWheels();


        string CorrectInput();






    }
}
