using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog
{
    class Message
    {
       public string reciver { get; set; }
       public string text { get; set; }
       public string deliverymethod { get; set; }
       public string deliveryProgram { get; set; }

       public Message()
        {
            reciver = "unknown";
            text = "unknown";
            deliverymethod = "email";
            deliveryProgram = "no";
        }
        
       public Message(string _reciver, string _text,string _deliveriMethod, string _delyveryProgram)
        {
            reciver = _reciver;
            text = _text;
            deliverymethod = _deliveriMethod;
            deliveryProgram = _delyveryProgram;
            
        }



    }
}
