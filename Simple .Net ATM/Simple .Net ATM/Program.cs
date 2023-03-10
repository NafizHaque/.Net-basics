using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_.Net_ATM
{
    class Program
    {
        public static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose from one of the following options");
                Console.WriteLine("1.Deposit");
                Console.WriteLine("1.Withdraw");
                Console.WriteLine("1.Balance");
                Console.WriteLine("1.Exit");
            }

            void deposit(cardHolder currentHolder)
            {
                Console.WriteLine("Amount of £ deposit?");
                double deposit = Double.Parse(Console.ReadLine());
                currentHolder.setBalance(deposit);
                Console.WriteLine($"Thank you for the £ deposit. New Balance: {currentHolder.getBalance}");
            } 
            void withdraw(cardHolder currentHolder)
            {
                Console.WriteLine("Amount of £ withdraw?");
                double withdrawal = Double.Parse(Console.ReadLine());
                //Checksum for money
                if (currentHolder.getBalance() > withdrawal)
                {
                    Console.WriteLine("Not enough funds");
                }
                else
                {
                    currentHolder.setBalance(currentHolder.getBalance() - withdrawal);
                    Console.WriteLine("Thank you for withdrawal");
                }

            }
            void balance(cardHolder currentHolder)
            {
                Console.WriteLine($"Current Balance: {currentHolder.getBalance}");
            }


            List<cardHolder> cardList = new List<cardHolder>();
            cardList.Add(new cardHolder("4556626171784905", 1234, "John", 2678.36));
            cardList.Add(new cardHolder("4408915459776166", 7304, "Erik", 61.03));
            cardList.Add(new cardHolder("4532771698642316", 6727, "Harry", 932.80));
            cardList.Add(new cardHolder("4716054691134427", 2569, "Linda", 4009.96));


            Console.WriteLine("Welcome to Simple .Net ATM");
            Console.WriteLine("please insert card:");
            string cardNumber = "";
            cardHolder currentHolder = cardList[0];

            while(true)
            {
                try
                {
                    cardNumber = Console.ReadLine();
                    foreach (cardHolder card in cardList)
                    {
                        if (card.getNumber() == cardNumber)
                        {
                            currentHolder = card;
                        }
                    }
                    if (currentHolder != null) { break; }
                }
                catch { Console.WriteLine("Error. Please try again"); }
            }

            Console.WriteLine("please enter pin");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                   if (currentHolder.getPin() == userPin) { break; }
                    else { Console.WriteLine("error with pin. Please try again"); }
                }
                catch { Console.WriteLine("Error. Please try again"); }
            }
            Console.WriteLine($"Welcome {currentHolder.getName()} !");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());

                }
                catch { }
                if(option == 1) { deposit(currentHolder); }
                else if(option == 2) { withdraw(currentHolder); }
                else if (option == 3) { balance(currentHolder); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);

           
        }
        
    }
}
