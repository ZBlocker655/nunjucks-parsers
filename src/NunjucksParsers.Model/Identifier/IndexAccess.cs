using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;

namespace NunjucksParsers.Model.Identifier;

/// <summary>
/// Parse tree node representing an identifier with a trailing
/// index accessor "[...]".
/// </summary>
public class IndexAccess: Identifier
{
  public Identifier Identifier { get; }
  public Expr Index { get; }

  public IndexAccess(Identifier identifier, Expr index)
  {
    Identifier = identifier;
    Index = index;
  }

  public override bool Equals(Node? other)
    => other is IndexAccess ia && Identifier.Equals(ia.Identifier) && Index.Equals(ia.Index);

  public override int GetHashCode() => HashCode.Combine(Identifier, Index);
}
