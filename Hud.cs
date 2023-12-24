using System;
using System.Threading;

public class RandomTimerClass
{
    private Timer mainLoopTimer;
    private Timer proceedTimer;
    private Random random;

    public RandomTimerClass()
    {
        random = new Random();
        mainLoopTimer = new Timer(MainLoop, random, 0, 1); // Change 1 to your desired interval
        proceedTimer = new Timer(ProceedAfterDelay, null, Timeout.Infinite, Timeout.Infinite);
    }

    public void Start()
    {
        Console.ReadKey();
    }

    private void MainLoop(object state)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Random random = (Random)state;
        Console.Write(random.Next() + " Error System Not Found");
        Console.ResetColor();
    }

    private void ProceedAfterDelay(object state)
    {
        Console.WriteLine("\nBack to normal after 5 seconds.");

        mainLoopTimer.Change(0, 100); 
        // Disable the proceed timer
        proceedTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }
}
