
Coordinate[] coordinateArray = new Coordinate[4];

for (int i=0; i<4; i++)
{  
    coordinateArray[i] = new Coordinate(i+1,7);

}

Console.WriteLine(Coordinate.AdjectCoordinate(coordinateArray[1], coordinateArray[3]));

public struct Coordinate
{
    public readonly int Row { get; }
    public readonly int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static bool AdjectCoordinate(Coordinate p1, Coordinate p2)
    {

        int rowChange = p1.Row - p2.Row;
        int columnChange = p1.Column - p2.Column;

        if (Math.Abs(rowChange) <= 1 && columnChange == 0) return true;
        if (Math.Abs(columnChange) <= 1 && rowChange == 0) return true;

        return false;

    }

}