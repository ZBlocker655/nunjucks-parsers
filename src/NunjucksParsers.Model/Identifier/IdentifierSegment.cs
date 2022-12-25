using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;

namespace NunjucksParsers.Model.Identifier;

/// <summary>
/// Parse tree node representing an identifier segment consisting
/// of a code name + a posible index accessor "[...]".
/// </summary>
public class IdentifierSegment: Identifier
{
  public CodeName CodeName { get; }
  public Expr? Index { get; }

  public IdentifierSegment(CodeName codeName, Expr? index = null)
  {
    CodeName = codeName;
    Index = index;
  }

  public override bool Equals(Node? other)
    => other is IdentifierSegment seg
      && CodeName.Equals(seg.CodeName)
      && (
        (Index == null && seg.Index == null)
        || (Index != null && seg.Index != null && Index.Equals(seg.Index))
      );

  public override int GetHashCode() => HashCode.Combine(CodeName, Index);
}
