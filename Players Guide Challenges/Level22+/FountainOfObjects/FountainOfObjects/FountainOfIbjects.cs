namespace FountainGame
{
    class FountainOfIbjects
    {

        public void Run()
        {
            string choice;
            Player player = new Player();
            choice = Console.ReadLine();

            Board board;
            board = choice switch
            {
                "small" => new Board(new BoardCreate(4), player),
                "medium" => new Board(new BoardCreate(6), player),
                "large" => new Board(new BoardCreate(8), player),
            };
            bool gameComplete = false;
            while (!gameComplete)
            {

                Console.WriteLine(player.CurentRoom());
                if (board.CurrentRoomMessage() != null) { Console.WriteLine(board.CurrentRoomMessage()); }
                if (board.PitCheck() != null) { Console.WriteLine(board.PitCheck()); }
                Console.Write("What is your action?: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "move north":
                        Console.WriteLine(board.PlayerMovement(Direction.North)); break;
                    case "move east":
                        Console.WriteLine(board.PlayerMovement(Direction.East)); break;
                    case "move west":
                        Console.WriteLine(board.PlayerMovement(Direction.West)); break;
                    case "move south":
                        Console.WriteLine(board.PlayerMovement(Direction.South)); break;
                    case "enable fountain":
                        board.FountainAction(); break;
                    case "disable fountain":
                        board.FountainAction(); break;
                    default:
                        Console.WriteLine("error"); break;
                }
                if (board.WinCondition()) { gameComplete = true; }
            }
            Console.Write("you won");


        }


    }
}


