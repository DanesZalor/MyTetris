using System.Collections;

namespace Tetris.Core.Pieces;

public abstract class Piece : IEnumerable<Vector2D>
{
    private Vector2D[] _blocks;
    public Vector2D Origin {
        get 
        {
            (decimal X, decimal Y) = (0,0);

            foreach(var _b in _blocks)
            {
                X += _b.X;
                Y += _b.Y;
            }

            X /= _blocks.Length;
            Y /= _blocks.Length;

            if(X - (int)X > 0.5m) X = (int)X + 1m;
            if(Y - (int)Y > 0.5m) Y = (int)Y + 1m;

            return new Vector2D((byte)X,(byte)Y);
        }
    }

    public Piece(Vector2D a, Vector2D b, Vector2D c, Vector2D d)
    {
        var coords = new Vector2D[]{ a, b, c, d };

        if(coords.Length != 4)
        {
            throw new ArgumentException("must be 4, retard");
        }

        _blocks = coords;
    }

    public Piece Move(Vector2D v)
    { 
        for(int i = 0; i<4; i++) _blocks[i] += v; 
        return this;
    }

    public abstract Piece RotateClockwise();
    public abstract Piece RotateCounterClockwise();

#region Enumerarable overrides
    public IEnumerator<Vector2D> GetEnumerator() 
        => ((IEnumerable<Vector2D>)_blocks).GetEnumerator();
    

    IEnumerator IEnumerable.GetEnumerator() 
        => _blocks.GetEnumerator();
#endregion

}
