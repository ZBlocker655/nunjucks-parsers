using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;
using NunjucksParsers.Model.Template;
using static NunjucksParsers.Pidgin.CoreHelpers;
using Pidgin;
using static Pidgin.Parser;

namespace NunjucksParsers.Pidgin;

public static class TemplateParser
{
  private static readonly Parser<char, Node> _valueInsertion =
    ExprParser.Expr
    .Between(Tok("{{"), SkipWhitespaces.Then(Tok("}}")))
    .Select<Node>(e => new ValueInsertion(e as Expr))
    .Labelled("value insertion");

  public static readonly Parser<char, Node> Template =
    _valueInsertion; // TODO: Lots nore options to be added later!

  public static Node ParseOrThrow(string input)
    => Template.ParseOrThrow(input) as Node;
}
