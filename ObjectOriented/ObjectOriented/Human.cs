using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes__Basics
{
    internal class Human
    {
        //member variable
        private string firstName;
        private string lastName;
        private int age;
        private string eyeColour;
       
      


        //Contructors
        public Human(string firstName, string lastName, string eyeColour, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColour = eyeColour;
            this.age = age;

        }


        public void introduction()
        {
            Console.WriteLine($"Hello my name is {firstName} {lastName}, i have {eyeColour} eyes and im {age}");
        }

        
    }
}
