using Tetris.Core;
using Tetris.Core.Pieces;

public class Program
{
    public static void Main()
    {
        var b = new Board2D();

        for(int i = 0; i < 10; i++) b[i,1] = true;
        for(int i = 0; i < 10; i+=2) b[i,0] = true;
        for(int i = 1; i < 10; i+=2) b[i,2] = true;

        b.cleanBoard();

        var pp = new PiecePlacer(b);

        var piece = new TPiece0(new Vector2D(3,3));
        foreach(var _b in piece) Console.Write($"{_b} ");
        Console.WriteLine($"ORIGIN={piece.Origin}");

        pp.CurrentPiece = piece;

        pp.printBoard();
    }
}