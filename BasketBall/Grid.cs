namespace BasketBall;

internal class Grid
{
    public int BallsCount=0;
    protected int rows;
    protected int cols;
    protected char[,] cells;

    public Grid(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        cells = new char[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                cells[i,j] = ' ';
    }

    //public void Move(char c)
    //{
    //    switch (c)
    //    {
    //        case 'w':
    //            MoveUp();
    //            break;
    //        case 's':
    //            MoveDown();
    //            break;
    //        case 'a':
    //            MoveLeft();
    //            break;
    //        case 'd':
    //            MoveRight();
    //            break;
    //    }
    //}

    //add items to the grid
    public void AddBlock(int x, int y) => cells[x, y] = '■';
    public void AddBall(int x, int y)
    {
        cells[x, y] = 'O';
        BallsCount++;
    }
    public void AddBasket(int x, int y) => cells[x, y] = 'U';
    public void AddCoin(int x, int y) => cells[x, y] = '$';

    //check cell content methods
    protected bool isBlock(int x, int y) => cells[x, y] == '■';
    protected bool isBall(int x, int y) => cells[x, y] == 'O';
    protected bool isBasket(int x, int y) => cells[x, y] == 'U';
    protected bool isCoin(int x, int y) => cells[x, y] == '$';
    
    //override ToString() to print the grid
    public override bool Equals(object? obj)
    {
        var grid = obj as Grid;

        if (grid is null) return false;

        if (grid.rows != this.rows || grid.cols != this.cols) return false;

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                if (grid.cells[i, j] != this.cells[i, j])
                    return false;

        return true;
    }
    public override string ToString()
    {
        string output = "";
        for (int i = 0; i < rows; i++)
        {
            output += "| ";
            for (int j = 0; j < cols; j++)
            {
                output += cells[i, j] + " | ";
            }
            output += "\n";
        }
        output += "\n";

        return output;
    }
    public override int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hash = 17;
            // Incorporate the hash codes of all elements in the array
            foreach (var element in cells)
                hash = hash * 31 + (int)element;
            return hash;
        }
    }

}
