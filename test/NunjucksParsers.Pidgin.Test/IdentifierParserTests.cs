namespace NunjucksParsers.Pidgin.Test;

using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;
using NunjucksParsers.Model.Identifier;
using NunjucksParsers.Pidgin;

public class IdentifierParserTests
{
  public static IEnumerable<object[]> Cases =>
    new List<object[]>
    {
      new object[]
      {
        true,
        "foo",
        new IdentifierSegment(
          new CodeName("foo")
        )
      },
      new object[]
      {
        true,
        "foo.bar",
        new PropertyAccess(
          new IdentifierSegment(
            new CodeName("foo")
          ),
          new IdentifierSegment(
            new CodeName("bar")
          )
        )
      },
      new object[]
      {
        true,
        "foo.bar.baz",
        new PropertyAccess(
          new IdentifierSegment(
            new CodeName("foo")
          ),
          new PropertyAccess(
            new IdentifierSegment(
              new CodeName("bar")
            ),
            new IdentifierSegment(
              new CodeName("baz")
            )
          )
        )
      },
      new object[]
      {
        true,
        "foo[\"prop\"]",
        new IdentifierSegment(
          new CodeName("foo"),
          new StringLiteral("prop")
        )
      },
      new object[]
      {
        true,
        "foo[\"prop\"].bar",
        new PropertyAccess(
          new IdentifierSegment(
            new CodeName("foo"),
            new StringLiteral("prop")
          ),
          new IdentifierSegment(
            new CodeName("bar")
          )
        )
      },
      new object[]
      {
        true,
        "foo.bar[\"prop\"]",
        new PropertyAccess(
          new IdentifierSegment(
            new CodeName("foo")
          ),
          new IdentifierSegment(
            new CodeName("bar"),
            new StringLiteral("prop")
          )
        )
      },
      new object[]
      {
        true,
        "foo[\"prop\"].bar[\"prop\"]",
        new PropertyAccess(
          new IdentifierSegment(
            new CodeName("foo"),
            new StringLiteral("prop")
          ),
          new IdentifierSegment(
            new CodeName("bar"),
            new StringLiteral("prop")
          )
        )
      },
      new object[]
      {
        true,
        "foo[something.else].bar[\"prop\"]",
        new PropertyAccess(
          new IdentifierSegment(
            new CodeName("foo"),
            new PropertyAccess(
              new IdentifierSegment(
                new CodeName("something")
              ),
              new IdentifierSegment(
                new CodeName("else")
              )
            )
          ),
          new IdentifierSegment(
            new CodeName("bar"),
            new StringLiteral("prop")
          )
        )
      },
      new object[]
      {
        true,
        "foo[something[\"a\"].else].bar[\"prop\"]",
        new PropertyAccess(
          new IdentifierSegment(
            new CodeName("foo"),
            new PropertyAccess(
              new IdentifierSegment(
                new CodeName("something"),
                new StringLiteral("a")
              ),
              new IdentifierSegment(
                new CodeName("else")
              )
            )
          ),
          new IdentifierSegment(
            new CodeName("bar"),
            new StringLiteral("prop")
          )
        )
      },
    };

  [Theory]
  [MemberData(nameof(Cases))]
  public void ParseOrThrow(bool expectToParse, string input, Node expectedTree)
  {
    if (expectToParse)
    {
      var actualTree = IdentifierParser.ParseOrThrow(input) as Node;
      Assert.True(actualTree.Equals(expectedTree));
    }
    else
    {
      Assert.Throws<ParseException>(() => IdentifierParser.ParseOrThrow(input));
    }
  }
}
