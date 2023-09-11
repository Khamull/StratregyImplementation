using System;
using System.Collections.Generic;

public interface IMoveStrategy
{
    void ExecuteMove(ref int x, ref int y, ConsoleKeyInfo keyInfo);
}

public class MoveUp : IMoveStrategy
{
    public void ExecuteMove(ref int x, ref int y, ConsoleKeyInfo keyInfo)
    {
        y = Math.Max(y - 1, 0);
    }
}

public class MoveLeft : IMoveStrategy
{
    public void ExecuteMove(ref int x, ref int y, ConsoleKeyInfo keyInfo)
    {
        x = Math.Max(x - 1, 0);
    }
}

public class MoveDown : IMoveStrategy
{
    public void ExecuteMove(ref int x, ref int y, ConsoleKeyInfo keyInfo)
    {
        y = Math.Min(y + 1, Console.WindowHeight - 1);
    }
}

public class MoveRight : IMoveStrategy
{
    public void ExecuteMove(ref int x, ref int y, ConsoleKeyInfo keyInfo)
    {
        x = Math.Min(x + 1, Console.WindowWidth - 1);
    }
}

public interface IDrawStrategy
{
    void Draw(int x, int y);
}

public class StickFigureDrawStrategy : IDrawStrategy
{
    public void Draw(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(" O ");
        Console.SetCursorPosition(x, y + 1);
        Console.WriteLine("/|\\");
        Console.SetCursorPosition(x, y + 2);
        Console.WriteLine("/ \\");
    }
}

public class Character
{
    private IMoveStrategy moveStrategy;
    private IDrawStrategy drawStrategy;

    public Character(IMoveStrategy moveStrategy, IDrawStrategy drawStrategy)
    {
        this.moveStrategy = moveStrategy;
        this.drawStrategy = drawStrategy;
    }

    public void SetMoveStrategy(IMoveStrategy strategy)
    {
        this.moveStrategy = strategy;
    }

    public void SetDrawStrategy(IDrawStrategy strategy)
    {
        this.drawStrategy = strategy;
    }

    public void PerformMove(ref int x, ref int y, ConsoleKeyInfo keyInfo)
    {
        this.moveStrategy.ExecuteMove(ref x, ref y, keyInfo);
    }

    public void Draw(int x, int y)
    {
        this.drawStrategy.Draw(x, y);
    }
}

class Program
{
    static void Main()
    {
        int x = 0;
        int y = 0;

        Character fighter = new Character(new MoveUp(), new StickFigureDrawStrategy());

        Dictionary<ConsoleKey, IMoveStrategy> moveStrategies = new Dictionary<ConsoleKey, IMoveStrategy>
        {
            { ConsoleKey.W, new MoveUp() },
            { ConsoleKey.A, new MoveLeft() },
            { ConsoleKey.S, new MoveDown() },
            { ConsoleKey.D, new MoveRight() }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Press 'W' to move up, 'A' to move left, 'S' to move down," +
                          " 'D' to move right, 'Q' to Quit.");
            fighter.Draw(x, y+1);

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Q)
            {
                return;
            }

            if (moveStrategies.ContainsKey(keyInfo.Key))
            {
                moveStrategies[keyInfo.Key].ExecuteMove(ref x, ref y, keyInfo);
            }
        }
    }
}
