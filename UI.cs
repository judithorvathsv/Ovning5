using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ovning5
{
    public class UI : IUI
    {
        string registrationNumber;
        string color;
        int numberOfEngines;
        int numberOfWheels = 0;
        int cylinderVolume;
        int numberOfSeats;
        string fueltype;
        int lenght;
        public static List<Vehicle> VehicleList { get; set; } = new List<Vehicle>();       //******************************************
        public int capacityIntInput { get ; set ; }                     //*********************************

       // public int capacityIntInput;
        public int freeCapacity;


        private void Initializing()
        {
            //23
            VehicleList.Add(new Airplane { NumberOfEngines = 2, RegistrationNumber = "aaa000", Color = "red" });
            VehicleList.Add(new Airplane { NumberOfEngines = 2, RegistrationNumber = "Aaa000", Color = "red" });
            VehicleList.Add(new Airplane { NumberOfEngines = 4, RegistrationNumber = "aaa001", Color = "red" });
            VehicleList.Add(new Airplane { NumberOfEngines = 4, RegistrationNumber = "aaa002", Color = "blue" });

            VehicleList.Add(new Boat { CylinderVolume = 300, RegistrationNumber = "aaA000", Color = "red" });
            VehicleList.Add(new Boat { CylinderVolume = 400, RegistrationNumber = "aAa000", Color = "blue" });
            VehicleList.Add(new Boat { CylinderVolume = 300, RegistrationNumber = "aaa003", Color = "yellow" });
            VehicleList.Add(new Boat { CylinderVolume = 400, RegistrationNumber = "aaa004", Color = "black" });

            VehicleList.Add(new Bus { NumberOfSeats = 50, RegistrationNumber = "aaa050", Color = "blue" });
            VehicleList.Add(new Bus { NumberOfSeats = 56, RegistrationNumber = "aaa060", Color = "red" });
            VehicleList.Add(new Bus { NumberOfSeats = 72, RegistrationNumber = "aaa005", Color = "red" });
            VehicleList.Add(new Bus { NumberOfSeats = 56, RegistrationNumber = "aaa006", Color = "red" });

            VehicleList.Add(new Car { Fueltype = "bensin", RegistrationNumber = "aaa700", Color = "red" });
            VehicleList.Add(new Car { Fueltype = "diesel", RegistrationNumber = "aaa007", Color = "black" });
            VehicleList.Add(new Car { Fueltype = "bensin", RegistrationNumber = "aaa008", Color = "red" });
            VehicleList.Add(new Car { Fueltype = "diesel", RegistrationNumber = "aaa009", Color = "white" });

            VehicleList.Add(new Motorcycle { Lenght = 172, RegistrationNumber = "aaa0010", Color = "red", NumberOfWheels = 2 });
            VehicleList.Add(new Motorcycle { Lenght = 108, RegistrationNumber = "aaa0011", Color = "blue", NumberOfWheels = 2 });
            VehicleList.Add(new Motorcycle { Lenght = 108, RegistrationNumber = "aaa0012", Color = "yellow", NumberOfWheels = 3 });
            VehicleList.Add(new Motorcycle { Lenght = 172, RegistrationNumber = "aaa0013", Color = "black", NumberOfWheels = 2 });
            VehicleList.Add(new Motorcycle { Lenght = 108, RegistrationNumber = "aaa0014", Color = "black", NumberOfWheels = 3 });
            VehicleList.Add(new Motorcycle { Lenght = 172, RegistrationNumber = "aaa0015", Color = "black", NumberOfWheels = 2 });
            VehicleList.Add(new Motorcycle { Lenght = 172, RegistrationNumber = "aaa0016", Color = "black", NumberOfWheels = 2 });
        }
      
        private int GetCapacityToGarage()        {
            Console.WriteLine("Give capacity to the garage: ");
            string capacityStringInput = CorrectInput();
            capacityIntInput = int.Parse(capacityStringInput);
            return capacityIntInput;
        }

           
        public void Menu()  {
            Console.WriteLine(" *** Garage register *** ");

            Initializing();
            GetCapacityToGarage();

            string input;
            int intInput;

            do
            {
            label0:
                Console.WriteLine("\nEnter a number:\n1: Park a vehicle\n2: List the vehicles in the garage\n3: Send out a vehicle\n4: Seach for a vehicle\n5: Quit\n");
                input = Console.ReadLine();
                bool correctInput = int.TryParse(input, out intInput);
                if (0 < intInput && intInput < 6)
                {
                    switch (intInput)
                    {
                        case 1:                           
                            AddVehicleInTheGarage();
                            break;
                        case 2:
                            ListOutTheVehiclesInTheGarage();
                            break;
                        case 3:
                            SendOutCarFormGarage();
                            break;

                        case 4:
                            SearchForVehicle();
                            break;

                        case 5:
                            Environment.Exit(0);
                            break;  
                    }
                }
                else goto label0;

            } while (0 < intInput && intInput <= 5);
        }

        private int CheckCapacity()
        {
            UI ui = new UI();
            Console.WriteLine("Garage occupied places: " + Garage<Vehicle>.MyVehiclesInGarage.Length);
            Console.WriteLine("Garage all places: " + capacityIntInput);
            int freeplaces = capacityIntInput - Garage<Vehicle>.MyVehiclesInGarage.Length;
            if (Garage<Vehicle>.MyVehiclesInGarage.Length >= capacityIntInput)
            {
                Console.WriteLine("Garage is FULL. ");
                return freeCapacity = 1;
            }

            else 
            {
                Console.WriteLine($"Free places: {freeplaces} ");
                return freeCapacity = 2;
            }
        }

        public Vehicle AddVehicleInTheGarage()
        {        
                    
                string inputAddVehicleString;
                int inputAddVehicleInt;
                do
                {
                CheckCapacity();
                Console.WriteLine("**********************************************");
                if (freeCapacity == 2)
                {

                    Console.WriteLine("Please choose vehice: \n1: Airplane\n2: Boat\n3: Bus\n4: Car\n5: Motorcycle\n6: Finish to add");
                    inputAddVehicleString = Console.ReadLine();
                    bool correctInput2 = int.TryParse(inputAddVehicleString, out inputAddVehicleInt);

                    switch (inputAddVehicleInt)
                    {
                        case 1:
                            AskBasicInformation();
                            AddAirplane();
                            break;
                        case 2:
                            AskBasicInformation();
                            AddBoat();
                            break;
                        case 3:
                            AskBasicInformation();
                            AddBus();
                            break;
                        case 4:
                            AskBasicInformation();
                            AddCar();
                            break;
                        case 5:
                            AskBasicInformation();
                            AddMotorcycle();
                            break;
                        case 6:
                            Console.WriteLine("Back to the main menu.");
                            break;
                        default:
                            Console.WriteLine("Wrong input. Back to the main menu.");
                            break;
                    }

                }
                else {                    
                    break;
                }
            }
                while (0 < inputAddVehicleInt && inputAddVehicleInt < 6);
            
           

            return new Vehicle();
        }

        public void AskBasicInformation()
        {
            AskRegistrationNumber();
            AskColor();
        }

        public void AskRegistrationNumber()
        {
            string patternRegNumber = @"[^0-9a-zA-Z]";  //letter or number only allowed
            bool isValidRegNumber;
        labelRegNumber:
            do
            {
                Console.WriteLine("Write registrationNumber:");
                registrationNumber = Console.ReadLine();
                isValidRegNumber = Regex.IsMatch(registrationNumber, patternRegNumber);

                if (registrationNumber.Length > 0)
                {
                    //only uniq registration number is allowed:
                    Dictionary<string, Vehicle> myDictionary = VehicleList.ToDictionary(x => x.RegistrationNumber);
                    bool keyExists = myDictionary.Keys.OfType<string>().Any(k => string.Equals(k, registrationNumber, StringComparison.InvariantCultureIgnoreCase));
                    if (keyExists)
                    {
                        Console.WriteLine("Wrong input! There is a same registration number already in the system. \nPlease check the registration number and enter a correct one.");
                        goto labelRegNumber;
                    }
                }
                else
                {
                    Console.WriteLine("Registration number cannot be empty!");
                    goto labelRegNumber;
                }

            } while (isValidRegNumber);

        }

        public void AskColor()
        {
            string patternColor = @"[^a-zA-Z ]";        //letter only allowed    
            bool isValidColor;
            bool emptyColorInput;
            do
            {
                Console.WriteLine("Write color:");
                color = Console.ReadLine();
                emptyColorInput = string.IsNullOrEmpty(color.Trim());

                isValidColor = Regex.IsMatch(color, patternColor);
                if (emptyColorInput) Console.WriteLine("Color cannot be empty!");
                if (isValidColor) Console.WriteLine("Not valid input. Color can be only letter!");

            } while (isValidColor | emptyColorInput);
        }

        private Vehicle AddAirplane()
        {
            label2:
            Console.WriteLine("Write number of engines");
        label1:
            string enginesString = Console.ReadLine();
            int enginesInt;
            if (int.TryParse(enginesString, out enginesInt)) {
                if (enginesInt > 0)
                    numberOfEngines = enginesInt;
                else { Console.WriteLine("It has to be bigger than zero.");
                    goto label2;
                }               
            }
            else
            {
                Console.WriteLine("Write a correct input. Use number.");
                goto label1;
            }
            Vehicle airplane = new Airplane(numberOfEngines, registrationNumber, color);        
          
                Console.WriteLine($"Added: {airplane} is parking.");
                VehicleList.Add(airplane);
        

            return airplane;
        }

        private Vehicle AddBoat()
        {
        label2: Console.WriteLine("Write cylinder volume");
            string cylinderVolumeString = Console.ReadLine();
            int cylinderVolumeInt;
            if (int.TryParse(cylinderVolumeString, out cylinderVolumeInt))
                if (cylinderVolumeInt > 0)
                    cylinderVolume = cylinderVolumeInt;
                else {
                    Console.WriteLine("It has to be bigger than zero.");
                    goto label2;
                }
            else
            {
                Console.WriteLine("Write a correct input. Use number.");
                goto label2;
            }
            Vehicle boat = new Boat(cylinderVolume, registrationNumber, color);


            
                Console.WriteLine($"Added: {boat} is parking.");
                VehicleList.Add(boat);
                     
            return boat;
        }

        private Vehicle AddBus()
        {
        label3: Console.WriteLine("Write number of seats");
            string numberOfSeatsString = Console.ReadLine();
            int numberOfSeatsInt;
            if (int.TryParse(numberOfSeatsString, out numberOfSeatsInt))
                if (numberOfSeatsInt > 0)
                    numberOfSeats = numberOfSeatsInt;
                else
                {
                    Console.WriteLine("It has to be bigger than zero.");
                    goto label3;
                }
            else
            {
                Console.WriteLine("Write a correct input. Use number.");
                goto label3;
            }
            Vehicle bus = new Bus(numberOfSeats, registrationNumber, color);
            Console.WriteLine($"Added: {bus} is parking.");
            VehicleList.Add(bus);
            return bus;
        }

        private Vehicle AddCar()
        {
            Console.WriteLine("Fueltype is gasoline or diesel. Write 1 if the fueltype is gasoline or push anything else for diesel.");
            string fueltypeString = Console.ReadLine();
            if (fueltypeString == "1")
                fueltype = "gasoline";
            else fueltype = "diesel";
            Vehicle car = new Car(fueltype, registrationNumber, color);
            Console.WriteLine($"Added: {car} is parking.");
            VehicleList.Add(car);
            return car;
        }

        private Vehicle AddMotorcycle()
        {
        label4: Console.WriteLine("Write number of wheels");
            string numberOfWheelsString = Console.ReadLine();
            int numberOfWheelsInt;
            if (int.TryParse(numberOfWheelsString, out numberOfWheelsInt))
                if (numberOfWheelsInt > 0)
                    numberOfWheels = numberOfWheelsInt;
            else
                {
                    Console.WriteLine("It has to be bigger than zero.");
                    goto label4;
                }

            else
            {
                Console.WriteLine("Write a correct input. Use number.");
                goto label4;
            }
        label5: Console.WriteLine("Write the lenght of the motorcycle");
            string lengthString = Console.ReadLine();
            int lengthInt;
            if (int.TryParse(lengthString, out lengthInt))
                if (lengthInt > 0)
                    lenght = lengthInt;
                else
                {
                    Console.WriteLine("It has to be bigger than zero.");
                    goto label5;
                }

            else
            {
                Console.WriteLine("Write a correct input. Use number.");
                goto label5;
            }
            Vehicle motorcycle = new Motorcycle(lenght, registrationNumber, color, numberOfWheels);
            Console.WriteLine($"Added: {motorcycle} is parking.");
            VehicleList.Add(motorcycle);
            return motorcycle;
        }


        /*                   ///////////////////ebbol a staticbol sima lesz UI-ban. 
        public static void ListOutTheVehiclesInTheGarage()
        {
            IHandler h = new Handler();      /////////////////////////////////////////staticbol sima lett a handlerben.   Mukodik.07.08.17:57
            h.ListTheVehiclesInTheGarage();
        }
        */
        public void ListOutTheVehiclesInTheGarage()
        {
            IHandler h = new Handler();      /////////////////////////////////////////staticbol sima lett a handlerben.   Mukodik.07.08.17:57
            h.ListTheVehiclesInTheGarage();
        }



        public static string AskSendOutAVehicleFromTheGarage()
        {
            string deletingVehicleRegNumber;
            string patternRegNumber = @"[^0-9a-zA-Z]";  //letter or number only allowed
            bool isValidRegNumber;
            bool emptyRegNumberInput;
            bool keyExists;
            Dictionary<string, Vehicle> myVehicleREgNumberDictionary = VehicleList.ToDictionary(x => x.RegistrationNumber);
            do
            {
                Console.WriteLine("Which vehicle you want to get from the garage? \nPlease write the registration number:");
                deletingVehicleRegNumber = Console.ReadLine();


                isValidRegNumber = Regex.IsMatch(deletingVehicleRegNumber, patternRegNumber);
                emptyRegNumberInput = string.IsNullOrEmpty(deletingVehicleRegNumber.Trim());               
                keyExists = myVehicleREgNumberDictionary.Keys.OfType<string>().Any(k => string.Equals(k, deletingVehicleRegNumber, StringComparison.InvariantCultureIgnoreCase));

                //valid input, only letter and number allowed:
                if (isValidRegNumber)
                {
                    Console.WriteLine("Wrong input. Only number bigger than zero and letter are allowed. \n");
                }

                //not empty input allowed:                
                else if (emptyRegNumberInput)
                    Console.WriteLine("Registrering number cannot be empty!");

                //searched registr. number should be in the garage:               
                else if (!keyExists)
                {
                    Console.WriteLine("Wrong input! There is no same registration number in the system.");
                }

            } while (isValidRegNumber | emptyRegNumberInput);

            if (keyExists)
                return deletingVehicleRegNumber;
            else return deletingVehicleRegNumber=null;
        }  //******************************************************************



        /*    //////////////////////////////ebbol simat csinalok itt az UI-ban
        public static void SendOutCarFormGarage()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();  ////////////////////////////////////////////////////// Handlerben lett sima 
            IHandler h = new Handler();
            h.FindTheCarToSendOutFromTheGarage(gar);
        }
        */
        public void SendOutCarFormGarage()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();  ////////////////////////////////////////////////////// Handlerben lett sima 
            IHandler h = new Handler();
            h.FindTheCarToSendOutFromTheGarage(gar);
        }


        public void SearchForVehicle()
        {
            string inputString;
            int inputInt;
            do
            {
            label:
                Console.WriteLine("\nMenu:\n1: Find a vehicle with registration number\n2: Get vehicle types and how many vehicles are in a type\n3: Find a vehicle/vehicles by type, color and number of wheels\n4: Quit to the main menu");
                inputString = Console.ReadLine();
                bool correctInput = int.TryParse(inputString, out inputInt);             
                                
                if (0 < inputInt && inputInt < 6)
                {
                    switch (inputInt)
                    {
                        case 1:
                            GetVehicleByRegNumber();
                            break;
                        case 2:
                            VehicleTypesWithNumberOfVehicles();
                            break;
                        case 3:
                            SearcVehicleshByProperties();
                            break;
                        case 4:
                            Console.WriteLine("Back to the main menu");
                            break;                    
                    }
                }
                else {
                    Console.WriteLine("Wrong input. Enter a number between 1 and 4.");
                    goto label;
                }
               
            } while (0 < inputInt && inputInt <= 3);
        }

       
        /*//////////////////////////////////////////////////////////////////////////////////////////////////staticbol simat csinalok UI ban. Mukodik 07.08.18:26
        public static void GetVehicleByRegNumber()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            IHandler h = new Handler();
            h.FindVehicleWithRegNUmber(gar);
        }
        */

        public void GetVehicleByRegNumber()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            IHandler h = new Handler();
            h.FindVehicleWithRegNUmber(gar);
        }



        

        /*  ///////////////////////////////////////////////////////////////////////////////////staticbol sima 07.08.18:30
        public static void VehicleTypesWithNumberOfVehicles()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            IHandler h = new Handler();
            h.FindVehicleTypes(gar);
        }
        */

        public void VehicleTypesWithNumberOfVehicles()
        {
            Garage<Vehicle> gar = new Garage<Vehicle>();
            IHandler h = new Handler();
            h.FindVehicleTypes(gar);
        }


        //0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
        //ebbol simat csinalok//////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SearcVehicleshByProperties()
        {    
            Console.WriteLine("\n---Searching parameters:---");

            string firstInput;
            do {
                Console.WriteLine("Choose first parameter: 1: type, 2: color, 3: number of wheels");
                firstInput = CorrectInput();
                IHandler h = new Handler();
                switch (firstInput) {                    
                        case "1": //type                       
                            h.SearcVehicleshByType();
                            break;
                        case "2": //color                        
                        h.SearcVehicleshByColor();
                            break;
                        case "3": //wheels                       
                        h.SearcVehicleshByWheels();
                            break;
                        default:
                        Console.WriteLine("Wrong input.");
                        break;
                    }    
            } while (!(firstInput == "1" || firstInput == "2" || firstInput == "3"));
        }


        /* ////////////////////////////////////////////////////////ezekbol staticok simat csinalok UI-ben. 
          public static string SearchedType()
          {
              string type;
              bool emptyTypeInput;
              bool keyExistsForType;

              do
              {
                  Console.WriteLine("Write the type of the vehicle, or for all vehicle enter V:");
                  type = Console.ReadLine();
                  emptyTypeInput = string.IsNullOrEmpty(type.Trim());

                  //looking for the types we already have in the garage:
                  Dictionary<string, List<Vehicle>> resultDictionary = (from sample in VehicleList group sample by sample.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());
                  keyExistsForType = resultDictionary.Keys.Any(k => string.Equals(k, type, StringComparison.InvariantCultureIgnoreCase));

                  if (emptyTypeInput)
                      Console.WriteLine("Type cannot be empty!");
                  else if (!keyExistsForType && !(type == "v" || type == "V"))
                      Console.WriteLine("There is no this type in the garage.");
              }
              while (emptyTypeInput || (!keyExistsForType && type != "v" && type != "V"));
              return type;
          }     //******************************************************************

          public static string SearchedColor()
          {
              string color;
              bool emptyColorInput;
              bool keyExistsForColor;

              do
              {
                  Console.WriteLine("Write the color, or for all color enter C:");
                  color = Console.ReadLine();
                  emptyColorInput = string.IsNullOrEmpty(color.Trim());


                  //looking for the colors we already have in the garage:
                  Dictionary<string, List<Vehicle>> resultDictionary = (from sample in VehicleList group sample by sample.Color).ToDictionary(g => g.Key, g => g.ToList());
                  keyExistsForColor = resultDictionary.Keys.Any(k => string.Equals(k, color, StringComparison.InvariantCultureIgnoreCase));

                  if (emptyColorInput)
                      Console.WriteLine("Type cannot be empty!");
                  else if (!keyExistsForColor && !(color == "c" || color == "C"))
                      Console.WriteLine("There is no this color in the garage.");
              }
              while (emptyColorInput || (!keyExistsForColor && color != "c" && color != "C"));
              return color;
          }   //******************************************************************

          public static int SearchedWheels()
          {
              string wheelsString;
              bool emptyWheelInput;
              int wheelsInt;
              bool validWheelNumber;

              //looking for the number of wheels we already have in the garage:
              Dictionary<int, List<Vehicle>> resultDictionaryForWheels = (from sample in VehicleList group sample by sample.NumberOfWheels).ToDictionary(g => g.Key, g => g.ToList());
              bool keyExists;

              do
              {
                  Console.WriteLine("Write the number of wheels, or enter 0:");
                  wheelsString = Console.ReadLine();
                  emptyWheelInput = string.IsNullOrEmpty(wheelsString.Trim());
                  validWheelNumber = int.TryParse(wheelsString, out wheelsInt);
                  keyExists = resultDictionaryForWheels.Keys.OfType<int>().Any(k => int.Equals(k, wheelsInt));

                  if (emptyWheelInput)
                      Console.WriteLine("Input cannot be empty!");

                  else if (!validWheelNumber)
                      Console.WriteLine("Write a correct input. Use number.");

                  else if (!keyExists)
                      Console.WriteLine($"There is no vehicle with {wheelsInt} wheels in the garage.");

              } while (emptyWheelInput || !validWheelNumber || !(keyExists || wheelsString == "0"));
              return wheelsInt;

          }  //******************************************************************

          */

        public string SearchedType()
        {
            string type;
            bool emptyTypeInput;
            bool keyExistsForType;

            do
            {
                Console.WriteLine("Write the type of the vehicle, or for all vehicle enter V:");
                type = Console.ReadLine();
                emptyTypeInput = string.IsNullOrEmpty(type.Trim());

                //looking for the types we already have in the garage:
                Dictionary<string, List<Vehicle>> resultDictionary = (from sample in VehicleList group sample by sample.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());
                keyExistsForType = resultDictionary.Keys.Any(k => string.Equals(k, type, StringComparison.InvariantCultureIgnoreCase));

                if (emptyTypeInput)
                    Console.WriteLine("Type cannot be empty!");
                else if (!keyExistsForType && !(type == "v" || type == "V"))
                    Console.WriteLine("There is no this type in the garage.");
            }
            while (emptyTypeInput || (!keyExistsForType && type != "v" && type != "V"));
            return type;
        }     //******************************************************************

        public string SearchedColor()
        {
            string color;
            bool emptyColorInput;
            bool keyExistsForColor;

            do
            {
                Console.WriteLine("Write the color, or for all color enter C:");
                color = Console.ReadLine();
                emptyColorInput = string.IsNullOrEmpty(color.Trim());


                //looking for the colors we already have in the garage:
                Dictionary<string, List<Vehicle>> resultDictionary = (from sample in VehicleList group sample by sample.Color).ToDictionary(g => g.Key, g => g.ToList());
                keyExistsForColor = resultDictionary.Keys.Any(k => string.Equals(k, color, StringComparison.InvariantCultureIgnoreCase));

                if (emptyColorInput)
                    Console.WriteLine("Type cannot be empty!");
                else if (!keyExistsForColor && !(color == "c" || color == "C"))
                    Console.WriteLine("There is no this color in the garage.");
            }
            while (emptyColorInput || (!keyExistsForColor && color != "c" && color != "C"));
            return color;
        }   //******************************************************************

        public int SearchedWheels()
        {
            string wheelsString;
            bool emptyWheelInput;
            int wheelsInt;
            bool validWheelNumber;

            //looking for the number of wheels we already have in the garage:
            Dictionary<int, List<Vehicle>> resultDictionaryForWheels = (from sample in VehicleList group sample by sample.NumberOfWheels).ToDictionary(g => g.Key, g => g.ToList());
            bool keyExists;

            do
            {
                Console.WriteLine("Write the number of wheels, or enter 0:");
                wheelsString = Console.ReadLine();
                emptyWheelInput = string.IsNullOrEmpty(wheelsString.Trim());
                validWheelNumber = int.TryParse(wheelsString, out wheelsInt);
                keyExists = resultDictionaryForWheels.Keys.OfType<int>().Any(k => int.Equals(k, wheelsInt));

                if (emptyWheelInput)
                    Console.WriteLine("Input cannot be empty!");

                else if (!validWheelNumber)
                    Console.WriteLine("Write a correct input. Use number.");

                else if (!keyExists)
                    Console.WriteLine($"There is no vehicle with {wheelsInt} wheels in the garage.");

            } while (emptyWheelInput || !validWheelNumber || !(keyExists || wheelsString == "0"));
            return wheelsInt;

        }  //******************************************************************














        /// //////////////////////////////////////////////////////////////////////////ebbol statikot csinalok UI-ban, amit HANDLERben is hasznalok.

        public string CorrectInput() {

            string input;
            string inputString;
            bool emptyInput;
            int inputInt;
            bool validInput;           
            do
            {               
                input = Console.ReadLine();
                inputString = input.Trim();

                emptyInput = string.IsNullOrEmpty(inputString.Trim());
                validInput = int.TryParse(inputString, out inputInt);

                if (emptyInput)
                    Console.WriteLine("Input cannot be empty.");

                else if (!validInput)
                    Console.WriteLine("Write a correct input. Use number.");
                else if(inputInt<=0)
                    Console.WriteLine("Input has to be bigger than zero.");
            }
            while (emptyInput || !validInput || (inputInt <= 0));

            return inputString;
        }     //******************************************************************

    
    }



}













