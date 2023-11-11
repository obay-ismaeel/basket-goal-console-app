namespace BasketBall;

internal class DFS
{
    private HashSet<Grid> _visitedStates;
    private Stack<Grid> _stack;
    private Grid _startState;
    public DFS (Grid startState)
    {
        _visitedStates = new();
        _stack = new();
        _startState = startState;
    }
    
    public List<Grid>? Solve()
    {
        return Solve(_startState);
    }

    private List<Grid>? Solve(Grid grid)
    {
        
        _stack.Push(grid);

        do
        {
            var item = _stack.Pop();
            _visitedStates.Add(item);

            //add children to the stack
            foreach(Grid child in item.GetPossibleMoves(false))
            {
                if( _visitedStates.Contains(child) ) continue;
                _stack.Push(child);
                if (child.BallsCount == 0) break;
            }

            if(_stack.Peek().BallsCount == 0) break;
            
        } while (_stack.Any());

        var finalState = _stack.Pop();
        List<Grid> result = new();
        while( finalState != null ) 
        {
            result.Add(finalState);
            finalState = finalState.Parent;
        }
        return result;
    }

}
