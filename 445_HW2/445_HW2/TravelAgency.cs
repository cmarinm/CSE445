using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/**
 * Author: Cesar Marin
 * CSE 445 HW2
 * */

namespace _445_HW2
{
    class TravelAgency
    {
        private int currPrice;
        private int prevPrice;
        private int name;
        static Random rnd = new Random();

        public TravelAgency(int name)
        {
            prevPrice = 100000;
            this.name = name;
        }

        public void run()
        {
            while (Program.getstatus())
            {
                Thread.Sleep(1500);
                //continue running
            }
        }
        public void hotelSale(Int32 pr, Int32 sup)
        {
            prevPrice = currPrice;
            currPrice = pr;
            if(currPrice < prevPrice) //check for sale again, to be sure
            {
                int rooms = (prevPrice - currPrice)%100 + rnd.Next(0,11); //generate close to random rooms
                OrderClass order = new OrderClass(); //create order class and set up
                order.setAmount(rooms);
                order.setId(name);
                order.setSup(sup);
                int card = rnd.Next(5000, 7001);
                order.setCard(card);
                string orderString = encoder(order); //encode into string
                Console.WriteLine("Agency {0} sending order for {1} rooms from supplier {2}", this.name, rooms, sup);
                Program.buffer.setOneCell(orderString); // send to buffer

            }

        }

        private string encoder(OrderClass order)
        {
            String orderstring;
            orderstring = order.getId() + " " + order.getCard() + " " + order.getAmount() + " " + order.getSup() + "";
            return orderstring;
        }
    }
}
