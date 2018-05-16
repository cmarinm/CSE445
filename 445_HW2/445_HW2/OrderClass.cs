using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _445_HW2
{
    class OrderClass
    {
        private int senderId;
        private int CardNo;
        private int amount;
        private int supId;

        public void setSup(int id)
        {
            this.supId = id;
        }

        public int getSup()
        {
            return this.supId;
        }

        public void setId(int id)
        {
            this.senderId = id;
        }
        public int getId()
        {
            return this.senderId;
        }
        public void setCard(int number)
        {
            this.CardNo = number;
        }

        public int getCard()
        {
            return this.CardNo;
        }

        public void setAmount(int amount)
        {
            this.amount = amount;
        }
        public int getAmount()
        {
            return this.amount;
        }
    }
}
