using System.Collections;

namespace Tetris.Core.Pieces;

// Ideally Immutable 
public abstract class Piece : IEnumerable<Vector2D>
{
    private Vector2D[] _blocks;
    public Vector2D Origin {
        get 
        {
            var vec = new Vector2D(0,0);
            foreach(var _b in _blocks) vec += _b;

            return vec/_blocks.Length;
        }
    }

    public Piece(Vector2D a, Vector2D b, Vector2D c, Vector2D d)
    {
        _blocks =  new Vector2D[]{ a, b, c, d };
    }

    public abstract Piece MovedBy(Vector2D v);
    public abstract Piece Rotated(bool clockwise);
    

#region Enumerarable overrides
    public IEnumerator<Vector2D> GetEnumerator() 
        => ((IEnumerable<Vector2D>)_blocks).GetEnumerator();
    

    IEnumerator IEnumerable.GetEnumerator() 
        => _blocks.GetEnumerator();
#endregion

}
