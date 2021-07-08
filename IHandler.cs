using System;

namespace Ovning5
{
    public interface IHandler
    {

        //  int GiveCapacityToGarageFromUI() => throw new NotImplementedException();


        /* STATICBOL SIMAT CSINALTMA A HANDLERBEN  mukodik 07.08.17:32
        static Vehicle[] MakeTheListToArray();
        */


        Vehicle[] MakeTheListToArray();

        void ListTheVehiclesInTheGarage();

        void FindTheCarToSendOutFromTheGarage(Garage<Vehicle> MyVehiclesInGarage);

        void FindVehicleWithRegNUmber(Garage<Vehicle> MyVehiclesInGarage);

        void FindVehicleTypes(Garage<Vehicle> MyVehiclesInGarage);


        void SearcVehicleshByType();
        void SearcVehicleshByColor();
        void SearcVehicleshByWheels();

      


    }
}