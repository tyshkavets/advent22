using System.Collections.Immutable;
using Pidgin;
using static Pidgin.Parser;

namespace Day13;

public static class InputParser
{
    private static readonly Parser<char, char> LeftBracket = Char('[');
    private static readonly Parser<char, char> RightBracket = Char(']');
    
    private static Parser<char, T> Tok<T>(Parser<char, T> token)
        => Try(token).Before(SkipWhitespaces);

    private static readonly Parser<char, char> Comma = Char(',');

    private static readonly Parser<char, Input> Literal
        = Tok(Num)
            .Select<Input>(value => new InputInteger(value))
            .Labelled("integer literal");

    private static readonly Parser<char, Input> GeneralParser =
        Literal.Or(Rec(() => ArrayParser!));

    private static readonly Parser<char, Input> ArrayParser =
        GeneralParser.Between(SkipWhitespaces)
            .Separated(Comma)
            .Between(LeftBracket, RightBracket)
            .Select<Input>(els => new InputArray(els.ToImmutableArray()));

    public static Result<char, Input> Parse(string input) => GeneralParser.Parse(input);
}