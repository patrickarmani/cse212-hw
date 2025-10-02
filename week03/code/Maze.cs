/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    private void MoveCore(int dirIndex, int dx, int dy)
    {
        if (!_mazeMap.TryGetValue((_currX, _currY), out var moves) ||
            moves is null || moves.Length < 4 || !moves[dirIndex])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX += dx;
        _currY += dy;
    }
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>

    // public void MoveLeft()

    //new comment
    /// Move left if allowed; otherwise throw.
    /// Directions order: [left, right, up, down] -> left = index 0
    //new comment
    public void MoveLeft() => MoveCore(dirIndex: 0, dx: -1, dy: 0);

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    // public void MoveRight()

    //new comment
    /// Move right if allowed; otherwise throw. right = index 1
    //new comment
    public void MoveRight() => MoveCore(dirIndex: 1, dx: +1, dy: 0);

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    // public void MoveUp()

    //new comment
    /// Move up if allowed; otherwise throw. up = index 2
    /// Here I consider up as y - 1
    //new comment
    public void MoveUp() => MoveCore(dirIndex: 2, dx: 0, dy: -1);

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    // public void MoveDown()

    //new comment
    /// Move down if allowed; otherwise throw. down = index 3
    /// Here I consider down as y + 1
    //new comment
    public void MoveDown() => MoveCore(dirIndex: 3, dx: 0, dy: +1);



    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}