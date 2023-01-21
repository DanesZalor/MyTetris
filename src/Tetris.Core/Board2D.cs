namespace Tetris.Core;

public class Board2D
{
    private const byte MAX_HORIZONTAL = 10;
    private const byte MAX_VERTICAL = 24;
    private static void validateCoords(int vertical, int horizontal)
    {
        if(!(vertical >= 0 && vertical < MAX_VERTICAL))
        {
            throw new IndexOutOfRangeException("x is out of range");
        }

        if(!(horizontal >= 0 && horizontal < MAX_HORIZONTAL))
        {
            throw new IndexOutOfRangeException("y is out of range");
        }
    }    

    private int[] _boardFlags;

    public bool this[int vertical, int horizontal] 
    {
        get {
            validateCoords(vertical, horizontal);

            var xFlagCheck = 0b0000_0000_0000_0000_0000_0000_0000_0001 << vertical;
            return (_boardFlags[horizontal] & xFlagCheck) > 0;
        }
        set {
            validateCoords(vertical, horizontal);
            
            var xFlagCheck = 0b0000_0000_0000_0000_0000_0000_0000_0001 << vertical;
            
            if(value)
            {
                // A = A | B
                _boardFlags[horizontal] |= xFlagCheck;
            }
            else
            {
                // A = A & (~A | ~B)
                _boardFlags[horizontal] &= (~_boardFlags[horizontal] | ~xFlagCheck); 
            }
        }
    }

    public Board2D()
    {
        _boardFlags = new int[MAX_HORIZONTAL];
    }
    
    public void printBoard()
    {
        Console.WriteLine("  " + new string('=', MAX_HORIZONTAL*2));
        for(int x = MAX_VERTICAL-1; x >= 0; x--)
        {
            Console.Write("  ");
            for(int y = 0; y < MAX_HORIZONTAL; y++)
            {
                Console.Write(this[x,y] ? "██" : "░░");
            }
            Console.WriteLine("  ");
        }
    }
}
