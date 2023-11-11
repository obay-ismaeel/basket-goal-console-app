using BasketBall;

play:
Console.Write("Choose a level from 1 to 10 and press enter: ");
Int32.TryParse(Console.ReadLine(), out int number);
Level level = new Level(number);

Console.WriteLine(
    $"\nUse the keyboard [W,A,S,D] to move..." +
    $"\nPress [P] to show possible moves" +
    $"\nPress [N] to solve using DFS algorithm" +
    $"\nPress [B] to solve using BFS algorithm" +
    $"\nPress [M] to solve using UCS algorithm" +
    $"\n{level}"
);

while (level.BallsCount > 0)
{
    var input = char.ToLower(Console.ReadKey(true).KeyChar);
    level.Control(input);
    Console.WriteLine("\n");
    if (input != 'b' && input != 'n' && input != 'm')
        Console.WriteLine(level);
}

Console.WriteLine("=====================================================");
Console.WriteLine("\t\tCongrats You WON!");
Console.WriteLine("=====================================================\n");

Console.Write("Press any key to replay: ");

Console.ReadKey();
Console.WriteLine("\n");

goto play;