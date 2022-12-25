using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;

namespace NunjucksParsers.Model.Template;

/// <summary>
/// Parse tree node representing a template insertion
/// with a single expression in it; would look like
/// {{ something["here"].someAttribute }}
/// </summary>
public class ValueInsertion: Node
{
  public Expr Value { get; }

  public ValueInsertion(Expr value)
  {
    Value = value;
  }

  public override bool Equals(Node? other)
    => other is ValueInsertion vi && Value.Equals(vi.Value);

  public override int GetHashCode() => Value.GetHashCode();
}
