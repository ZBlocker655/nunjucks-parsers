namespace NunjucksParsers.Model.Core;

/// <summary>
/// Base class for all parse tree nodes.
/// </summary>
public abstract class Node : IEquatable<Node>
{
  public abstract bool Equals(Node? other);

  public override bool Equals(object? obj) => Equals(obj as Node);

  public abstract override int GetHashCode();
}
