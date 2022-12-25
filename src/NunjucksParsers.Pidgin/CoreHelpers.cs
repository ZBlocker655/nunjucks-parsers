using Pidgin;
using static Pidgin.Parser;

namespace NunjucksParsers.Pidgin;

public static class CoreHelpers
{
  public static Parser<char, T> Tok<T>(Parser<char, T> token)
    => Try(token).Before(SkipWhitespaces);

  public static Parser<char, string> Tok(string token)
    => Tok(String(token));
}
