﻿using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;
using NunjucksParsers.Model.Identifier;
using static NunjucksParsers.Pidgin.CoreHelpers;
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
    OneOf<char, Node>(
      _string,
      IdentifierParser.Identifier
    );
}