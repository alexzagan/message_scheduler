using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace prog
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Message> MessageList = new List<Message>();
            Console.WriteLine(getRealHour() + ":" + getRealMinute());
            // For Interval in Minutes 
            // This Scheduler will start at 22:00 and call after every 30 Minutes
            //This Scheduler will start when you run the program + 1 minute and call after every minute
            // IntervalInSeconds(start_hour, start_minute, minutes)
            MyScheduler.IntervalInMinutes(getRealHour(), getRealMinute() + 1, 1,
            () =>
            {
                if (messagelist_isEmpty(MessageList) == true)
                {
                    Console.WriteLine("The MessageList is empty.");
                }
                else
                {
                    for(int i=0; i< MessageList.Count; i++)
                    {

                        if (MessageAvailableToSend(MessageList[i].deliveryProgram))
                        {
                            SendMessageTo(MessageList[i].reciver, MessageList[i].deliverymethod);
                            MessageList.RemoveAt(i);
                        }
                        else
                        {
                            Console.WriteLine("--------Message unsend, still in list--------");
                        }
                    }
                }
            });

            Contact co1 = new Contact("John Doe", "email", "asaa");
            Contact co2 = new Contact("Jane Doe", "fax", "15:40-15:50");
            Contact co3 = new Contact("Collect", "hl7", "16:00-16:30");
            
            List<Contact> ContactList = new List<Contact>();
            ContactList.Add(co1);
            ContactList.Add(co2);
            ContactList.Add(co3);

            Client c1 = new Client("John Doe Medical Office", ContactList);

            Contact co4 = new Contact("John Doe", "email", "asaa");
            Contact co5 = new Contact("Jane Doe", "fax", "6:00-7:00");
            Contact co6 = new Contact("Collect", "hl7", "8:00-8:30");

            List<Contact> ContactList2 = new List<Contact>();
            ContactList2.Add(co4);
            ContactList2.Add(co5);
            ContactList2.Add(co6);
            Client c2 = new Client("Hospital Suceava", ContactList2);

            Console.WriteLine("1." + c1.Name + "\n2." + c2.Name);
            while (true)
            {
                Console.WriteLine("Choose one client: ");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Write the message:");
                string msg = Console.ReadLine();
                string clientstring;
                if (x == 1)
                {
                    clientstring = c1.Name;
                    
                    foreach (Contact contact in c1.GetListcontact)
                    {
                        Message m = new Message(contact.Name, msg, contact.DeliveryMethod, contact.DeliveryProgram);
                        MessageList.Add(m);
                    }

                }
                if(x == 2)
                {
                    foreach (Contact contact in c2.GetListcontact)
                    {
                        Message m = new Message(contact.Name, msg, contact.DeliveryMethod, contact.DeliveryProgram);
                        MessageList.Add(m);
                    }
                }
                foreach(Message m in MessageList)
                {
                    Console.WriteLine("{0}, {1},{2},{3}", m.reciver, m.text, m.deliverymethod, m.deliveryProgram);
                }
                
            }

            Console.ReadKey();
        }

        private static int getRealMinute()
        {
            string date = DateTime.Now.ToString("H:mm");
            string[] date2 = date.Split(':');
            int min_start = int.Parse(date2[1]);
            return min_start;
        }

        private static int getRealHour()
        {
            string date = DateTime.Now.ToString("H:mm");
            string[] date2 = date.Split(':');
            int hour_start = int.Parse(date2[0]);
            return hour_start;
        }
        private static void SendMessageTo(string reciver, string deliverymethod)
        {            
            Console.WriteLine("Message send to " + reciver + " from " + deliverymethod);

        }
        private static bool MessageAvailableToSend(string deliveryProgram)
        {
            string interval, time1, time2;
            int h1, h2, min1, min2;

            if (deliveryProgram == "asaa")
            {
                return true;
            }
            else if(deliveryProgram != "asaa")
            {
                interval = deliveryProgram;
                string[] intervall = interval.Split('-');
                time1 = intervall[0].ToString();
                time2 = intervall[1].ToString();
                string[] time11 = time1.Split(':');
                string[] time22 = time2.Split(':');
                h1 = int.Parse(time11[0]);
                min1 = int.Parse(time11[1]);
                h2 = int.Parse(time22[0]);
                min2 = int.Parse(time22[1]);
                DateTime hourMinute;
                hourMinute = DateTime.Now;
                if ( (hourMinute.Hour >= h1 && hourMinute.Hour >= min1)&&(hourMinute.Hour <= h2 && hourMinute.Hour <= min2))
                {
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            } 
        }
        private static bool messagelist_isEmpty(List<Message> messageList)
        {
            if(!messageList.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
