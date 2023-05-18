
FountainOfObects game = GameGenerate(4);
game.Run();



FountainOfObects GameGenerate(int size)
{
    MapGenerator board = new MapGenerator(size, size);
    Monster[] monsters = new Monster[0];
    if (size > 3)
    {
        board.SetRoomLocation(new Location(0, 0), RoomType.Entrance);
        board.SetRoomLocation(new Location(1, 2), RoomType.Fountain);
        board.SetRoomLocation(new Location(3, 2), RoomType.Pit);

        monsters = new Monster[1]
        {
            new Maelstrom(new Location(2,2))
        };
    }
    if (size > 5)
    {
        board.SetRoomLocation(new Location(0, 2), RoomType.Pit);
    }
    if (size > 7)
    {
        board.SetRoomLocation(new Location(7, 0), RoomType.Pit);
        board.SetRoomLocation(new Location(4, 5), RoomType.Pit);
        monsters = new Monster[2]
        {
            new Maelstrom(new Location(2,2)),
            new Maelstrom(new Location(5,5))
        };
    }
    return new FountainOfObects(board, new Player(new Location(0, 0)), monsters);
}


public class FountainOfObects
{
    public MapGenerator CurrentBoard { get; }
    public Player Player { get; }
    public Monster[] Monsters { get; }

    public FountainOfObects(MapGenerator board, Player player, Monster[] monsters)
    {
        CurrentBoard = board;
        Player = player;
        Monsters = monsters;

    }


    public void Run()
    {

        bool gameComplete = false;
        while (!gameComplete)
        {
            CurrentRoom();
            if (DisplayRoomMessage != null) { ConsoleHelper.WriteLine(DisplayRoomMessage(), ConsoleColor.Gray); }
            ICommand command = GetUserCommand();
            command.Execute(this);
            Isense sense = new PitSense();
            if (sense.SenseNear(this))
            {
                sense.DisplaySenseMessage(this);
            }

           
        }


    }


    private void CurrentRoom()
    {
        ConsoleHelper.WriteLine($"You are in a Room at Row: {Player.Location.X} Column: {Player.Location.Y}", ConsoleColor.Gray);
    }

    private string  DisplayRoomMessage()
    {
        if (CurrentBoard.Matrix[Player.Location.X,Player.Location.Y] is Room)
        {
            return CurrentBoard.Matrix[Player.Location.X, Player.Location.Y].RoomMessage;
        }
        else { return null ; }
    }


    private ICommand GetUserCommand()
    {
        while (true)
        {
            ConsoleHelper.Write("What do you want to do? ", ConsoleColor.White);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();

            if (input == "move north") return new MoveDirection(Direction.North);
            if (input == "move south") return new MoveDirection(Direction.South);
            if (input == "move east") return new MoveDirection(Direction.East);
            if (input == "move west") return new MoveDirection(Direction.West);
            if (input == "enable fountain") return new FountainCommands();
            ConsoleHelper.WriteLine($"I did not understand '{input}'.", ConsoleColor.Red);


        }

    }

}


public class MapGenerator
{
    public Room[,] Matrix { get; set; }

    public int MRow { get; }
    public int MCol { get; }

    public MapGenerator(int row, int col)
    {
        MRow = row;
        MCol = col;
        Matrix = new Room[MRow, MCol];

    }
    public void SetRoomLocation(Location coordinates, RoomType type)
    {
        switch (type)
        {
            case RoomType.Entrance:
                Matrix[coordinates.X, coordinates.Y] = new EntanceRoom(); break;
            case RoomType.Fountain:
                Matrix[coordinates.X, coordinates.Y] = new FountainRoom(); break;
            case RoomType.Pit:
                Matrix[coordinates.X, coordinates.Y] = new PitRoom(); break;
        }
    }

    public void UpdateRoomLocation(Location coordinates, Room room) { Matrix[coordinates.X, coordinates.Y] = room; }

    public Room? GetRoom(Location coordinates) => IsLegalMove(coordinates) ? Matrix[coordinates.X, coordinates.Y] : null;
    public RoomType GetRoomType(Location coordinates) 
    {
        Console.WriteLine($"im at test: {coordinates.X} and {coordinates.Y}");
        if (IsLegalMove(coordinates))
        {
            if (Matrix[coordinates.X, coordinates.Y] != null)
            {
                return Matrix[coordinates.X, coordinates.Y].RoomT;
            }
        }
        return RoomType.NullRoom;
    }


