namespace NunjucksParsers.Pidgin.Test;

using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;
using NunjucksParsers.Model.Identifier;
using NunjucksParsers.Pidgin;

public class ExprParserTests
{
  public static IEnumerable<object[]> Cases =>
    new List<object[]>
    {
      new object[]
      {
        true,
        "\"foo\"",
        new StringLiteral("foo")
      },
      new object[]
      {
        true,
        "'foo'",
        new StringLiteral("foo")
      },
      new object[]
      {
        false,
        "'foo\"",
        null
      },
      new object[]
      {
        true,
        "myFooVariable",
        new IdentifierSegment(new CodeName("myFooVariable"))
      },
    };

  [Theory]
  [MemberData(nameof(Cases))]
  public void ParseOrThrow(bool expectToParse, string input, Node expectedTree)
  {
    if (expectToParse)
    {
      var actualTree = ExprParser.ParseOrThrow(input) as Node;
      Assert.True(actualTree.Equals(expectedTree));
    }
    else
    {
      Assert.Throws<ParseException>(() => ExprParser.ParseOrThrow(input));
    }
  }
}
