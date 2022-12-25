using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Identifier;
using static NunjucksParsers.Pidgin.CoreHelpers;
using Pidgin;
using static Pidgin.Parser;

namespace NunjucksParsers.Pidgin;

public static class IdentifierParser
{
  public static readonly Parser<char, Node> Identifier =
    Tok("foo").Select<Node>(s => new CodeName("foo")); // TODO: placeholder

  public static Identifier ParseOrThrow(string input)
    => Identifier.ParseOrThrow(input) as Identifier;
}
