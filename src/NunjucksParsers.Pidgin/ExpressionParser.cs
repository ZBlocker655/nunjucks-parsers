using Pidgin;
using static Pidgin.Parser;

namespace NunjucksParsers.Pidgin;

public static class ExpressionParser
{
  private static Parser<char, T> Tok<T>(Parser<char, T> token)
    => Try(token).Before(SkipWhitespaces);
}
