using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog
{
    class Contact
    {
       
        public string Name { get; }
        public string DeliveryMethod { get; set; }
        public string DeliveryProgram { get; set; }
        
        
        public Contact()
        {
            Name = "unknown contact";
            DeliveryMethod = "email";
            DeliveryProgram = "asaa";
        }


        public Contact(string name, string deliveryMethod, string deliveryProgram)
        {
            Name = name;
            DeliveryMethod = deliveryMethod;
            DeliveryProgram = deliveryProgram;
        }



        // Method that overrides the base class (System.Object) implementation.
        public override string ToString()
        {
            return Name;
        }
    }
}
