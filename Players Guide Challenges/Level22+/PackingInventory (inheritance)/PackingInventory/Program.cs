
PackingIventory.Run();

class PackingIventory
{

    public static void Run()
    {
        Pack pack = new Pack(10, 20, 30);
        int? choice;
        while (true)
        {
            Console.WriteLine($"Pack is currently at {pack.ItemCount}/{pack.MaxItems} items, {pack.CurrentWeight}/{pack.MaxWeight} weight, and {pack.CurrentVolume}/{pack.MaxVolume} volume.");
            
            Console.WriteLine("What do you want to add?");
            Console.WriteLine("1 - Rope");
            Console.WriteLine("2 - Water");
            Console.WriteLine("3 - Sword");

            choice = Convert.ToInt32(Console.ReadLine());

            InventoryItem newItem = choice switch
            {

                1 => new Rope(),
                2 => new Water(),
                3 => new Sword(),
            };


            
            if (!pack.Add(newItem))
            {
                
                Console.WriteLine("Could not add this to the pack.");

            }
            Console.WriteLine($"Current Items in Pack: {pack.ToString()} ");

        }
    }
}


public class InventoryItem
{
    public double Volume { get; set; }
    public double Weight { get; set; }

    public InventoryItem(double volume, double weight)
    {
        Volume = volume;
        Weight = weight;

    }
}
public class Pack
{
    private InventoryItem[] items;
    public double MaxVolume { get; }
    public double MaxWeight { get; }
    public int MaxItems { get; }
    public double CurrentVolume { get; set; }
    public double CurrentWeight { get; set; }

    public int ItemCount;


    public Pack(double maxVolume, double maxWeight, int maxItems)
    {
        MaxVolume = maxVolume;
        MaxWeight = maxWeight;
        items = new InventoryItem[maxItems];
        CurrentVolume = 0;
        CurrentWeight = 0;
        ItemCount = 0;
    }


    public bool Add(InventoryItem newItem)
    {
        if (newItem.Weight + CurrentWeight < MaxWeight || newItem.Volume + CurrentVolume < MaxVolume)
        {
            items[ItemCount] = newItem;
            
            ItemUpdate(newItem);
            return true;
        }
        else
        {
            return false;
        }

    }

    private void ItemUpdate(InventoryItem newItem)
    {
        ItemCount += 1;
        CurrentWeight += newItem.Weight;
        CurrentVolume += newItem.Volume;
    }

    public override string ToString()
    {
        string message = "Pack Contains: ";
        for (int i = 0; i < ItemCount; i++)
        {
            message += items[i].ToString() + ", ";
        }
        return message;
    }
}


public class Rope : InventoryItem { public Rope() : base(1.5, 1) { } public override string ToString() => "Rope";}

public class Water : InventoryItem {public Water() : base(2, 3) { } public override string ToString() => "Water"; }

public class Sword : InventoryItem { public Sword() : base(3, 5) { } public override string ToString() => "Sword"; }




