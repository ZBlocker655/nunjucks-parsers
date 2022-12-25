using NunjucksParsers.Model.Core;

namespace NunjucksParsers.Model.Identifier;

/// <summary>
/// Parse tree node representing an identifier segment accessing
/// a property with dot (.) notation.
/// </summary>
public class PropertyAccess: Identifier
{
  public IdentifierSegment Segment { get; }
  public Identifier PropertyRef { get; }

  public PropertyAccess(IdentifierSegment segment, Identifier propertyRef)
  {
    Segment = segment;
    PropertyRef = propertyRef;
  }

  public override bool Equals(Node? other)
    => other is PropertyAccess pa && Segment.Equals(pa.Segment) && PropertyRef.Equals(pa.PropertyRef);

  public override int GetHashCode() => HashCode.Combine(Segment, PropertyRef);
}
