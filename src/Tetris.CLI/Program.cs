using Tetris.Core;

public class Program
{
    public static void Main()
    {
        var v1 = new Vector2D(1,1);
        var v2 = new Vector2D(1,2);

        Console.WriteLine(v1 == v2);
    }    
}