using BasketBall;

Console.Write("Choose a level from 1 to 10 and press enter: ");
Int32.TryParse(Console.ReadLine(), out int number);

Grid one = new Grid(3,3);
one.AddBlock(1, 1);
one.AddBall(2, 1);
one.AddBasket(0, 0);

Grid two = new Grid(3, 3);
two.AddBlock(1, 1);
two.AddBall(2, 1);
two.AddBasket(0, 0);

Grid three = new Grid(3, 3);
three.AddBlock(0, 0);
three.AddBall(1, 1);
three.AddBasket(2, 1);  

Console.WriteLine("one: " + one.GetHashCode());
Console.WriteLine("two: " + two.GetHashCode());
Console.WriteLine("three: " + three.GetHashCode());