using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Dynamic;

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
        public int CapacityIntInput { get ; set ; }               
        public int freeCapacity;


        private void Initializing()
        {                                                                                           
            //23   
            Handler.VehicleList.Add(new Airplane { NumberOfEngines = 2, RegistrationNumber = "aaa000", Color = "red" });
            Handler.VehicleList.Add(new Airplane { NumberOfEngines = 2, RegistrationNumber = "Aaa000", Color = "red" });
            Handler.VehicleList.Add(new Airplane { NumberOfEngines = 4, RegistrationNumber = "aaa001", Color = "red" });
            Handler.VehicleList.Add(new Airplane { NumberOfEngines = 4, RegistrationNumber = "aaa002", Color = "blue" });

            Handler.VehicleList.Add(new Boat { CylinderVolume = 300, RegistrationNumber = "aaA000", Color = "red" });
            Handler.VehicleList.Add(new Boat { CylinderVolume = 400, RegistrationNumber = "aAa000", Color = "blue" });
            Handler.VehicleList.Add(new Boat { CylinderVolume = 300, RegistrationNumber = "aaa003", Color = "yellow" });
            Handler.VehicleList.Add(new Boat { CylinderVolume = 400, RegistrationNumber = "aaa004", Color = "black" });

            Handler.VehicleList.Add(new Bus { NumberOfSeats = 50, RegistrationNumber = "aaa050", Color = "blue" });
            Handler.VehicleList.Add(new Bus { NumberOfSeats = 56, RegistrationNumber = "aaa060", Color = "red" });
            Handler.VehicleList.Add(new Bus { NumberOfSeats = 72, RegistrationNumber = "aaa005", Color = "red" });
            Handler.VehicleList.Add(new Bus { NumberOfSeats = 56, RegistrationNumber = "aaa006", Color = "red" });

            Handler.VehicleList.Add(new Car { Fueltype = "bensin", RegistrationNumber = "aaa700", Color = "red" });
            Handler.VehicleList.Add(new Car { Fueltype = "diesel", RegistrationNumber = "aaa007", Color = "black" });
            Handler.VehicleList.Add(new Car { Fueltype = "bensin", RegistrationNumber = "aaa008", Color = "red" });
            Handler.VehicleList.Add(new Car { Fueltype = "diesel", RegistrationNumber = "aaa009", Color = "white" });

            Handler.VehicleList.Add(new Motorcycle { Lenght = 172, RegistrationNumber = "aaa0010", Color = "red", NumberOfWheels = 2 });
            Handler.VehicleList.Add(new Motorcycle { Lenght = 108, RegistrationNumber = "aaa0011", Color = "blue", NumberOfWheels = 2 });
            Handler.VehicleList.Add(new Motorcycle { Lenght = 108, RegistrationNumber = "aaa0012", Color = "yellow", NumberOfWheels = 3 });
            Handler.VehicleList.Add(new Motorcycle { Lenght = 172, RegistrationNumber = "aaa0013", Color = "black", NumberOfWheels = 2 });
            Handler.VehicleList.Add(new Motorcycle { Lenght = 108, RegistrationNumber = "aaa0014", Color = "black", NumberOfWheels = 3 });
            Handler.VehicleList.Add(new Motorcycle { Lenght = 172, RegistrationNumber = "aaa0015", Color = "black", NumberOfWheels = 2 });
            Handler.VehicleList.Add(new Motorcycle { Lenght = 172, RegistrationNumber = "aaa0016", Color = "black", NumberOfWheels = 2 });
        }
      

        private int GetCapacityToGarage()        {
            do {
                Console.WriteLine("Give capacity to the garage: ");
                string capacityStringInput = CorrectInput();
                CapacityIntInput = int.Parse(capacityStringInput);               

                if (Garage<IVehicle>.MyVehiclesInGarage.Length >= CapacityIntInput)
                {
                    Console.WriteLine("There are already vehicles in the garage. \nThe garage capacity has to be bigger than the number of these vehicles.");
                    Console.WriteLine("Number of vehicles in the garage: "+ Garage<IVehicle>.MyVehiclesInGarage.Length);
                }      
            } while (Garage<IVehicle>.MyVehiclesInGarage.Length >= CapacityIntInput);
          
            return CapacityIntInput;
        }

              
        public void Menu()  {

            // --------Starting items above added here:------------- 
            Initializing();

            Console.WriteLine(" *** Garage register *** ");           
            GetCapacityToGarage();
            Garage<IVehicle> g = new(CapacityIntInput);
            
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


        private void AddVehicleInTheGarage()
        {                        
                string inputAddVehicleString;
                int inputAddVehicleInt;

                do
                {
                IHandler h = new Handler();
                if (h.CheckCapacityInTheGarageSendingToUI() == false)
                {
                    Console.WriteLine("**********************************************");        
              
                    Console.WriteLine("Please choose vehice: \n1: Airplane\n2: Boat\n3: Bus\n4: Car\n5: Motorcycle\n6: Finish to add\n");
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
        }


        private void AskBasicInformation()
        {
            AskRegistrationNumber();
            AskColor();
        }


        private void AskRegistrationNumber()
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
                    Dictionary<string, IVehicle> myDictionary = Handler.VehicleList.ToDictionary(x => x.RegistrationNumber); 
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


        private void AskColor()
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


        private IVehicle AddAirplane()
        {
            label2:
            Console.WriteLine("Write number of engines");
            label1:
            string enginesString = Console.ReadLine();
            if (int.TryParse(enginesString, out int enginesInt))
            {
                if (enginesInt > 0)
                    numberOfEngines = enginesInt;
                else
                {
                    Console.WriteLine("It has to be bigger than zero.");
                    goto label2;
                }
            }
            else
            {
                Console.WriteLine("Write a correct input. Use number.");
                goto label1;
            }
            IVehicle airplane = new Airplane(numberOfEngines, registrationNumber, color);           
                Console.WriteLine($"Added: {airplane} is parking.");            
            Handler.VehicleList.Add(airplane);
            return airplane;
        }


        private IVehicle AddBoat()
        {
        label2: Console.WriteLine("Write cylinder volume");
            string cylinderVolumeString = Console.ReadLine();
            if (int.TryParse(cylinderVolumeString, out int cylinderVolumeInt))
                if (cylinderVolumeInt > 0)
                    cylinderVolume = cylinderVolumeInt;
                else
                {
                    Console.WriteLine("It has to be bigger than zero.");
                    goto label2;
                }
            else
            {
                Console.WriteLine("Write a correct input. Use number.");
                goto label2;
            }
            IVehicle boat = new Boat(cylinderVolume, registrationNumber, color);
                Console.WriteLine($"Added: {boat} is parking.");                               
            Handler.VehicleList.Add(boat);
            return boat;
        }


        private IVehicle AddBus()
        {
        label3: Console.WriteLine("Write number of seats");
            string numberOfSeatsString = Console.ReadLine();
            if (int.TryParse(numberOfSeatsString, out int numberOfSeatsInt))
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
            IVehicle bus = new Bus(numberOfSeats, registrationNumber, color);
            Console.WriteLine($"Added: {bus} is parking.");           
            Handler.VehicleList.Add(bus);
            return bus;
        }


        private IVehicle AddCar()
        {
            Console.WriteLine("Fueltype is gasoline or diesel. Write 1 if the fueltype is gasoline or push anything else for diesel.");
            string fueltypeString = Console.ReadLine();
            if (fueltypeString == "1")
                fueltype = "gasoline";
            else fueltype = "diesel";
            IVehicle car = new Car(fueltype, registrationNumber, color);
            Console.WriteLine($"Added: {car} is parking.");            
            Handler.VehicleList.Add(car);
            return car;
        }


        private IVehicle AddMotorcycle()
        {
        label4: Console.WriteLine("Write number of wheels");
            string numberOfWheelsString = Console.ReadLine();
            if (int.TryParse(numberOfWheelsString, out int numberOfWheelsInt))
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
            if (int.TryParse(lengthString, out int lengthInt))
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
            IVehicle motorcycle = new Motorcycle(lenght, registrationNumber, color, numberOfWheels);
            Console.WriteLine($"Added: {motorcycle} is parking.");           
           Handler.VehicleList.Add(motorcycle);
            return motorcycle;
        }

     
        private void ListOutTheVehiclesInTheGarage()
        {
            IHandler h = new Handler();
            Console.WriteLine("---Vehicles in the garage:---");
            h.ListTheVehiclesInTheGarage();
        }


        public string AskSendOutAVehicleFromTheGarage()  
        {
            string deletingVehicleRegNumber;
            string patternRegNumber = @"[^0-9a-zA-Z]";  //letter or number only allowed
            bool isValidRegNumber;
            bool emptyRegNumberInput;
            bool keyExists;
           
            Dictionary<string, IVehicle> myVehicleREgNumberDictionary = Handler.VehicleList.ToDictionary(x => x.RegistrationNumber);
            do
            {
                Console.WriteLine("Which vehicle you want to get from the garage? \nPlease write the registration number:");
                deletingVehicleRegNumber = Console.ReadLine();

                isValidRegNumber = Regex.IsMatch(deletingVehicleRegNumber, patternRegNumber);
                emptyRegNumberInput = string.IsNullOrEmpty(deletingVehicleRegNumber.Trim());               
                keyExists = myVehicleREgNumberDictionary.Keys.OfType<string>().Any(k => string.Equals(k, deletingVehicleRegNumber, StringComparison.InvariantCultureIgnoreCase));

                //valid input, only letter and number allowed:
                if (isValidRegNumber)                
                    Console.WriteLine("Wrong input. Only number bigger than zero and letter are allowed. \n");                

                //not empty input allowed:                
                else if (emptyRegNumberInput)
                    Console.WriteLine("Registrering number cannot be empty!");

                //searched registr. number should be in the garage:               
                else if (!keyExists)                
                    Console.WriteLine("Wrong input! There is no same registration number in the system.");                

            } while (isValidRegNumber | emptyRegNumberInput);

            if (keyExists)
                return deletingVehicleRegNumber;
            else return deletingVehicleRegNumber=null;
        }  

               
        private void SendOutCarFormGarage()
        {
            Garage<IVehicle> gar = new();   
            IHandler h = new Handler();

            Console.WriteLine("---Sending out vehicle:---");
            
            //listing car which will be deleted:
            foreach (var item in h.FindTheCarToSendOutFromTheGarage(gar))
            {
                Console.WriteLine();
                Console.WriteLine("The vehicle which will leave the garage:");             
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Vehicles in the garage after sending out:");
            h.ListTheVehiclesInTheGarage();
        }


        private void SearchForVehicle()
        {
            string inputString;
            int inputInt;
            do
            {
            label:
                Console.WriteLine("\nMenu:\n1: Find a vehicle with registration number\n2: Get vehicle types and how many vehicles are in a type\n3: Find a vehicle/vehicles by type, color and number of wheels\n4: Quit to the main menu\n");
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
                  

        private void GetVehicleByRegNumber()   
        {
            Console.WriteLine("\n---Finding vehicle by registration number:---");
            Garage<IVehicle> gar = new();
            IHandler h = new Handler();      
            h.FindVehicleWithRegNUmber(gar);
        }


        private void VehicleTypesWithNumberOfVehicles()
        {
            Console.WriteLine("\n---Finding vehicle types:---");
            Garage<IVehicle> gar = new();
            IHandler h = new Handler();
            h.FindVehicleTypes(gar);
        }

       
        private void SearcVehicleshByProperties()
        {    
            Console.WriteLine("\n---Searching parameters:---");

            string firstInput;
            do {
                Console.WriteLine("Choose first parameter: 1: type, 2: color, 3: number of wheels");
                firstInput = CorrectInput();                
                switch (firstInput) {                    
                        case "1": //type                       
                          SearcVehicleshByType();
                            break;
                        case "2": //color                        
                        SearcVehicleshByColor();
                            break;
                        case "3": //wheels                       
                        SearcVehicleshByWheels();
                            break;
                        default:
                        Console.WriteLine("Wrong input.");
                        break;
                    }    
            } while (!(firstInput == "1" || firstInput == "2" || firstInput == "3"));
        }
               

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
                Dictionary<string, List<IVehicle>> resultDictionary = (from sample in Handler.VehicleList group sample by sample.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());
                keyExistsForType = resultDictionary.Keys.Any(k => string.Equals(k, type, StringComparison.InvariantCultureIgnoreCase));  

                if (emptyTypeInput)
                    Console.WriteLine("Type cannot be empty!");
                else if (!keyExistsForType && !(type == "v" || type == "V"))
                    Console.WriteLine("There is no this type in the garage.");
            }
            while (emptyTypeInput || (!keyExistsForType && type != "v" && type != "V"));
            return type;
        }    


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
                Dictionary<string, List<IVehicle>> resultDictionary = (from sample in Handler.VehicleList group sample by sample.Color).ToDictionary(g => g.Key, g => g.ToList());
                keyExistsForColor = resultDictionary.Keys.Any(k => string.Equals(k, color, StringComparison.InvariantCultureIgnoreCase));  

                if (emptyColorInput)
                    Console.WriteLine("Type cannot be empty!");
                else if (!keyExistsForColor && !(color == "c" || color == "C"))
                    Console.WriteLine($"There is no {color} color in the garage.");
            }
            while (emptyColorInput || (!keyExistsForColor && color != "c" && color != "C"));
            return color;
        }   


        public string SearchedWheels()
        {
            string input;
            string wheelsString;
            bool emptyWheelInput;

            int wheelsInt;
            bool validIntWheelNumber;

            string patternWheel = @"[^0-9wW]";  
            bool validWheelToGetAllWheel;                                           

            //looking for the number of wheels we already have in the garage:           
            Dictionary<int, List<IVehicle>> resultDictionaryForWheels = (from sample in Handler.VehicleList group sample by sample.NumberOfWheels).ToDictionary(g => g.Key, g => g.ToList());
            bool keyExists;

            do      
            {               
                Console.WriteLine("Write the number of wheels, or for all wheels: enter w or W:");
                input = Console.ReadLine();
                wheelsString = input.Trim();

                //if input is empty:
                emptyWheelInput = string.IsNullOrEmpty(wheelsString.Trim());
                // if the specific wheel number is in the register:
                validIntWheelNumber = int.TryParse(wheelsString, out wheelsInt);
                // for all wheel number:
                validWheelToGetAllWheel = Regex.IsMatch(wheelsString, patternWheel);  

                //looking for wheel number in the garage:
                keyExists = resultDictionaryForWheels.Keys.OfType<int>().Any(k => int.Equals(k, wheelsInt));

                if (emptyWheelInput)
                    Console.WriteLine("Input cannot be empty!");

                else if(validIntWheelNumber && wheelsInt < 0)
                    Console.WriteLine("Only positive number allowed.");

                else if (!keyExists && validIntWheelNumber)
                    Console.WriteLine($"There is no vehicle with {wheelsInt} wheels in the garage.");

                else if (validWheelToGetAllWheel)                                                         
                    Console.WriteLine("Write a correct input. Use number, for all wheel use w or W.");       

                } while (emptyWheelInput || validWheelToGetAllWheel || (validIntWheelNumber && wheelsInt < 0) || (!keyExists && validIntWheelNumber));             
         
            return wheelsString;
        }


        private void SearcVehicleshByType()
        {          
            string secondInputToType;
            do
            {
                Console.WriteLine("Choose second parameter: 1: color, 2: number of wheels");
                IUI ui = new UI();
                IHandler h = new Handler();
                secondInputToType = ui.CorrectInput();

                if (secondInputToType == "1") // color
                {     
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in h.ListtypeAndColorAndWheel())                    
                        Console.WriteLine(item);                    
                }
                else if (secondInputToType == "2") //wheel
                {                   
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in h.ListtypeAndWheelAndColor())                    
                        Console.WriteLine(item);                    
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToType != "1" && secondInputToType != "2");
        }


        private void SearcVehicleshByColor()
        {          
            string secondInputToColor;
            do
            {
                Console.WriteLine("Choose second parameter: 1: type, 2: number of wheels");
                IUI ui = new UI();
                IHandler h = new Handler();
                secondInputToColor = ui.CorrectInput();
                if (secondInputToColor == "1") //type
                {                
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in h.ListcolorAndTypeAndWheels())                   
                        Console.WriteLine(item);                    
                }
                else if (secondInputToColor == "2") //wheel
                {                    
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in h.ListcolorAndWheelAndType())                   
                        Console.WriteLine(item);                    
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToColor != "1" && secondInputToColor != "2");
        }


        private void SearcVehicleshByWheels()
        {         
            string secondInputToWheel;
            do
            {
                Console.WriteLine("Choose second parameter: 1: type, 2: color");
                IUI ui = new UI();
                IHandler h = new Handler();
                secondInputToWheel = ui.CorrectInput();
                if (secondInputToWheel == "1") //type
                {
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in h.ListwheelAndTypeAndColor())                   
                        Console.WriteLine(item);                    
                }
                else if (secondInputToWheel == "2") //color
                {
                    Console.WriteLine(" \nVehicles: ");
                    foreach (var item in h.ListwheelAndColorAndType())                 
                        Console.WriteLine(item);                   
                }
                else Console.WriteLine("Wrong input.");
            } while (secondInputToWheel != "1" && secondInputToWheel != "2");
        }


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
        }

    }
}













