namespace Tetris.Core.Pieces;

public abstract class Piece
{
    private Vector2D[] _blocks;
    protected Vector2D[] Blocks => _blocks;

    public Piece(Vector2D a, Vector2D b, Vector2D c, Vector2D d)
    {
        var coords = new Vector2D[]{ a, b, c, d };

        if(coords.Length != 4)
        {
            throw new ArgumentException("must be 4, retard");
        }

        _blocks = coords;
    }

    public void Move(Vector2D v)
    {
        for(int i = 0; i<4; i++)
        {
            Blocks[i] += v;
        }
    }

    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
}