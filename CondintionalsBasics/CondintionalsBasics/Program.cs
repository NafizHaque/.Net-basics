public class ConditionalsBasics
{
    public static void Main()
    {
        // Simple if statement examples

        Console.Write("Enter Temperature: ");
        string temperatureInput = Console.ReadLine();
        int temperature;
        // Try to parse the string (returns a boolean)
        bool isTemperature = int.TryParse(temperatureInput, out temperature );

        if(temperature < 10)
        {
            Console.WriteLine("Very Cold");
        }
        else if (temperature == 10)
        {
            Console.WriteLine("Perfect Temperature");
        }
        else 
        {
            Console.WriteLine("Very Warm Day");
        }

        // Switch cases Examples

        int age = 25;

        switch (age)
        {
            case 15:
                Console.WriteLine("you are 15");
                break;
            case 20:
                Console.WriteLine("you are 20");
                break;

            default:
                Console.WriteLine("How old are you then");
                break;
        }
        //if statement shortcuts

        // condition ? first expression : second expression;
        // condition has to be either true or false
        // the conditional operator is right - associative
        // the expression a ? b: c ? d : e
        // is evaluated as a ? b : (c ? d : e),
        //not as (a? b : c) ? d: e.
        // the conditional operator cannot be overlooked

        // energy kelvin of water 
        int energy = 474;
        string stateofMatter;

        stateofMatter = energy < 273 ? "Ice" : energy <373 ? "Water" : "Steam";

        Console.WriteLine($"State of matter is: {stateofMatter}");

        // Different Loops Examples


        //For Loop

        for(int counter = 0; counter < 10; counter +=2)
        {
            Console.WriteLine($"Counter by 2: {counter}");
        }

        Console.WriteLine("press enter to step through while loop");
        //While loop
        int whileCounter = 0;
        while(whileCounter < 10)
        {
            Console.ReadLine();
            Console.WriteLine($"increasing counter to: {whileCounter} by 1");
            whileCounter++;

        }
        //Do While Loop

        int doCounter = 0;
 
        do
        {
            Console.WriteLine($"The Do Counter by 1: {doCounter}");
            doCounter++;
        }while(doCounter < 10);


        //breaks and continues and their uses
        Console.WriteLine("only Odd numbers are shown");
        for (int i = 0; i < 10; i++)
        {
            if(i % 2 == 0)
            {
                Console.WriteLine("Even");
                continue;
            }
            Console.WriteLine(i);
        }

        decimal d = (decimal)1.23456789123456789;
        Console.WriteLine(d); // Prints 1.23456789123457
        decimal e = 1.23456789123456789M;
        Console.WriteLine(e); // Prints 1.23456789123456789

        List<int> listing = new List<int>()
        {1, 2 , 3 , 4};
        Console.WriteLine(listing[1]);



        //Console Read waits for the program to be terminated here
        Console.Read();
        
    }

}
