namespace Tetris.Core;

public class Board2D
{
    public const byte MAX_COLUMNS = 10;
    public const byte MAX_ROWS = 24;
    private static void validateCoords(int column, int row)
    {
        if(!(row >= 0 && row < MAX_ROWS))
        {
            throw new IndexOutOfRangeException("row(y) is out of range");
        }

        if(!(column >= 0 && column < MAX_COLUMNS))
        {
            throw new IndexOutOfRangeException("column(x) is out of range");
        }
    }    

    private int[] _boardFlags;

    public bool this[int column, int row] 
    {
        get {
            validateCoords(column, row);

            var xFlagCheck = 0b0000_0000_0000_0000_0000_0000_0000_0001 << row;
            return (_boardFlags[column] & xFlagCheck) > 0;
        }
        set {
            validateCoords(column, row);
            
            var xFlagCheck = 0b0000_0000_0000_0000_0000_0000_0000_0001 << row;
            
            if(value)
            {
                // A = A | B
                _boardFlags[column] |= xFlagCheck;
            }
            else
            {
                // A = A & (~A | ~B)
                _boardFlags[column] &= (~_boardFlags[column] | ~xFlagCheck); 
            }
        }
    }

    public Board2D()
    {
        _boardFlags = new int[MAX_COLUMNS];
    }
    
    public bool isRowFull(int row)
    {
        for(int i = 0; i < MAX_COLUMNS; i++)
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
        for(int column = 0; column < MAX_COLUMNS; column++)
        {
            if(!this[column, row]) return;
        }
        
        var index = 0b0000_0000_0000_0000_0000_0000_0000_0001 << row;

        var postIndex = (index-1) | index;
        
        for(int column = 0; column < MAX_COLUMNS; column++)
        {
            var A_NOT_index = _boardFlags[column] & ~index;
            
            _boardFlags[column] =
                (
                    (A_NOT_index & postIndex) |
                    ((A_NOT_index & ~postIndex) >> 1)
                );
        }
    }

    public void cleanBoard()
    {
        for(int i = 0; i < MAX_ROWS; i++) cleanRow(i);
    }
}
