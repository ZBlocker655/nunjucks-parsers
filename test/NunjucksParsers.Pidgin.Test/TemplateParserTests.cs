namespace NunjucksParsers.Pidgin.Test;

using NunjucksParsers.Model.Core;
using NunjucksParsers.Model.Expression;
using NunjucksParsers.Model.Identifier;
using NunjucksParsers.Model.Template;
using NunjucksParsers.Pidgin;

public class TemplateParserTests
{
  public static IEnumerable<object[]> Cases =>
    new List<object[]>
    {
      new object[]
      {
        true,
        "{{foo}}",
        new ValueInsertion(
          new IdentifierSegment(
            new CodeName("foo")
          )
        )
      },
      new object[]
      {
        true,
        "{{  foo }}",
        new ValueInsertion(
          new IdentifierSegment(
            new CodeName("foo")
          )
        )
      },
      new object[]
      {
        true,
        "{{ me.addresses[\"home\"].city }}",
        new ValueInsertion(
          new PropertyAccess(
            new IdentifierSegment(
              new CodeName("me")
            ),
            new PropertyAccess(
              new IdentifierSegment(
                new CodeName("addresses"),
                new StringLiteral("home")
              ),
              new IdentifierSegment(
                new CodeName("city")
              )
            )
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
      var actualTree = TemplateParser.ParseOrThrow(input) as Node;
      Assert.True(actualTree.Equals(expectedTree));
    }
    else
    {
      var tree = TemplateParser.ParseOrThrow(input);
      Assert.Throws<ParseException>(() => IdentifierParser.ParseOrThrow(input));
    }
  }
}
