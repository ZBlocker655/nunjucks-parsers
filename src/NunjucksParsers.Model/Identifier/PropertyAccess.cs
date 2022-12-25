using NunjucksParsers.Model.Core;

namespace NunjucksParsers.Model.Identifier;

/// <summary>
/// Parse tree node representing an identifier accessing
/// a property with dot (.) notation.
/// </summary>
public class PropertyAccess: Identifier
{
  public Identifier Identifier { get; }
  public CodeName Property { get; }

  public PropertyAccess(Identifier identifier, CodeName property)
  {
    Identifier = identifier;
    Property = property;
  }

  public override bool Equals(Node? other)
    => other is PropertyAccess pa && Identifier.Equals(pa.Identifier) && Property.Equals(pa.Property);

  public override int GetHashCode() => HashCode.Combine(Identifier, Property);
}
