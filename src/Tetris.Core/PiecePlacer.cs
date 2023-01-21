namespace Tetris.Core;

public class PiecePlacer
{
    private Board2D _board;
    private Piece? currentPiece;

    public PiecePlacer(Board2D board)
    {
        _board = board ?? throw new ArgumentNullException(nameof(board));
    }
}
