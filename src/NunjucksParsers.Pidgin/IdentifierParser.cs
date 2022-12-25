using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;
using NunjucksParsers.Model.Identifier;
using static NunjucksParsers.Pidgin.CoreHelpers;
using Pidgin;
using static Pidgin.Parser;

namespace NunjucksParsers.Pidgin;

public static class IdentifierParser
{
  private static readonly Parser<char, Node> _codeName =
    (
      from first in Letter
      from rest in OneOf(Letter, Digit, Char('_')).ManyString()
      select new CodeName(first + rest) as Node
    )
    .Labelled("code name");

  private static readonly Parser<char, Node> _propertyAccess =
    Rec(() =>
      Map(
        (id, _, prop) => new PropertyAccess(id as Identifier, prop as CodeName) as Node,
        Identifier,
        Char('.'),
        _codeName
      )
    )
    .Labelled("property access");

  private static readonly Parser<char, Node> _indexAccess =
    Rec(() =>
      Map(
        (id, _, index, _) => new IndexAccess(id as Identifier, index as Expr) as Node,
        Identifier,
        Char('['),
        ExprParser.Expr,
        Char(']')
      )
    )
    .Labelled("index access");

  public static readonly Parser<char, Node> Identifier =
    OneOf<char, Node>(
      Try(_indexAccess),
      Try(_propertyAccess),
      _codeName
    );

  public static Identifier ParseOrThrow(string input)
    => Identifier.ParseOrThrow(input) as Identifier;
}
