using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace Ovning5
{
  public  class Program
    {
        public  static void Main(string[] args) {

            IUI userInterface = new UI();         
            userInterface.Menu();
        }
    }   
}
