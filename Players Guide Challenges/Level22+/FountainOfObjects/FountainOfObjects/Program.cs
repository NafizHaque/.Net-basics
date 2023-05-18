using System.ComponentModel;
using System.Xml.Serialization;
using FountainGame;
FountainOfIbjects game = new FountainOfIbjects();
game.Run();


class BoardCreate
{
    public Room[,] Matrix { get; set; }


    public int BoardSizeLimit { get; set; }
    public BoardCreate(int size)
    {
        BoardSizeLimit = size;
        Matrix = new Room[size, size];
        Matrix[1, 3] = new FountainRoom();
        Matrix[0, 0] = new EntanceRoom();

        if (size > 3) { Matrix[0, 2] = new PitRoom(); }
        if (size > 5) 
        { 
            Matrix[1, 4] = new PitRoom(); 
            Matrix[1, 5] = new MaelstromRoom(new Monster(1,5)); 
        }
        if (size > 7) 
        { 
            Matrix[2, 6] = new PitRoom(); 
            Matrix[3, 4] = new PitRoom(); 
            Matrix[3, 6] = new MaelstromRoom(new Monster(3, 6)); 
            Matrix[4, 4] = new MaelstromRoom(new Monster(4, 4)); 
        }
    }
}


class Player
{

    public (int currentRow, int currentColumn) position { get; set; }
    public Direction playerMove { get; set; }
    public Player() => position = (0, 0);

    public string CurentRoom()
    {
        string positionMessage = $"You are in a Room at Row: {position.currentRow} Column: {position.currentColumn}";
        return positionMessage;

    }

}


class Board
{
    public BoardCreate? CurrentBoard { get; }
    public Player CurrentPlayer { get; }



    public Board(BoardCreate newBoard, Player currentPlayer)
    {
        CurrentPlayer = currentPlayer;
        CurrentBoard = newBoard;
    }


    public string PlayerMovement(Direction direction)
    {
        int x = CurrentPlayer.position.currentRow;
        int y = CurrentPlayer.position.currentColumn;
        if (direction == Direction.North && x > 0)
        {
            x -= 1;
            CurrentPlayer.position = (x, y);
            return "Moved North!";
        }
        if (direction == Direction.East && y > 0)
        {
            y -= 1;
            CurrentPlayer.position = (x, y);
            return "Moved East!";
        }
        if (direction == Direction.West && y < CurrentBoard.BoardSizeLimit)
        {
            y += 1;
            CurrentPlayer.position = (x, y);
            return "Moved West!";

        }
        if (direction == Direction.South && x < CurrentBoard.BoardSizeLimit)
        {
            x += 1;
            CurrentPlayer.position = (x, y);
            return "Moved South!";
        }

        return "invalid move";

    }

    public void FountainAction()
    {
        int x = CurrentPlayer.position.currentRow;
        int y = CurrentPlayer.position.currentColumn;

        if (x == 0 && y == 2)
        {
            FountainRoom fountain = CurrentBoard.Matrix[0, 2] as FountainRoom;
            fountain.FountainToggle();
            CurrentBoard.Matrix[0, 2] = fountain;
        }

    }
    public bool WinCondition()
    {
        int x = CurrentPlayer.position.currentRow;
        int y = CurrentPlayer.position.currentColumn;
        FountainRoom fountain = CurrentBoard.Matrix[0, 2] as FountainRoom;
        if (x == 0 && y == 0 && fountain.IsEnabled)
        {
            return true;
        }
        else { return false; }

    }
    public string PitCheck()
    {
        int x = CurrentPlayer.position.currentRow;
        int y = CurrentPlayer.position.currentColumn;

        if (x > 0)
        {
            if (CurrentBoard.Matrix[x - 1, y] is PitRoom)
            {
                return "You feel a draft. There is a pit in a nearby Room";

            }
        }
        if (x < CurrentBoard.BoardSizeLimit)
        {
            if (CurrentBoard.Matrix[x + 1, y] is PitRoom)
            {
                return "You feel a draft. There is a pit in a nearby Room";

            }
        }
        if (y < CurrentBoard.BoardSizeLimit)
        {
            if (CurrentBoard.Matrix[x, y + 1] is PitRoom)
            {
                return "You feel a draft. There is a pit in a nearby Room";

            }
        }
        if (y > 0)
        {
            if (CurrentBoard.Matrix[x, y - 1] is PitRoom)
            {
                return "You feel a draft. There is a pit in a nearby Room";

            }
        }
        return null;
    }

    public void IfMonster()
    {
        int x = CurrentPlayer.position.currentRow;
        int y = CurrentPlayer.position.currentColumn;


        if (CurrentBoard.Matrix[x, y] is MaelstromRoom)
        {


            CurrentPlayer.position = (x+2,y+1);
            CurrentBoard.Matrix[x - 2, y - 1] = new MaelstromRoom(new Monster(x - 2, y - 1)) ;
            CurrentBoard.Matrix[x, y] = null;

        }
    }

    public string CurrentRoomMessage()
    {
        int x = CurrentPlayer.position.currentRow;
        int y = CurrentPlayer.position.currentColumn;

        if (CurrentBoard.Matrix[x, y] is Room)
        {
            Room room = CurrentBoard.Matrix[x, y];
            return room.RoomMessage;
        }
        else return null;
    }


}


class Room
{
    public string RoomMessage { get; set; }
    public Room()
    {
    }
}


class FountainRoom : Room
{
    public bool IsEnabled { get; set; }
    public FountainRoom()
    {
        IsEnabled = false;
        RoomMessage = "You hear water dripping in this room The Fountain of Objects is here!";
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

class Monster
{
    public (int currentRow, int currentColumn) position { get; set; }

    public Monster(int row, int column)
    {
        position = (row,  column);


    }

}


class EntanceRoom : Room
{
    public EntanceRoom()
    {
        RoomMessage = "You see a light coming from the cavern entrance";
    }
}


class PitRoom : Room
{
    public PitRoom()
    {
        RoomMessage = "Oh dear you are dead by the pits!";
    }
}


class MaelstromRoom : Room
{
    public Monster Maelstrom { get; set; }
    public MaelstromRoom(Monster maelstrom)
    {
        Maelstrom = maelstrom;
        RoomMessage = "You've Encountered a Maelstrom! He Sends you away to a random room!";
    }
}

public interface IRobotCommand
{
    void Execute(time board);
}



public record time(int x , int y);
enum Direction { North, South, East, West };


