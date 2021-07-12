using System;
using System.Collections.Generic;

namespace Ovning5
{
    public interface IHandler
    {
        bool CheckCapacityInTheGarageSendingToUI();
        IVehicle[] MakeTheListToArray();       

        void ListTheVehiclesInTheGarage();   
    
      
        List<IVehicle> FindTheCarToSendOutFromTheGarage(Garage<IVehicle> MyVehiclesInGarage);

        void FindVehicleWithRegNUmber(Garage<IVehicle> MyVehiclesInGarage);

        void FindVehicleTypes(Garage<IVehicle> MyVehiclesInGarage);



        List<IVehicle> ListtypeAndColorAndWheel();
        List<IVehicle> ListtypeAndWheelAndColor();
        List<IVehicle> ListcolorAndTypeAndWheels();
        List<IVehicle> ListcolorAndWheelAndType();
        List<IVehicle> ListwheelAndTypeAndColor();
        List<IVehicle> ListwheelAndColorAndType();            

    }
}