using NunjucksParsers.Model.Core;

namespace NunjucksParsers.Model.Expression;

/// <summary>
/// Parse tree node representing a string literal.
/// </summary>
public class StringLiteral: Expr
{
  public string Value { get; }

  public StringLiteral(string value)
  {
    Value = value;
  }

  public override bool Equals(Node? other)
    => other is StringLiteral sn && Value == sn.Value;

  public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);
}
