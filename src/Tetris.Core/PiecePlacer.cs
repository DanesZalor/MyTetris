using System.Linq;
namespace Tetris.Core;

public class PiecePlacer
{
    private Board2D _board;
    private Piece? _currentPiece;

    public Piece? CurrentPiece
    {
        get => _currentPiece;
        set{
            _currentPiece = value ?? throw new ArgumentNullException();
        }
    }

    public PiecePlacer(Board2D board)
    {
        _board = board ?? throw new ArgumentNullException(nameof(board));
    }
    
    public void printBoard()
    {
        Console.WriteLine(" ┌" + new string('─', Board2D.MAX_COLUMNS*2) + "┐");

        for(int row = Board2D.MAX_ROWS-1; row >= 0; row--)
        {
            Console.Write(" │");
            for(int column = 0; column < Board2D.MAX_COLUMNS; column++)
            {
                Console.Write(
                    (CurrentPiece?.Any(block => block.X == column && block.Y == row) ?? false) ? 
                    "▓▓" : (_board[column, row] ? "██" : "  "));
            }
            Console.WriteLine("│ ");
        }

        Console.WriteLine(" └" + new string('─', Board2D.MAX_COLUMNS*2) + "┘");
    }
}
