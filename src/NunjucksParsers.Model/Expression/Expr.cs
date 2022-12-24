namespace NunjucksParsers.Model.Expression;

public abstract class Expr : IEquatable<Expr>
{
  public abstract bool Equals(Expr? other);

  public override bool Equals(object? obj) => Equals(obj as Expr);

  public abstract override int GetHashCode();
}
