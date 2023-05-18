
Arrow arrow;
int choice = 1;

switch (choice)
{
    case 1:
        Console.WriteLine("Ye rest and recover your health");
        break;
    case 2:
        Console.WriteLine("Raiding the port town get ye 60 doubloons");
        break;
    case 3:
        Console.WriteLine("The wind is at your back, open horizon ahead");
        break;
    case 4:
        Console.WriteLine("Its a baby kraken eating a small toy boat!");
        break;
    default:
        Console.WriteLine("Sorry I dont know that option!");
        break;

}

while (true)
{
    Console.Write(" 1. Elite \n 2. Beginner \n 3. Marksmen \n 4. Custom ");
    int choice = Convert.ToInt32(Console.ReadLine());
    arrow = choice switch
    {
        1 => Arrow.EliteArrow(),
        2 => Arrow.BeginnerArrow(),
        3 => Arrow.MarksmenArrow(),
        4 => GetArrow()
    };

    Console.WriteLine($"That arrow costs {arrow.Cost()} gold.");
    Console.WriteLine($"Head: {arrow._Arrowhead}\nFletch: {arrow._Fletching}\nLength: {arrow._Length}");
}





Arrow GetArrow()
{
    Arrowhead arrowhead = GetArrowheadType();
    Fletching fletching = GetFletchingType();
    float length = GetLength();

    return new Arrow(arrowhead, fletching, length);
}

Arrowhead GetArrowheadType()
{
    Console.Write("Arrowhead type (steel, wood, obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Arrowhead.Steel,
        "wood" => Arrowhead.Wood,
        "obsidian" => Arrowhead.Obsidian
    };
}

Fletching GetFletchingType()
{
    Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.Plastic,
        "turkey feather" => Fletching.TurkeyFeathers,
        "goose feather" => Fletching.GooseFeathers
    };
}

float GetLength()
{
    float length = 0;

    while (length < 60 || length > 100)
    {
        Console.Write("Arrow length (between 60 and 100): ");
        length = Convert.ToSingle(Console.ReadLine());
    }

    return length;
}

public class Arrow
{
    public Arrowhead _Arrowhead { get; }
    public Fletching _Fletching { get; }
    public float _Length { get; }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _Arrowhead = arrowhead;
        _Fletching = fletching;
        _Length = length;
    }

    public static Arrow EliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95);
    public static Arrow BeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75);
    public static Arrow MarksmenArrow() => new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65);
    public float Cost()
    {
        
        {
            float arrowheadCost = _Arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5
            };

            float fletchingCost = _Fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3
            };

            float shaftCost = 0.05f * _Length;

            return arrowheadCost + fletchingCost + shaftCost;
        }
    }
}

public enum Arrowhead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }



}