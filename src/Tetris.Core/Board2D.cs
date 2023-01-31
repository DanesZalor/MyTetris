namespace Tetris.Core;

public class Board2D
{
    public const byte MAX_HORIZONTAL = 10;
    public const byte MAX_VERTICAL = 24;
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
    
    public bool isRowFull(int row)
    {
        for(int i = 0; i < MAX_HORIZONTAL; i++)
        {
            if(!this[row, i])
            { 
                return false;
            }
        }
        return true;
    }

    public void cleanRow(int row)
    {
        for(int i = 0; i < MAX_HORIZONTAL; i++)
        {
            if(!this[row, i]) return;
        }
        
        var index = 0b0000_0000_0000_0000_0000_0000_0000_0001 << row;

        var postIndex = (index-1) | index;
        
        for(int i = 0; i < MAX_HORIZONTAL; i++)
        {
            var A_NOT_index = _boardFlags[i] & ~index;
            
            _boardFlags[i] =
                (
                    (A_NOT_index & postIndex) |
                    ((A_NOT_index & ~postIndex) >> 1)
                );
        }
    }

    public void cleanBoard()
    {
        for(int i = 0; i < MAX_VERTICAL; i++) cleanRow(i);
    }
}
