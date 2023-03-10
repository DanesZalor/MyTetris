namespace Tetris.Core;

public struct Vector2D
{
    public byte X {get; init;}
    public byte Y {get; init;}
    
    public Vector2D(byte x, byte y)
    {
        X = x;
        Y = y;
    }

    public static Vector2D operator +(Vector2D a, Vector2D b)
        => new Vector2D(){
            X = (byte)(a.X + b.X), 
            Y = (byte)(a.Y + b.Y)
        };
    
    public static Vector2D operator -(Vector2D a, Vector2D b)
        => new Vector2D(){
            X = (byte)(a.X - b.X), 
            Y = (byte)(a.Y - b.Y) 
        };

    public static Vector2D operator /(Vector2D a, float b)
    {
        (float X, float Y) = (a.X / b, a.Y / b);
        
        if(X - (int)X > 0.5f) X = (int)X + 1f;
        if(Y - (int)Y > 0.5f) Y = (int)Y + 1f;
        
        return new Vector2D((byte)X, (byte)Y);
    }

    public static bool operator ==(Vector2D a, Vector2D b)
        => (a.X == b.X) && (a.Y == b.Y);

    public static bool operator !=(Vector2D a, Vector2D b)
        => (a.X != b.X) || (a.Y != b.Y);

    public override bool Equals(object? obj)
        => obj != null && obj is Vector2D && 
            this == (Vector2D)obj; 

    public override int GetHashCode()
        => this.GetHashCode();

    public override string ToString() => $"({X},{Y})";
}
