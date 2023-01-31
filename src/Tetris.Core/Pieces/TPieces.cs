namespace Tetris.Core.Pieces;

public class TPiece0 : Piece
{
    public TPiece0(Vector2D origin) 
    : base(
        origin - new Vector2D(0,1),
        origin,
        origin + new Vector2D(0,1),
        origin + new Vector2D(1,0)
    ) { }

    public override Piece RotateClockwise()
    {
        throw new NotImplementedException();
    }

    public override Piece RotateCounterClockwise()
    {
        throw new NotImplementedException();
    }
}