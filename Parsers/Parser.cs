using FluentChaining;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.ParserLinks;
using Chain = FluentChaining.FluentChaining;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class Parser : IParser
{
    private readonly IChain<string[], ICommand?> _chain;

    public Parser()
    {
        _chain = Chain.CreateChain<string[], ICommand?>(
            builder => builder
                .Then<ConnectCommandParserLink>()
                .Then<FileCommandParserLink>()
                .Then<TreeCommandParserLink>()
                .FinishWith(() => null));
    }

    public ICommand? Parse(string input)
    {
        string[] tokens = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
        return _chain.Process(tokens);
    }
}