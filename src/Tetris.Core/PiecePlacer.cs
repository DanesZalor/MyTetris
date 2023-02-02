using System.Linq;
namespace Tetris.Core;

public class PiecePlacer
{
    private Board2D _board;
    private Piece? _currentPiece;

    public Piece? CurrentPiece
    {
        private get => _currentPiece;
        set{
            _currentPiece = _currentPiece ?? value;
        }
    }

    public PiecePlacer(Board2D board)
    {
        _board = board ?? throw new ArgumentNullException(nameof(board));
    }
    
    public void printBoard()
    {
        Console.WriteLine(" ┌" + new string('─', Board2D.MAX_COLUMNS*2) + "┐");

        for(int x = Board2D.MAX_ROWS-1; x >= 0; x--)
        {
            Console.Write(" │");
            for(int y = 0; y < Board2D.MAX_COLUMNS; y++)
            {
                Console.Write(
                    (CurrentPiece?.Any(block => block.X == x && block.Y == y) ?? false) ? 
                    "▓▓" : (_board[x,y] ? "██" : "  "));
            }
            Console.WriteLine("│ ");
        }

        Console.WriteLine(" └" + new string('─', Board2D.MAX_COLUMNS*2) + "┘");
    }
}
