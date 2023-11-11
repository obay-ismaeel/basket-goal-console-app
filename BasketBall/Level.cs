namespace BasketBall;

internal class Level : Grid
{
    public Level(int level)
    {
        switch (level)
        {
            case 1:
                one();
                break;
            case 2:
                two();
                break;
            case 3:
                three();
                break;
            case 4:
                four();
                break;
            case 5:
                five();
                break;
            case 6:
                six();
                break;
            case 7:
                seven();
                break;
            case 8:
                eight();
                break;
            case 9:
                nine();
                break;
            case 10:
                ten();
                break;
        }
    }

    private void one()
    {
        initializeGrid(3, 3);

        AddBall(0, 1);
        AddBasket(2, 1);
    }
    private void two()
    {
        initializeGrid(3, 3);

        AddBall(1, 0);
        AddBasket(1, 2);
        AddBlock(0, 2);
        AddBlock(2, 0);
    }
    private void three()
    {
        initializeGrid(3, 3);

        AddBall(2, 1);
        AddBasket(0, 1);
        AddBlock(0, 0);
        AddBlock(1, 2);
        AddBlock(2, 0);
    }
    private void four()
    {
        initializeGrid(4, 3);

        AddBall(2, 0);
        AddBasket(2, 2);
        AddBlock(0, 0);
        AddBlock(2, 1);
    }
    private void five()
    {
        initializeGrid(4, 3);

        AddBall(3, 2);
        AddBasket(1, 2);
        AddCoin(1, 0);
        AddBlock(3, 0);
        AddBlock(2, 2);
        AddBlock(1, 1);
    }
    private void six()
    {
        initializeGrid(4, 3);

        AddBall(2, 1);
        AddBasket(1, 0);
        AddBlock(0, 1);
        AddBlock(2, 0);
        AddBlock(2, 2);
    }
    private void seven()
    {
        initializeGrid(4, 3);

        AddBall(3, 1);
        AddBasket(2, 2);
        AddBlock(0, 0);
        AddBlock(1, 2);
        AddBlock(3, 2);
    }
    private void eight()
    {
        initializeGrid(4, 3);

        AddBall(1, 1);
        AddBall(3, 1);
        AddBasket(0, 2);
        AddBlock(0, 1);
        AddBlock(2, 1);
    }
    private void nine()
    {
        initializeGrid(4, 3);

        AddBall(1, 0);
        AddBall(1, 1);
        AddBall(1, 2);
        AddBasket(0, 0);
        AddBlock(0, 1);
        AddBlock(2, 0);
        AddBlock(3, 0);
        AddBlock(3, 2);
    }
    private void ten()
    {
        initializeGrid(4, 3);

        AddBall(2, 0);
        AddBasket(1, 2);
        AddBlock(0, 2);
        AddBlock(1, 0);
        AddBlock(2, 2);
        AddBlock(3, 0);
    }


}
