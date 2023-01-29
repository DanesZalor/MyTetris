using Tetris.Core;

public class Program
{
    public static void Main()
    {
        var b = new Board2D();

        for(int i = 0; i < 10; i++) b[1,i] = true;
        for(int i = 0; i < 10; i+=2) b[0,i] = true;
        for(int i = 1; i < 10; i+=2) b[2,i] = true;

        b.printBoard();

        b.cleanBoard();

        b.printBoard();
    }    
}