using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ovning5
{
    public class Garage<T> : IEnumerable<Vehicle>
    {

       private int capacity;     

        public Garage()        {
            Handler h = new Handler();
            this.capacity = Handler.GiveCapacityToGarageFromUI();            //00000000000000000000000000000000000000000 ????????
        }
       
        private static Vehicle[] vehicles;





        /*
         * 
         * STATIC MAKETHELISTTOARRAY BOL SIMAT CSINALTAM A HANDLERBAN.
        public static Vehicle[] MyVehiclesInGarage
        { 
            get  {
                IHandler h = new Handler();
                return h.MakeTheListToArray(); }  //0000000000000000000000000000000000000000000000000000000   mukodik 07.08.17:32
            set { vehicles = value; }
        }
         */

        public static Vehicle[] MyVehiclesInGarage
        {
            get
            {
                IHandler h = new Handler();
                return h.MakeTheListToArray();
            }  //0000000000000000000000000000000000000000000000000000000   mukodik 07.08.17:32
            set { vehicles = value; }
        }




        IEnumerator<Vehicle> GetEnumerator()
        {                 
            foreach (var item in MyVehiclesInGarage)
                    yield return item;           
        }      


       
       IEnumerator<Vehicle> IEnumerable<Vehicle>.GetEnumerator()
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



