


Point point1 = new Point(2, 3);
Point point2 = new Point(-4, 0);
Console.WriteLine($"point1: {point1.X}, {point1.Y}");
Console.WriteLine($"point2: {point2.X}, {point2.Y}");

Colour customColour = new Colour(255, 51, 153 );
Colour premadeColour = Colour.Green;

Console.WriteLine($"Custom Colour RGB values: R:{customColour._Red} G:{customColour._Green} B:{customColour._Blue}");
Console.WriteLine($"Premade Colour RGB values: R:{premadeColour._Red} G:{premadeColour._Green} B:{premadeColour._Blue}");


enumCardColour[] colourArray = new enumCardColour[] { enumCardColour.Blue, enumCardColour.Green, enumCardColour.Red, enumCardColour.Yellow };
enumCardRank[] rankArray = new enumCardRank[] { enumCardRank.One, enumCardRank.Two, enumCardRank.Three, enumCardRank.Four, enumCardRank.Five, enumCardRank.Six, enumCardRank.Seven, enumCardRank.Eight, enumCardRank.Nine, enumCardRank.Ten, enumCardRank.Dollar, enumCardRank.Percent, enumCardRank.Power, enumCardRank.Ampersand };

foreach (enumCardColour colour in colourArray)
{
    foreach (enumCardRank rank in rankArray)
    {
        Card card = new Card(colour, rank);

        Console.WriteLine($"The {card.CardColour} {card.CardRank}");
    }
}

Door door = new Door("1111");

/*while(true)
{
    Console.Write($"The Doopr is currently {door.DoorState} What would you like to do?: ");
    string action = Console.ReadLine();
    switch(action)
    {
        case "open":
            door.ChangeDoorState(enumDoorAction.Open);
            break;
        case "lock":
            door.ChangeDoorState(enumDoorAction.Lock);
            break;
        case "unlock":
            door.ChangeDoorState(enumDoorAction.Unlock);
            break;
        case "close":
            door.ChangeDoorState(enumDoorAction.Close);
            break;
        case "new code":
            Console.Write($"Old code?: ");
            string? oldCode = Console.ReadLine();
            Console.Write($"New code?: ");
            string? newCode = Console.ReadLine();
            door.ChangeDoorCode(oldCode, newCode);
            break;
             

    }


}*/

while(true)
{
    Console.Write($"Enter password ");
    string pass = Console.ReadLine();
    PasswordValidator validator = new PasswordValidator();
    if (validator.PasswordCheck(pass))
    {
        Console.WriteLine("nice password");
    }
    else
    {
        Console.WriteLine("bad password");
    }

}

class Point
{
    public int X { get; }
    public int Y { get; }
    public Point()
    {
        X = 0; Y = 0;
    }
    public Point(int x, int y)
    {
        X = x; Y = y; 
    }
}
class Colour
{
    public int _Red { get; }
    public int _Green { get; }
    public int _Blue { get; }


    public Colour() : this(0, 0, 0) { }

    public Colour(int red, int green, int blue )
    {
        _Red = red; _Green = green; _Blue = blue; 
    }

    public static Colour White { get; } = new Colour(255, 255, 255);
    public static Colour Orange { get; } = new Colour(255, 165, 0);
    public static Colour Yellow { get; } = new Colour(255, 255, 0);
    public static Colour Green { get; } = new Colour(0, 255, 0);
    public static Colour Blue { get; } = new Colour(0, 0, 255);
    public static Colour Purple { get; } = new Colour(128, 0, 128);
}


class Card
{
    public enumCardColour CardColour { get;}
    public enumCardRank CardRank { get; }

    public Card( enumCardColour cardColour, enumCardRank cardRank )
    {
        CardColour = cardColour;
        CardRank = cardRank;
    }

    public bool IsSymbol()
    {
        if ( CardRank == enumCardRank.Ampersand || CardRank == enumCardRank.Power || CardRank == enumCardRank.Percent || CardRank == enumCardRank.Dollar)
        {
            return true;
        }
        else { return false; }
    }
    public bool IsNumber()
    {
        if (IsSymbol() == true )
        {
            return false;

        }
        else { return true; }
    }
       
}


class Door
{   
    public enumDoorState DoorState { get; private set; }
    public string DoorCode;

    public Door(string passcode)
    {
        DoorCode = passcode;
        DoorState = enumDoorState.Locked;
    }

    public void ChangeDoorState(enumDoorAction action)
    {
        if (action == enumDoorAction.Unlock && DoorState == enumDoorState.Locked)
        {
            string ?passcodeInput = "";
            Console.WriteLine("Input the Passcode to lock: ");
            while (passcodeInput != DoorCode)
            {
                passcodeInput = Console.ReadLine();
            }
            Console.WriteLine($"Success! Door unlocked {passcodeInput}");
            DoorState = enumDoorState.Closed;

        }
        else if (action == enumDoorAction.Lock && DoorState == enumDoorState.Closed) { DoorState = enumDoorState.Locked;}
        else if (action == enumDoorAction.Open && DoorState == enumDoorState.Closed) { DoorState = enumDoorState.Open; }
        else if (action == enumDoorAction.Close && DoorState == enumDoorState.Open) { DoorState = enumDoorState.Closed; }

    }
    public void ChangeDoorCode(string oldCode, string newCode)
    {
        if (oldCode == DoorCode)
        {
            DoorCode = newCode;
            Console.WriteLine($"Door code changed! New code: {DoorCode}");

        }
        else
        {
            Console.WriteLine($"Failed!");
        }

    }


}

class PasswordValidator
{
    private bool Uppercase = false;
    private bool Lowercase = false;
    private bool Number = false;
    private bool ContainsContraband = false;

    private bool PasswordLength(string password)
    {
        int passLength = password.Length;
        if (passLength < 14 && passLength > 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool PasswordCheck(string password)
    {

        foreach (char letter in password)
        {
            if (char.IsUpper(letter) && Uppercase == false)
            {
                Uppercase = true;
            }
            else if (char.IsLower(letter) && Lowercase == false)
            {

                Lowercase = true;
            }
            else if (char.IsDigit(letter) && Number == false)
            {

                Number = true;
            }
            else if (letter == 'T' || letter == '&' && ContainsContraband == false)
            {


                ContainsContraband = true;
            }
        }

        if(Uppercase && Lowercase && Number && !ContainsContraband && PasswordLength(password))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
 

enum enumDoorState { Open, Closed, Locked};
enum enumDoorAction { Open, Close, Lock, Unlock}
enum enumCardColour { Red, Green, Blue, Yellow};
enum enumCardRank{ One,Two,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Dollar,Percent,Power,Ampersand};

