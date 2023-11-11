namespace BasketBall;

internal class BFS
{
    private HashSet<Grid> _visitedStates;
    private Queue<Grid> _queue;
    private Grid _startState;
    public BFS(Grid startState)
    {
        _visitedStates = new();
        _queue = new();
        _startState = startState;
    }

    public List<Grid>? Solve()
    { 
        return Solve(_startState);
    }

    private List<Grid>? Solve(Grid grid)
    {

        _queue.Enqueue(grid);
        Grid sol = null;
        do
        {
            var item = _queue.Dequeue();
            _visitedStates.Add(item);

            //add children to the queue
            foreach (Grid child in item.GetPossibleMoves(false))
            {
                if (_visitedStates.Contains(child)) continue;
                _queue.Enqueue(child);
                if (child.BallsCount == 0)
                {
                    sol = child;
                    break;
                }
            }

            if (sol is not null) break;
        } while (_queue.Any());

        var finalState = sol;
        List<Grid> result = new();
        while (finalState != null)
        {
            result.Add(finalState);
            finalState = finalState.Parent;
        }
        return result;
    }
}
