using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;
using Pidgin;
using static Pidgin.Parser;

namespace NunjucksParsers.Pidgin;

public static class ExprParser
{
  private static readonly Parser<char, Node> _string =
    OneOf(
      AnyCharExcept('"').Many().Between(Char('"'), Char('"')),
      AnyCharExcept('\'').Many().Between(Char('\''), Char('\''))
    )
    .Select<Node>(chars => new StringLiteral(new String(chars.ToArray())))
    .Labelled("string literal");

  public static readonly Parser<char, Node> Expr =
    Rec(() =>
      OneOf<char, Node>(
        Try(_string),
        IdentifierParser.Identifier
      )
    );

  public static Expr ParseOrThrow(string input)
    => Expr.ParseOrThrow(input) as Expr;
}
