using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_.Net_ATM
{
    class cardHolder
    {
        String cardNumber;
        int pin;
        String name;
        double balance;

        public cardHolder(string cardNumber, int pin, string name, double balance)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.name = name;
            this.balance = balance;
        }

        public String getNumber()
        {
            return cardNumber;
        }
        public int getPin()
        {
            return pin;
        }
        public String getName()
        {
            return name;
        }
        public Double getBalance()
        {
            return balance;
        }

        public void setNumber(String newNumber)
        {
           cardNumber = newNumber;
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }
        public void setName(String newName)
        {
            name = newName;
        }

        public void setBalance(double newBalance)
        {
           balance = newBalance;
        }

    }
}
