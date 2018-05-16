using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static _445_HW2.Program;

namespace _445_HW2
{
    class HotelSupplier
    {
        public int name;
        private int counter;
        private int unitprice;
        private double taxrate;
        private double locationcharge;
        static Random rnd = new Random();
        public static event priceCutEvent pricecut;

        public HotelSupplier(int initialprice, int name, double rate, double loc)
        {
            this.unitprice = initialprice;
            this.taxrate = rate;
            this.locationcharge = loc;
            this.name = name;
            this.counter = 0;
        }
        // called by order set event
        public void newOrder()
        {
            string orderst = Program.buffer.getOneCell(this.name);
            if (orderst != null)
            { 
                OrderClass order = decoder(orderst);
                Thread process = new Thread(() => OrderProcessingThread(order,this.unitprice,this.taxrate, this.locationcharge));
                process.Start();
            }


        }
        public void run()
        {
            while(counter < 11)
            {
                pricingModel();
                Thread.Sleep(700);
            }
        }
        private void pricingModel()
        {
            int price = rnd.Next(0,1000); //random price set
            

            if (price < unitprice)
            {
                counter++;
                unitprice = price;
                pricecut(unitprice, this.name); // call the event
            }
            else unitprice = price; // still set unit price to new price.

        }

        //ran as a thread from newOrder
        public static void OrderProcessingThread(OrderClass orderobject, int price, double rate, double loc)
        {
            int carno = orderobject.getCard();
            if(carno < 5000 || carno > 7000)
            {
                Console.WriteLine("Card number {0} declined by supplier", carno);
                return;
            }

            double total = orderobject.getAmount() * price;
            total += total * rate + loc;
            Console.WriteLine("Order processed by supplier {0} from agency {1}, total for {2} rooms is {3} charged to card {4}\n",
                orderobject.getSup(), orderobject.getId(), orderobject.getAmount(), total, carno);
            

        }

        //simple method to decode
        public OrderClass decoder(String encode)
        {
            OrderClass order = new OrderClass();
            String[] elements = encode.Split(null);
            int id = Convert.ToInt32(elements[0]);
            int card = Convert.ToInt32(elements[1]);
            int amount = Convert.ToInt32(elements[2]);
            int sup = Convert.ToInt32(elements[3]);
            order.setId(id);
            order.setCard(card);
            order.setAmount(amount);
            order.setSup(sup);

            return order;
        }
    }
}
