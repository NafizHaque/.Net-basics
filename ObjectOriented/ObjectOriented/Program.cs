using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes__Basics
{
    class program
    {
        static void Main(string[] args)
        {

            // Creating object

            Human denis = new Human("denis", "smith", "brown", 18);
            denis.introduction();



            Console.Read();
        }
    }
}