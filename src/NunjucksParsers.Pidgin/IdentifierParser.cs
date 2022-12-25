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

  private static readonly Parser<char, Node> _identifierSegment =
    OneOf(
      // Case of code name with index access [...]
      Try(
        Map(
          (codeName, _, index, _) => new IdentifierSegment(codeName as CodeName, index as Expr) as Node,
          _codeName,
          Char('['),
          ExprParser.Expr,
          Char(']')
        )
      ),
      // Case of plain code name without index access
      _codeName.Select(codeName => new IdentifierSegment(codeName as CodeName) as Node)
    )
    .Labelled("identifier segment");

  private static readonly Parser<char, Node> _propertyAccess =
    Rec(() =>
      Map(
        (seg, _, id) => new PropertyAccess(seg as IdentifierSegment, id as Identifier) as Node,
        _identifierSegment,
        Char('.'),
        Identifier
      )
    )
    .Labelled("property access");

  public static readonly Parser<char, Node> Identifier =
    OneOf<char, Node>(
      Try(_propertyAccess),
      _identifierSegment
    )
    .Labelled("identifier");

  public static Identifier ParseOrThrow(string input)
    => Identifier.ParseOrThrow(input) as Identifier;
}
