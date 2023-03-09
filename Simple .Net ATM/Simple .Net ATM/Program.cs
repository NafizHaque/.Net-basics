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

        }
        
    }
}
