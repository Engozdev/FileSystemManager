using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Main
{
    public static void main()
    {
        var parser = new Parser();
        var context = new Context(string.Empty);
        while (true)
        {
            Console.Write(context.CurrentPath + "> ");
            string? input = Console.ReadLine();
            if (input is null) continue;

            if (input == "exit")
                break;

            ICommand? command;
            try
            {
                command = parser.Parse(input);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("invalid input");
                continue;
            }

            if (command is null)
            {
                Console.WriteLine("Unknown command");
                continue;
            }

            try
            {
                command.Execute(context);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("error: access denied");
            }
            catch
            {
                Console.WriteLine("something went wrong");
            }
        }
    }
}