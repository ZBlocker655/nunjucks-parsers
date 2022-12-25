using NunjucksParsers.Model.Core;

namespace NunjucksParsers.Model.Identifier;

/// <summary>
/// Parse tree node representing a code name such as "Foo".
/// </summary>
public class CodeName: Identifier
{
  public string Name { get; }

  public CodeName(string name)
  {
    Name = name;
  }

  public override bool Equals(Node? other)
    => other is CodeName cn && Name == cn.Name;

  public override int GetHashCode() => Name.GetHashCode(StringComparison.Ordinal);
}
