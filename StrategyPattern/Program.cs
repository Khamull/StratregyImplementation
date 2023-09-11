using System;
#region Interface
// Define an interface for the scheduling strategy
public interface ISchedulingStrategy
{
    void Execute();
}
#endregion
#region Scheduling Logics
// Implement concrete scheduling strategies
public class FCFS : ISchedulingStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing First-Come-First-Served scheduling strategy.");
        // Implement FCFS logic here
    }
}

public class SJN : ISchedulingStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Shortest-Job-Next scheduling strategy.");
        // Implement SJN logic here
    }
}

public class PriorityScheduling : ISchedulingStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Priority Scheduling strategy.");
        // Implement Priority Scheduling logic here
    }
}

public class RoundRobin : ISchedulingStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Round-Robin scheduling strategy.");
        // Implement Round-Robin logic here
    }
}

public class SRTN : ISchedulingStrategy
{
    public void Execute()
    {
        Console.WriteLine("Executing Shortest Remaining Time Next (SRTN) scheduling strategy.");
        // Implement SRTN logic here
    }
}
#endregion
#region Strategy Class
// Context class that uses the strategy
public class Scheduler
{
    private ISchedulingStrategy? _strategy;

    public void SetStrategy(ISchedulingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}
#endregion
class Program
{
    static void Main()
    {
        Scheduler scheduler = new Scheduler();

        while (true)
        {
            Console.WriteLine("Choose a scheduling strategy:");
            Console.WriteLine("1. First-Come-First-Served");
            Console.WriteLine("2. Shortest-Job-Next");
            Console.WriteLine("3. Priority Scheduling");
            Console.WriteLine("4. Round-Robin");
            Console.WriteLine("5. Shortest Remaining Time Next (SRTN)");
            Console.WriteLine("6. Exit");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 6)
            {
                break; // Exit the loop and terminate the program
            }

            ISchedulingStrategy selectedStrategy = null;

            switch (choice)
            {
                case 1:
                    selectedStrategy = new FCFS();
                    break;
                case 2:
                    selectedStrategy = new SJN();
                    break;
                case 3:
                    selectedStrategy = new PriorityScheduling();
                    break;
                case 4:
                    selectedStrategy = new RoundRobin();
                    break;
                case 5:
                    selectedStrategy = new SRTN();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Using First-Come-First-Served by default.");
                    selectedStrategy = new FCFS();
                    break;
            }

            scheduler.SetStrategy(selectedStrategy);
            Console.Clear(); // Clear console before execution
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Executing the selected strategy...");
            Console.ResetColor();

            // Simulate some time-consuming task
            System.Threading.Thread.Sleep(2000); // Sleep for 2 seconds

            scheduler.ExecuteStrategy();

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            Console.Clear(); // Clear console for the next iteration
        }
    }
}