using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Ovning5
{
 public class Handler : IHandler

    {    

   
        
        public static int  GiveCapacityToGarageFromUI() {
            UI ui = new UI();
            return ui.capacityIntInput;  /////////////////////////////////////////////////////////////////////////////////////////*******************************
        }






        /*
        //create array: from list within Handler -> for the Garage in Handler.     
        public  static Vehicle[] MakeTheListToArray() {                              //ooooooooooooooooooooooooooooooooooooooooooooooooo STTATICBOL SIMAT CSINALTAM  mukodik 07.08.17:32
            Vehicle[] handlerVehiclesArray = UI.VehicleList.ToArray(); /////////////////////////////////////////////////////////////////////////////////////////*******************
            return handlerVehiclesArray;
        }
        */
        //create array: from list within Handler -> for the Garage in Handler.     


        public Vehicle[] MakeTheListToArray()
        {                              //ooooooooooooooooooooooooooooooooooooooooooooooooo STTATICBOL SIMAT CSINALTAM  mukodik 07.08.17:32
            Vehicle[] handlerVehiclesArray = UI.VehicleList.ToArray(); /////////////////////////////////////////////////////////////////////////////////////////*******************
            return handlerVehiclesArray;
        }





        /// ////////////////////////////////////////////////////////////STATICBOL SIMA  hANDLERBEN Mukodik.07.08.17:57

        //Get array of vehicles from Garage then list out the those:
        /*
        public static void ListTheVehiclesInTheGarage()    {
            Console.WriteLine("---Vehicles in the garage:---");
            foreach (Vehicle item in Garage<Vehicle>.MyVehiclesInGarage)            
                Console.WriteLine(item);        
        }
        */

        //Get array of vehicles from Garage then list out the those:       
        public void ListTheVehiclesInTheGarage()
        {
            Console.WriteLine("---Vehicles in the garage:---");
            foreach (Vehicle item in Garage<Vehicle>.MyVehiclesInGarage)
                Console.WriteLine(item);
        }






        /*
        //Search in the Garage array to find the vehicle that we would be send out, list out the vehicle, then list out the new Garage list:
        public static void FindTheCarToSendOutFromTheGarage(Garage<Vehicle> MyVehiclesInGarage) {
            Console.WriteLine("---Sending out vehicle:---");

            string deletableRegNumber= UI.AskSendOutAVehicleFromTheGarage();            /////////////////////////////////////////////////////////////////////////////////////////******
            var deletingCar = MyVehiclesInGarage.Where(c => c.RegistrationNumber.Equals(deletableRegNumber)).ToList();
        
            foreach (var item in deletingCar)
            {
                Console.WriteLine("The vehicle which will leave the garage:");
                Console.WriteLine(item); 
              
            }        
            // deleting car from the garage:
            foreach (var item in deletingCar)
            {
                UI.VehicleList.Remove(item); /////////////////////////////////////////////////////////////////////////////////////////*********************************
            }      
                      
            Console.WriteLine();

            //print out the garage after deleting:
            IHandler h = new Handler();
                h.ListTheVehiclesInTheGarage(); ////////////////////////////////////////////mivel fent staticbol sima lett itt a handletben.
        }
        */


        //Search in the Garage array to find the vehicle that we would be send out, list out the vehicle, then list out the new Garage list:
        public void FindTheCarToSendOutFromTheGarage(Garage<Vehicle> MyVehiclesInGarage)   //////////////////////////////simat csinaltam belole a Handlerben.
        {
            Console.WriteLine("---Sending out vehicle:---");

            string deletableRegNumber = UI.AskSendOutAVehicleFromTheGarage();            /////////////////////////////////////////////////////////////////////////////////////////******
            var deletingCar = MyVehiclesInGarage.Where(c => c.RegistrationNumber.Equals(deletableRegNumber)).ToList();

            foreach (var item in deletingCar)
            {
                Console.WriteLine("The vehicle which will leave the garage:");
                Console.WriteLine(item);

            }
            // deleting car from the garage:
            foreach (var item in deletingCar)
            {
                UI.VehicleList.Remove(item); /////////////////////////////////////////////////////////////////////////////////////////*********************************
            }

            Console.WriteLine();

            //print out the garage after deleting:
            IHandler h = new Handler();
            h.ListTheVehiclesInTheGarage(); ////////////////////////////////////////////mivel fent staticbol sima lett itt a handletben.
        }



        /*  ////////////////////////////////////////////////////////////////////////////////////////////ebbol simat csinalok a Handlerben 
        public static void FindVehicleWithRegNUmber(Garage<Vehicle> MyVehiclesInGarage) {
            Console.WriteLine("\n---Finding vehicle by registration number:---");
            string SearchForRegNumber = UI.AskSendOutAVehicleFromTheGarage(); /////////////////////////////////////////////////////////////////////////////////////////*********
            var searchedVehicle = MyVehiclesInGarage.Where(c => c.RegistrationNumber.Equals(SearchForRegNumber)).ToList();
  
            foreach (var item in searchedVehicle)
            {
                Console.WriteLine(item);
            }  
        }
        */

        public void FindVehicleWithRegNUmber(Garage<Vehicle> MyVehiclesInGarage)
        {
            Console.WriteLine("\n---Finding vehicle by registration number:---");
            string SearchForRegNumber = UI.AskSendOutAVehicleFromTheGarage(); /////////////////////////////////////////////////////////////////////////////////////////*********
            var searchedVehicle = MyVehiclesInGarage.Where(c => c.RegistrationNumber.Equals(SearchForRegNumber)).ToList();

            foreach (var item in searchedVehicle)
            {
                Console.WriteLine(item);
            }
        }




















        /*  //////////////////////////////////////////////////////////////////////////staticbol sima Handlerben.

        public static void FindVehicleTypes(Garage<Vehicle> MyVehiclesInGarage) {
            Console.WriteLine("\n---Finding vehicle types:---");
            
            var allVehicles = from v in MyVehiclesInGarage
                         group v by v.GetType().Name into garage
                         select new {Type = garage.Key, Number = garage.Count() } ;     

            foreach (var item in allVehicles)
            {
                Console.WriteLine(item.ToString().Substring(2,item.ToString().Length-3));
            }
        }
        */

        public void FindVehicleTypes(Garage<Vehicle> MyVehiclesInGarage)
        {
            Console.WriteLine("\n---Finding vehicle types:---");

            var allVehicles = from v in MyVehiclesInGarage
                              group v by v.GetType().Name into garage
                              select new { Type = garage.Key, Number = garage.Count() };

            foreach (var item in allVehicles)
            {
                Console.WriteLine(item.ToString().Substring(2, item.ToString().Length - 3));
            }
        }




        /* ///////////////////////////////////////////////////////////////////////////////////ezekbol staticok simat csinalok es a bennuk levo UI.searced...-bol is sima lesz.
        private static List<Vehicle> FindVehicleByWheels(Garage<Vehicle> MyVehiclesInGarage) {           
            List<Vehicle> findWheels;
            int wheels = UI.SearchedWheels(); /////////////////////////////////////////////////////////////////////////////////////////**********************
            if (wheels > 0) 
            return findWheels = MyVehiclesInGarage.Select(g => g).Where(v=>v.NumberOfWheels.Equals(wheels)).ToList();            
            else if (wheels == 0)  
              return  findWheels = MyVehiclesInGarage.Select(g => g).ToList();            
          else return findWheels = MyVehiclesInGarage.Select(g => g).ToList();
        }

      


        private static List<Vehicle> FindVehicleByColor(Garage<Vehicle> MyVehiclesInGarage)
        {
            List<Vehicle> findColor;
            string color = UI.SearchedColor();     /////////////////////////////////////////////////////////////////////////////////////////*****************
            if (!color.Equals("c") && !color.Equals("C"))
            {
                 findColor = MyVehiclesInGarage.Select(g => g).Where(v => v.Color.Equals(color)).ToList();                    
            }
            else
            {
                 findColor = MyVehiclesInGarage.Select(g => g).ToList();                          
            }            
            return findColor;
        }



        private static List<Vehicle> FindVehicleByType(Garage<Vehicle> MyVehiclesInGarage)
        {
            List<Vehicle> findType;
            string type = UI.SearchedType();          /////////////////////////////////////////////////////////////////////////////////////////**************
            if (!type.Equals("v") && !type.Equals("V"))
            {
                 findType = MyVehiclesInGarage.Select(g => g).Where(v => v.GetType().Name.Equals(type, StringComparison.InvariantCultureIgnoreCase)).ToList();          
            }
            else
            {
                 findType = MyVehiclesInGarage.Select(g => g).ToList();          
            }
            return findType;
        }
        */

        private List<Vehicle> FindVehicleByWheels(Garage<Vehicle> MyVehiclesInGarage)
        {
            List<Vehicle> findWheels;
            IUI ui = new UI();
            int wheels = ui.SearchedWheels(); /////////////////////////////////////////////////////////////////////////////////////////**********************
            if (wheels > 0)
                return findWheels = MyVehiclesInGarage.Select(g => g).Where(v => v.NumberOfWheels.Equals(wheels)).ToList();
            else if (wheels == 0)
                return findWheels = MyVehiclesInGarage.Select(g => g).ToList();
            else return findWheels = MyVehiclesInGarage.Select(g => g).ToList();
        }




        private List<Vehicle> FindVehicleByColor(Garage<Vehicle> MyVehiclesInGarage)
        {
            List<Vehicle> findColor;
            IUI ui = new UI();
            string color = ui.SearchedColor();     /////////////////////////////////////////////////////////////////////////////////////////*****************
            if (!color.Equals("c") && !color.Equals("C"))
            {
                findColor = MyVehiclesInGarage.Select(g => g).Where(v => v.Color.Equals(color)).ToList();
            }
            else
            {
                findColor = MyVehiclesInGarage.Select(g => g).ToList();
            }
            return findColor;
        }



        private List<Vehicle> FindVehicleByType(Garage<Vehicle> MyVehiclesInGarage)
        {
            List<Vehicle> findType;
            IUI ui = new UI();
            string type = ui.SearchedType();          /////////////////////////////////////////////////////////////////////////////////////////**************
            if (!type.Equals("v") && !type.Equals("V"))
            {
                findType = MyVehiclesInGarage.Select(g => g).Where(v => v.GetType().Name.Equals(type, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            else
            {
                findType = MyVehiclesInGarage.Select(g => g).ToList();
            }
            return findType;
        }






        /*  ///////////////////////////////////////////////////////////////////ezekbol staticbol simat csinalok Handlerben. 
        public static void SearcVehicleshByType()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            string secondInputToType;
            do
            {
                Console.WriteLine("Choose second parameter: 1: color, 2: number of wheels");
                secondInputToType = UI.CorrectInput(); /////////////////////////////////////////////////////////////////////////////////////////********************************

                if (secondInputToType == "1")
                { // color                       

                    var typeAndColorAndWheel = new List<Vehicle>();
                    typeAndColorAndWheel = FindVehicleByType(gar).ToList()
                        .Intersect(FindVehicleByColor(gar).ToList())
                        .Intersect(FindVehicleByWheels(gar).ToList()).ToList();

                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in typeAndColorAndWheel)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (secondInputToType == "2") //wheel
                {
                    var typeAndWheelAndColor = new List<Vehicle>();
                    typeAndWheelAndColor = FindVehicleByType(gar).ToList()
                        .Intersect(FindVehicleByWheels(gar).ToList())
                        .Intersect(FindVehicleByColor(gar).ToList()).ToList();
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in typeAndWheelAndColor)
                    {
                        Console.WriteLine(item);
                    }
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToType != "1" && secondInputToType != "2");
        }


        public static void SearcVehicleshByColor()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            string secondInputToColor;
            do
            {
                Console.WriteLine("Choose parameter: 1: type, 2: number of wheels");
                secondInputToColor = UI.CorrectInput(); /////////////////////////////////////////////////////////////////////////////////////////**************************
                if (secondInputToColor == "1") //type
                {
                    var colorAndTypeAndWheels = new List<Vehicle>();
                    colorAndTypeAndWheels = FindVehicleByColor(gar).ToList()
                        .Intersect(FindVehicleByType(gar).ToList())
                        .Intersect(FindVehicleByWheels(gar).ToList()).ToList();
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in colorAndTypeAndWheels)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (secondInputToColor == "2") //wheel
                {
                    var colorAndWheelAndType = new List<Vehicle>();
                    colorAndWheelAndType = FindVehicleByColor(gar).ToList()
                        .Intersect(FindVehicleByWheels(gar).ToList())
                        .Intersect(FindVehicleByType(gar).ToList()).ToList();
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in colorAndWheelAndType)
                    {
                        Console.WriteLine(item);
                    }
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToColor != "1" && secondInputToColor != "2");
        }


        public static void SearcVehicleshByWheels()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            string secondInputToWheel;
            do
            {
                Console.WriteLine("Choose parameter: 1: type, 2: color");
                secondInputToWheel = UI.CorrectInput(); //////////////////////////////////////////////////////////////////*******************************
                if (secondInputToWheel == "1") //type
                {
                    var wheelAndTypeAndColor = new List<Vehicle>();
                    wheelAndTypeAndColor = FindVehicleByWheels(gar).ToList()
                        .Intersect(FindVehicleByType(gar).ToList())
                        .Intersect(FindVehicleByColor(gar).ToList()).ToList();

                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in wheelAndTypeAndColor)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (secondInputToWheel == "2") //color
                {
                    var wheelAndColorAndType = new List<Vehicle>();
                    wheelAndColorAndType = FindVehicleByWheels(gar).ToList()
                        .Intersect(FindVehicleByColor(gar).ToList())
                        .Intersect(FindVehicleByType(gar).ToList()).ToList();

                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in wheelAndColorAndType)
                    {
                        Console.WriteLine(item);
                    }
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToWheel != "1" && secondInputToWheel != "2");
        }
        */


        public void SearcVehicleshByType()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            string secondInputToType;
            do
            {
                Console.WriteLine("Choose second parameter: 1: color, 2: number of wheels");
                IUI ui = new UI();
                secondInputToType = ui.CorrectInput(); /////////////////////////////////////////////////////////////////////////////////////////********************************

                if (secondInputToType == "1")
                { // color                       

                    var typeAndColorAndWheel = new List<Vehicle>();
                    typeAndColorAndWheel = FindVehicleByType(gar).ToList()
                        .Intersect(FindVehicleByColor(gar).ToList())
                        .Intersect(FindVehicleByWheels(gar).ToList()).ToList();

                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in typeAndColorAndWheel)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (secondInputToType == "2") //wheel
                {
                    var typeAndWheelAndColor = new List<Vehicle>();
                    typeAndWheelAndColor = FindVehicleByType(gar).ToList()
                        .Intersect(FindVehicleByWheels(gar).ToList())
                        .Intersect(FindVehicleByColor(gar).ToList()).ToList();
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in typeAndWheelAndColor)
                    {
                        Console.WriteLine(item);
                    }
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToType != "1" && secondInputToType != "2");
        }


        public void SearcVehicleshByColor()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            string secondInputToColor;
            do
            {
                Console.WriteLine("Choose parameter: 1: type, 2: number of wheels");
                IUI ui = new UI();
                secondInputToColor = ui.CorrectInput(); /////////////////////////////////////////////////////////////////////////////////////////**************************
                if (secondInputToColor == "1") //type
                {
                    var colorAndTypeAndWheels = new List<Vehicle>();
                    colorAndTypeAndWheels = FindVehicleByColor(gar).ToList()
                        .Intersect(FindVehicleByType(gar).ToList())
                        .Intersect(FindVehicleByWheels(gar).ToList()).ToList();
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in colorAndTypeAndWheels)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (secondInputToColor == "2") //wheel
                {
                    var colorAndWheelAndType = new List<Vehicle>();
                    colorAndWheelAndType = FindVehicleByColor(gar).ToList()
                        .Intersect(FindVehicleByWheels(gar).ToList())
                        .Intersect(FindVehicleByType(gar).ToList()).ToList();
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in colorAndWheelAndType)
                    {
                        Console.WriteLine(item);
                    }
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToColor != "1" && secondInputToColor != "2");
        }


        public void SearcVehicleshByWheels()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            string secondInputToWheel;
            do
            {
                Console.WriteLine("Choose parameter: 1: type, 2: color");
                IUI ui = new UI();
                secondInputToWheel = ui.CorrectInput(); //////////////////////////////////////////////////////////////////*******************************
                if (secondInputToWheel == "1") //type
                {
                    var wheelAndTypeAndColor = new List<Vehicle>();
                    wheelAndTypeAndColor = FindVehicleByWheels(gar).ToList()
                        .Intersect(FindVehicleByType(gar).ToList())
                        .Intersect(FindVehicleByColor(gar).ToList()).ToList();

                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in wheelAndTypeAndColor)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (secondInputToWheel == "2") //color
                {
                    var wheelAndColorAndType = new List<Vehicle>();
                    wheelAndColorAndType = FindVehicleByWheels(gar).ToList()
                        .Intersect(FindVehicleByColor(gar).ToList())
                        .Intersect(FindVehicleByType(gar).ToList()).ToList();

                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in wheelAndColorAndType)
                    {
                        Console.WriteLine(item);
                    }
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToWheel != "1" && secondInputToWheel != "2");
        }












    }
   
}