    public bool HasNeigbourNode(Location coordinates, RoomType type)
    {

        if (GetRoomType(new Location(coordinates.X - 1, coordinates.Y - 1))== type) return true;
        if (GetRoomType(new Location(coordinates.X - 1, coordinates.Y)) == type) return true;
        if (GetRoomType(new Location(coordinates.X - 1, coordinates.Y + 1)) == type) return true;
        if (GetRoomType(new Location(coordinates.X, coordinates.Y - 1)) == type) return true;
        if (GetRoomType(new Location(coordinates.X, coordinates.Y)) == type) return true;
        if (GetRoomType(new Location(coordinates.X, coordinates.Y + 1)) == type) return true;
        if (GetRoomType(new Location(coordinates.X + 1, coordinates.Y - 1)) == type) return true;
        if (GetRoomType(new Location(coordinates.X + 1, coordinates.Y)) == type) return true;
        if (GetRoomType(new Location(coordinates.X + 1, coordinates.Y + 1)) == type) return true;
        return false;
    }

    public bool IsLegalMove(Location coordinates) => coordinates.Y >= 0 && coordinates.X >= 0 && coordinates.Y < Matrix.GetLength(1) && coordinates.X < Matrix.GetLength(0);
}

public class Player
{
    public Location Location { get; set; }

    public bool IsAlive { get; private set; } = true;

    public string CauseOfDeath { get; private set; } = "";

    public int ArrowsRemaining { get; set; } = 5;

    public Player(Location start) => Location = start;

    public void Kill(string cause)
    {
        IsAlive = false;
        CauseOfDeath = cause;
    }
}





public record Location(int X, int Y);
public class Room { public string RoomMessage { get; protected set; } public RoomType RoomT { get; protected set; } }
public class EntanceRoom : Room { public EntanceRoom() { RoomMessage = "You see a light coming from the cavern entrance"; RoomT = RoomType.Entrance; } }
public class PitRoom : Room { public PitRoom() { RoomMessage = "Oh dear you are dead by the pits!"; RoomT = RoomType.Pit; } }
class FountainRoom : Room
{
    public bool IsEnabled { get; private set; }
    public FountainRoom()
    {
        IsEnabled = false;
        RoomMessage = "You hear water dripping in this room The Fountain of Objects is here!";
        RoomT = RoomType.Fountain;
    }
    public void FountainToggle()
    {
        switch (IsEnabled)
        {
            case true:
                IsEnabled = false; RoomMessage = "You hear water dripping in this room The Fountain of Objects is here!"; break;
            case false:
                IsEnabled = true; RoomMessage = "You hear water rushing from the Fountain of Objects It has been Reactivated "; break;
        }
    }
}
public abstract class Monster
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; } = true;
    public Monster(Location start) => Location = start;
    public abstract void Effect();
}


public class Maelstrom : Monster
{
    public Maelstrom(Location start) : base(start) { }

    public override void Effect()
    {

    }

}
public interface ICommand
{
    void Execute(FountainOfObects game);
}

public class MoveDirection : ICommand
{
    public Direction Direction { get; }
    public MoveDirection(Direction direction)
    {
        Direction = direction;
    }
    public void Execute(FountainOfObects game)
    {
        Location playerLocation = game.Player.Location;
        Location newLocation = Direction switch
        {
            Direction.North => new Location(playerLocation.X - 1, playerLocation.Y),
            Direction.South => new Location(playerLocation.X + 1, playerLocation.Y),
            Direction.West => new Location(playerLocation.X, playerLocation.Y - 1),
            Direction.East => new Location(playerLocation.X, playerLocation.Y + 1),
        };
        if (game.CurrentBoard.IsLegalMove(newLocation))
            game.Player.Location = newLocation;
        else
            ConsoleHelper.WriteLine("There is a wall there.", ConsoleColor.Red);
    }
}

public class FountainCommands : ICommand
{
    public void Execute(FountainOfObects game)
    {
        Room currentRoom = game.CurrentBoard.GetRoom(game.Player.Location);
        if (currentRoom is FountainRoom)
        {
            FountainRoom fountainRoom = currentRoom as FountainRoom;
            fountainRoom.FountainToggle();
            game.CurrentBoard.UpdateRoomLocation(game.Player.Location, fountainRoom);
        }
    }
}


public interface Isense
{
    bool SenseNear(FountainOfObects game);
    void DisplaySenseMessage(FountainOfObects game);
}


public class PitSense : Isense
{
    public bool SenseNear(FountainOfObects game) => game.CurrentBoard.HasNeigbourNode(game.Player.Location, RoomType.Pit);

   

}

public static class ConsoleHelper
{
    // Changes to the specified color and then displays the text on its own line.
    public static void WriteLine(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
    }

    // Changes to the specified color and then displays the text without moving to the next line.
    public static void Write(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
    }
}



public enum Direction { North, South, East, West };
public enum RoomType { Entrance, Fountain, Pit, NullRoom };


