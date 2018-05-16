using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static _445_HW2.Program;

namespace _445_HW2
{
    public struct Lock{
        public int rw;     //0 = read, 1 = write
        public bool lckd;   // wether its locked or not
    }
    class Program
    {
        public delegate void priceCutEvent(Int32 pr, Int32 supplier);
        public delegate void orderMade();
        public static bool HotelsAlive;
        public static MultiBuffer buffer;
        static void Main(string[] args)
        {
            // 5 travel agencies
            // 2 hotel suppliers
            // 3 buffer cells
            Console.WriteLine("Welcome to the hotel supplier porgram\n" +
                "please enter a room tax:(eg 10.5)");
            double tax = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Tax is set to {0}", tax);
            Console.WriteLine("Please enter a location charge:(eg 20.5)");
            double loc = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Location Charge is set to {0}", loc);

            buffer = new MultiBuffer(3);



            TravelAgency tr1 = new TravelAgency(1);
            TravelAgency tr2 = new TravelAgency(2);
            TravelAgency tr3 = new TravelAgency(3);
            TravelAgency tr4 = new TravelAgency(4);
            TravelAgency tr5 = new TravelAgency(5);

            HotelSupplier h1 = new HotelSupplier(1000, 1, tax, loc);
            HotelSupplier h2 = new HotelSupplier(1000, 2, tax, loc);

            HotelSupplier.pricecut += new priceCutEvent(tr1.hotelSale);
            HotelSupplier.pricecut += new priceCutEvent(tr2.hotelSale);
            HotelSupplier.pricecut += new priceCutEvent(tr3.hotelSale);
            HotelSupplier.pricecut += new priceCutEvent(tr4.hotelSale);
            HotelSupplier.pricecut += new priceCutEvent(tr5.hotelSale);

            MultiBuffer.orderset += new orderMade(h1.newOrder);
            MultiBuffer.orderset += new orderMade(h2.newOrder);

            //all event subscriptions made

            Thread t1thread = new Thread(tr1.run);
            Thread t2thread = new Thread(tr2.run);
            Thread t3thread = new Thread(tr3.run);
            Thread t4thread = new Thread(tr4.run);
            Thread t5thread = new Thread(tr5.run);

            Thread h1thread = new Thread(h1.run);
            Thread h2thread = new Thread(h2.run);
            HotelsAlive = true;

            t1thread.Start();
            t2thread.Start();
            t3thread.Start();
            t4thread.Start();
            t5thread.Start();

            h1thread.Start();
            h2thread.Start();

            h1thread.Join();
            h2thread.Join();

            HotelsAlive = false;

            t1thread.Join();
            t2thread.Join();
            t3thread.Join();
            t4thread.Join();
            t5thread.Join();

            Console.WriteLine("Finished, press enter to exit");
            Console.Read();



        }
        public static bool getstatus()
        {
            return HotelsAlive; // to check when to finish the agency threads
        }
    }


    class MultiBuffer
    {
        public static event orderMade orderset;
        private string[] buffer;
        private int size;
        static Semaphore sem = new Semaphore(3, 3);
        private Lock[] locks; //set up locks and rw flags for the buffer
        private Object bufferpulse = new Object(); // object to be used by monitor to avoid deadlocks when writing

        public MultiBuffer(int size)
        {
            this.size = size;
            buffer = new string[size];
            locks = new Lock[size];
            for(int i=0; i < size; i++)
            {
                locks[i].rw = 1;
                locks[i].lckd = false;
            }

        }

        public string getOneCell(int id)
        {
            string temp = "";
            sem.WaitOne();
            for(int i = 0; i< size; i++){ //check list
                if (!locks[i].lckd && locks[i].rw == 0) // check for locks, flag for read
                {
                    temp = buffer[i];
                    string[] elements = temp.Split(null);
                    if (Convert.ToInt32(elements[3]) == id)
                    {
                        // this is the correct supplier
                        locks[i].rw = 1;
                        sem.Release();
                        lock (bufferpulse) { Monitor.Pulse(bufferpulse); } //pulse to monitor on object
                        
                        return temp;
                    }
                }
            }

            // in this case, no orders matched to the supplier checking, still release and pulse, but return null
            sem.Release();
            lock (bufferpulse) { Monitor.Pulse(bufferpulse); }
            return null;
        }

        public void setOneCell(string order)
        {
            
            bool set = false; // to check when writing has happened
            while (!set)
            {
                sem.WaitOne();
                for (int i = 0; i < size; i++)
                {
                    if ((!locks[i].lckd) && (locks[i].rw == 1)) // check conditions, flag for write, not locked
                    {
                        locks[i].lckd = true; // lock cell
                        buffer[i] = order;
                        locks[i].rw = 0;
                        set = true;
                        locks[i].lckd = false; //unlock cell
                        sem.Release(); 
                        orderset(); //call event
                        return; // will exit here
                    }
                }
                //if we get here, the buffer was full for writers, we have to release semaphore to let readers in
                // otherwise we could get a deadlock, to we wait on the object for the monitor pulse, which readers do
                // once that happens, we check list again, until we are able to set an order in the buffer.
                sem.Release();
                lock (bufferpulse)
                {
                    Monitor.Wait(bufferpulse);
                }

            }


        }


    }
}
