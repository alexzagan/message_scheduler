using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog
{
    class Client
    {

        public string Name { get; set; }
        List<Contact> ContactList;
        
        
        public Client()
        {
            Name = "unknown client";
        }


        public Client(string name, List<Contact> contactList)
        {
            Name = name;
            ContactList = contactList;
        }

        public List<Contact> GetListcontact
        {
            get { return ContactList; }
        }


        

    // Method that overrides the base class (System.Object) implementation.
    public override string ToString()
        {
            return Name;
        }
    }
}
