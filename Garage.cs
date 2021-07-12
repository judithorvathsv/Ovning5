using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Ovning5
{
    public class Garage<T> : IEnumerable<IVehicle>
    {

        public Garage(int startCapacity)        {           
            capacity = startCapacity;         
        }

        public Garage()
        {
        }


        private static int capacity;

        public static int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

       

        public static int FreePlacesInTheGarage;

        public static int CountFreePlacesInTheGarage() { 
        return FreePlacesInTheGarage = Capacity - MyVehiclesInGarage.Length;
        }


 
        private static IVehicle[] vehicles;

        public static IVehicle[] MyVehiclesInGarage
        {
            get
            {
                IHandler h = new Handler();
                return h.MakeTheListToArray();
            }  
            set { vehicles = value; }
        }


        IEnumerator<IVehicle> GetEnumerator()
        {                 
            foreach (var item in MyVehiclesInGarage)
                    yield return item;           
        }  
       
       IEnumerator<IVehicle> IEnumerable<IVehicle>.GetEnumerator()
       {
             foreach (var item in MyVehiclesInGarage)
                 yield return item; 
        }      
                
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}



