using Tetris.Core;
using Tetris.Core.Pieces;

public class Program
{
    public static void Main()
    {
        var b = new Board2D();

        for(int i = 0; i < 10; i++) b[1,i] = true;
        for(int i = 0; i < 10; i+=2) b[0,i] = true;
        for(int i = 1; i < 10; i+=2) b[2,i] = true;

        b.cleanBoard();

        var pp = new PiecePlacer(b);

        var piece = new TPiece0(new Vector2D(0,1));
        foreach(var _b in piece) Console.Write($"{_b} ");
        Console.Write($"ORIGIN={piece.Origin}");

        //pp.CurrentPiece = piece;

        //pp.printBoard();
    }
}