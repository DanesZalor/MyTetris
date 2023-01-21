using Tetris.Core;

public class Program
{
    public static void Main()
    {
        var board = new Board2D();
        
        board[0,0] = true;
        board[0,1] = true;
        board[0,2] = true;
        board[1,2] = true;

        board.printBoard();

        board[1,2] = false;
        board[0,1] = false;

        board.printBoard();
    }    
}