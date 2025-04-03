namespace Itmo.ObjectOrientedProgramming.Lab4.Printers;

public class ConsolePrinter : IPrinter
{
    public void Print(string value)
    {
        Console.WriteLine(value);
    }
}