using System.Diagnostics;

namespace BasketBall;

internal class Grid
{
    public int BallsCount = 0;
    protected int rows;
    protected int cols;
    protected char[,]? cells;
    public Grid? Parent;

    public Grid() { }
    public Grid(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        cells = new char[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                cells[i,j] = ' ';
    }
    public Grid(Grid grid)
    {
        this.rows = grid.rows;
        this.cols = grid.cols;
        this.BallsCount = grid.BallsCount;
        this.cells = new char[rows, cols];

        for (int i = 0; i < rows; i++)
            for(int j = 0;j < cols; j++)
                this.cells[i,j] = grid.cells[i,j];
    }

    public void Control(char input)
    {
        switch (input)
        {
            case 'n':
                Stopwatch sw = Stopwatch.StartNew();
                sw.Start();

                DFS dfs = new(this);
                var path = dfs.Solve();
                for(int i=path.Count-2; i >= 0; i--)
                {
                    Console.WriteLine(path[i]);
                }
                this.BallsCount = 0;
                
                sw.Stop();
                Console.WriteLine($"Elapsed Time = {sw.Elapsed.TotalSeconds} seconds");
                
                break;
            
            case 'b':
                Stopwatch s = Stopwatch.StartNew();
                s.Start();

                BFS bfs = new(this);
                var sol = bfs.Solve();
                for (int i = sol.Count - 2; i >= 0; i--)
                {
                    Console.WriteLine(sol[i]);
                }
                this.BallsCount = 0;

                s.Stop();
                Console.WriteLine($"Elapsed Time = {s.Elapsed.TotalSeconds} seconds");
                break;
            
            case 'm':
                Stopwatch w = Stopwatch.StartNew();
                w.Start();

                UCS ucs = new(this);
                var res = ucs.Solve();
                for (int i = res.Count - 2; i >= 0; i--)
                {
                    Console.WriteLine(res[i]);
                }
                this.BallsCount = 0;

                w.Stop();
                Console.WriteLine($"Elapsed Time = {w.Elapsed.TotalSeconds} seconds");
                break;
            
            default:
                Move(input);
                break;
        }
    }
    public void Move(char c)
    {
        switch (c)
        {
            case 'w':
                MoveUp();
                break;
            case 's':
                MoveDown();
                break;
            case 'a':
                MoveLeft();
                break;
            case 'd':
                MoveRight();
                break;
            case 'p':
                GetPossibleMoves(true);
                break;
            default:
                Console.WriteLine("Invalid Input!...");
                break;
        }
    }

    //Grid Movements
    public List<Grid> GetPossibleMoves(bool print)
    {
        List<Grid> possileMoves = new();

        if (checkMoveDown() is not null) possileMoves.Add(checkMoveDown());
        if (checkMoveUp() is not null) possileMoves.Add(checkMoveUp());
        if (checkMoveRight() is not null) possileMoves.Add(checkMoveRight());
        if (checkMoveLeft() is not null) possileMoves.Add(checkMoveLeft());

        if (print)
        {
            Console.WriteLine("\nThe Possible Moves Are:\n");

            possileMoves.ForEach(grid =>
            {
                Console.WriteLine(grid);
            });
        }

        return possileMoves;
    }

    public void initializeGrid(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        cells = new char[rows, cols];
        for(int i = 0; i < rows; i++)
            for(int j = 0; j < cols; j++)
                cells[i,j] = ' ';
    }

    //This Grid Movements Functions
    private void MoveUp()
    {
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                moveCellUp(i, j);
    }
    private void MoveDown()
    {
        for (int i = rows - 1; i >= 0; i--)
            for (int j = 0; j < cols; j++)
                moveCellDown(i, j);
    }
    private void MoveLeft()
    {
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                moveCellLeft(i, j);
    }
    private void MoveRight()
    {
        for (int i = 0; i < rows; i++)
            for (int j = cols - 1; j >= 0; j--)
                moveCellRight(i, j);
    }

    //checking possible Movements
    public Grid? checkMoveUp()
    {
        Grid grid = new Grid(this);

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                grid.moveCellUp(i, j);
        grid.Parent = this;

        if (this.Equals(grid))
            return null;
        return grid;
    }
    public Grid? checkMoveDown()
    {
        Grid grid = new Grid(this);

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                grid.moveCellDown(i, j);
        grid.Parent = this;

        if (this.Equals(grid))
            return null;
        return grid;
    }
    public Grid? checkMoveRight()
    {
        Grid grid = new Grid(this);

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                grid.moveCellRight(i, j);
        grid.Parent = this;

        if (this.Equals(grid))
            return null;
        return grid;
    }
    public Grid? checkMoveLeft()
    {
        Grid grid = new Grid(this);

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                grid.moveCellLeft(i, j);
        grid.Parent = this;

        if (this.Equals(grid))
            return null;
        return grid;
    }

    //movement of individual cells
    protected void moveCellUp(int x, int y)
    {
        if (isBlock(x, y)) return;

        while (x > 0 && cells[x - 1, y]  == ' ')
        {
            cells[x - 1, y]  = cells[x, y] ;
            cells[x, y]  = ' ';
            x--;
        }

        if (x > 0 && isBall(x - 1, y) && isBasket(x, y))
        {
            BallsCount--;
            cells[x - 1, y]  = 'U';
            cells[x, y]  = ' ';
        }

        if (x > 0 && isCoin(x - 1, y) && isBasket(x, y))
        {
            cells[x - 1, y]  = 'U';
            cells[x, y]  = ' ';
        }

    }
    protected void moveCellDown(int x, int y)
    {
        if (isBlock(x, y)) return;

        while (x < rows - 1 && cells[x + 1, y]  == ' ')
        {
            cells[x + 1, y]  = cells[x, y] ;
            cells[x, y]  = ' ';
            x++;
        }

        if (x < rows - 1 && isBasket(x + 1, y) && isBall(x, y))
        {
            BallsCount--;
            cells[x + 1, y]  = 'U';
            cells[x, y]  = ' ';
        }

        if (x < rows - 1 && isBasket(x + 1, y) && isCoin(x, y))
        {
            cells[x + 1, y]  = 'U';
            cells[x, y]  = ' ';
        }
    }
    protected void moveCellLeft(int x, int y)
    {
        if (isBlock(x, y)) return;

        while (y > 0 && cells[x, y - 1]  == ' ')
        {
            cells[x, y - 1]  = cells[x, y] ;
            cells[x, y]  = ' ';
            y--;
        }
    }
    protected void moveCellRight(int x, int y)
    {
        if (isBlock(x, y)) return;

        while (y < cols - 1 && cells[x, y + 1] == ' ')
        {
            cells[x, y + 1] = cells[x, y];
            cells[x, y]  = ' ';
            y++;
        }
    }


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
