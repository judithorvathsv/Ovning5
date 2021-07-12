using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Dynamic;


namespace Ovning5
{ 
    public class Handler : IHandler
    {
        public static List<IVehicle> VehicleList = new();    


        public bool CheckCapacityInTheGarageSendingToUI()
        {
            Console.WriteLine("Garage occupied places: " + Garage<IVehicle>.MyVehiclesInGarage.Length);
            Console.WriteLine("Garage all places: " + Garage<IVehicle>.Capacity);

            Garage<IVehicle>.CountFreePlacesInTheGarage();
            if (Garage<IVehicle>.CountFreePlacesInTheGarage() <= 0)
            {
                Console.WriteLine("Garage is FULL. ");
                return true;
            }
            else
            {
                Console.WriteLine($"Free places: {Garage<IVehicle>.CountFreePlacesInTheGarage()} ");
                return false;
            }
        }


        //UI VehicleList after adding items should be changed to array for Garage:
        public IVehicle[] MakeTheListToArray()
        {
            IVehicle[] handlerVehiclesArray = VehicleList.ToArray();
            return handlerVehiclesArray;
        }


        //Get array of vehicles from Garage then list out the those:       
        public void ListTheVehiclesInTheGarage()
        {
            foreach (IVehicle item in Garage<IVehicle>.MyVehiclesInGarage)
                Console.WriteLine(item);
        }


        //Search in the Garage array to find the vehicle that we would be send out, delete vehicle:
        public List<IVehicle> FindTheCarToSendOutFromTheGarage(Garage<IVehicle> MyVehiclesInGarage)
        {
            IUI ui = new UI();
            string deletableRegNumber = ui.AskSendOutAVehicleFromTheGarage();
            var deletingCar = MyVehiclesInGarage.Where(c => c.RegistrationNumber.Equals(deletableRegNumber)).ToList();

            foreach (var item in deletingCar)
                VehicleList.Remove(item);
            return deletingCar;
        }


        //Find a vehicle by registration number:
        public void FindVehicleWithRegNUmber(Garage<IVehicle> MyVehiclesInGarage)
        {
            IUI ui = new UI();
            string SearchForRegNumber = ui.AskSendOutAVehicleFromTheGarage();
            var searchedVehicle = MyVehiclesInGarage.Where(c => c.RegistrationNumber.Equals(SearchForRegNumber)).ToList();

            foreach (var item in searchedVehicle)
                Console.WriteLine(item);
        }


        //Search for all types and how many are in the garage:
        public void FindVehicleTypes(Garage<IVehicle> MyVehiclesInGarage)
        {
            var allVehicles = from v in MyVehiclesInGarage
                              group v by v.GetType().Name into garage
                              select new { Type = garage.Key, Number = garage.Count() };

            foreach (var item in allVehicles)
                Console.WriteLine(item.ToString().Substring(2, item.ToString().Length - 3));
        }


        //filtering vehicles by wheel:
        private List<IVehicle> FindVehicleByWheels(Garage<IVehicle> MyVehiclesInGarage)
        {
            IUI ui = new UI();
            string wheels = ui.SearchedWheels();
            int intWheel;
            bool IsIntWheel = int.TryParse(wheels, out intWheel);

            if (IsIntWheel && (intWheel > 0))
                return MyVehiclesInGarage.Select(g => g).Where(v => v.NumberOfWheels.Equals(intWheel)).ToList();

            else if (IsIntWheel && (intWheel == 0))
                return MyVehiclesInGarage.Select(g => g).Where(v => v.NumberOfWheels.Equals(0)).ToList();

            else return MyVehiclesInGarage.Select(g => g).ToList();
        }


        //filtering vehicles by color:
        private List<IVehicle> FindVehicleByColor(Garage<IVehicle> MyVehiclesInGarage)
        {
            List<IVehicle> findColor;
            IUI ui = new UI();
            string color = ui.SearchedColor();
            if (!color.Equals("c") && !color.Equals("C"))
                findColor = MyVehiclesInGarage.Select(g => g).Where(v => v.Color.Equals(color)).ToList();
            else
                findColor = MyVehiclesInGarage.Select(g => g).ToList();
            return findColor;
        }

        //filtering vehicles by type:
        private List<IVehicle> FindVehicleByType(Garage<IVehicle> MyVehiclesInGarage)
        {
            List<IVehicle> findType;
            IUI ui = new UI();
            string type = ui.SearchedType();
            if (!type.Equals("v") && !type.Equals("V"))
                findType = MyVehiclesInGarage.Select(g => g).Where(v => v.GetType().Name.Equals(type, StringComparison.InvariantCultureIgnoreCase)).ToList();
            else
                findType = MyVehiclesInGarage.Select(g => g).ToList();
            return findType;
        }


        //give vehicle list according to type->color->wheel
        public List<IVehicle> ListtypeAndColorAndWheel()
        {
            Garage<IVehicle> gar = new();
            var typeAndColorAndWheel = FindVehicleByType(gar).ToList()
                        .Intersect(FindVehicleByColor(gar).ToList())
                        .Intersect(FindVehicleByWheels(gar).ToList()).ToList();
            return typeAndColorAndWheel;
        }


        //give vehicle list according to type->wheel->color
        public List<IVehicle> ListtypeAndWheelAndColor()
        {
            Garage<IVehicle> gar = new();
            var typeAndWheelAndColor = FindVehicleByType(gar).ToList()
                         .Intersect(FindVehicleByWheels(gar).ToList())
                         .Intersect(FindVehicleByColor(gar).ToList()).ToList();
            return typeAndWheelAndColor;
        }


        //give vehicle list according to color->type->wheel
        public List<IVehicle> ListcolorAndTypeAndWheels()
        {
            Garage<IVehicle> gar = new();
            var colorAndTypeAndWheels = FindVehicleByColor(gar).ToList()
                        .Intersect(FindVehicleByType(gar).ToList())
                        .Intersect(FindVehicleByWheels(gar).ToList()).ToList();
            return colorAndTypeAndWheels;
        }

   
        //give vehicle list according to color->wheel->type
        public List<IVehicle> ListcolorAndWheelAndType()
        {
            Garage<IVehicle> gar = new();
            var colorAndWheelAndType = FindVehicleByColor(gar).ToList()
                                .Intersect(FindVehicleByWheels(gar).ToList())
                                .Intersect(FindVehicleByType(gar).ToList()).ToList();
            return colorAndWheelAndType;
        }


        //give vehicle list according to wheel->type->color
        public List<IVehicle> ListwheelAndTypeAndColor()
        {
            Garage<IVehicle> gar = new();
            var wheelAndTypeAndColor = FindVehicleByWheels(gar).ToList()
                     .Intersect(FindVehicleByType(gar).ToList())
                     .Intersect(FindVehicleByColor(gar).ToList()).ToList();
            return wheelAndTypeAndColor;
        }


        //give vehicle list according to wheel->color->type
        public List<IVehicle> ListwheelAndColorAndType()
        {
            Garage<IVehicle> gar = new();
            var wheelAndColorAndType = FindVehicleByWheels(gar).ToList()
                  .Intersect(FindVehicleByColor(gar).ToList())
                  .Intersect(FindVehicleByType(gar).ToList()).ToList();
            return wheelAndColorAndType;
        }
              
    }
}





















