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
        
        Console.Clear();
        pp.CurrentPiece = new TPiece0(new Vector2D(3,3)).MovedBy(new Vector2D(3,3));
        pp.printBoard();
        
        while(true){
            Console.Clear();
            pp.CurrentPiece = pp.CurrentPiece?.Rotated(clockwise:true);
            pp.printBoard();
            Console.WriteLine(pp.CurrentPiece?.GetType().Name);
            Console.ReadLine();
        }
    }
}