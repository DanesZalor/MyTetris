namespace Tetris.Core.Pieces;

public class TPiece : Piece
{
    public TPiece() 
    : base(
        new Vector2D(0,0),
        new Vector2D(0,1),
        new Vector2D(0,2),
        new Vector2D(1,1)
    ) { }

    public override void RotateClockwise()
    {
        throw new NotImplementedException();
    }

    public override void RotateCounterClockwise()
    {
        throw new NotImplementedException();
    }
}
