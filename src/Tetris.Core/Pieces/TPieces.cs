namespace Tetris.Core.Pieces;

// ┻
public class TPiece0 : Piece
{
    public TPiece0(Vector2D origin) 
    : base(
        origin - new Vector2D(1,0),
        origin,
        origin + new Vector2D(1,0),
        origin + new Vector2D(0,1)
    ) { }

    public override Piece MovedBy(Vector2D v) => new TPiece0(Origin + v);
    public override Piece Rotated(bool clockwise) => 
        clockwise ? new TPiece1(Origin) : new TPiece3(Origin);
}


// ┣
public class TPiece1 : Piece
{
    public TPiece1(Vector2D origin) 
    : base(
        origin - new Vector2D(0,1),
        origin,
        origin + new Vector2D(0,1),
        origin + new Vector2D(1,0)
    ) { }

    public override Piece MovedBy(Vector2D v) => new TPiece1(Origin + v);
    
    public override Piece Rotated(bool clockwise) => 
        clockwise ? new TPiece2(Origin) : new TPiece0(Origin); 
}

// ┳
public class TPiece2 : Piece
{
    public TPiece2(Vector2D origin) 
    : base(
        origin - new Vector2D(1,0),
        origin,
        origin + new Vector2D(1,0),
        origin - new Vector2D(0,1)
    ) { }

    public override Piece MovedBy(Vector2D v) => new TPiece2(Origin + v);
    
    public override Piece Rotated(bool clockwise) => 
        clockwise ? new TPiece3(Origin) : new TPiece1(Origin); 
}

// ┫
public class TPiece3 : Piece
{
    public TPiece3(Vector2D origin) 
    : base(
        origin - new Vector2D(1,0),
        origin,
        origin + new Vector2D(0,1),
        origin - new Vector2D(0,1)
    ) { }

    public override Piece MovedBy(Vector2D v) => new TPiece3(Origin + v);
    
    public override Piece Rotated(bool clockwise) => 
        clockwise ? new TPiece0(Origin) : new TPiece2(Origin); 
}