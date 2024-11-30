using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser;
{
    public class FieldsParserTask
{
    private static readonly char[] StopChars = { ' ', '\"', '\'' };

    public static List<string> ParseLine(string line)
    {
        var tokenizedString = new List<string>();

        for (var startIndex = 0; startIndex < line.Length;)
        {
            var nextToken = ReadField(line, startIndex);

            if (nextToken.Value != " " || (nextToken.Value == " " && nextToken.Length > 1))
                tokenizedString.Add(nextToken.Value);

            startIndex += nextToken.Length;
        }

        return tokenizedString;
    }

    private static Token ReadField(string line, int startIndex)
    {
        switch (line[startIndex])
        {
            case ' ':
                return new Token(" ", startIndex, 1);
            case '"':
                return ParseQuotedField(line, startIndex, "\"");
            case '\'':
                return ParseQuotedField(line, startIndex, "'");
            default:
                return ParseFieldWithoutQuotes(line, startIndex);
        }
    }

    private static Token ParseQuotedField(string line, int startIndex, string quote)
    {
        return ParseField(line, startIndex + 1, quote.ToCharArray(), 2);
    }

    private static Token ParseFieldWithoutQuotes(string line, int startIndex)
    {
        return ParseField(line, startIndex, StopChars, 0);
    }

    private static Token ParseField(string line, int startIndex, char[] stopChars, int quotesNumber)
    {
        var tokenValue = new StringBuilder();
        var slashesCounter = 0;

        for (var i = startIndex; i < line.Length && !stopChars.Contains(line[i]); i++)
        {
            if (line[i] == '\\')
            {
                slashesCounter++;
                i++;
            }

            tokenValue.Append(line[i]);
        }

        return new Token(tokenValue.ToString(), startIndex,
            tokenValue.Length + quotesNumber + slashesCounter);
    }
}
}
