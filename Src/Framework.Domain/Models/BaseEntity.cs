namespace Framework.Domain.Models;
public abstract class BaseEntity<TEntity, TId> : IModel where TEntity : BaseEntity<TEntity, TId> where TId : struct
{
    private int? _requestedHashCode;

    public TId Id { get; protected set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || !(obj is BaseEntity<TEntity, TId>))
        {
            return false;
        }

        if (this == obj)
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        BaseEntity<TEntity, TId> baseEntity = (BaseEntity<TEntity, TId>)obj;
        return baseEntity.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        if (!_requestedHashCode.HasValue)
        {
            _requestedHashCode = Id.GetHashCode() ^ 0x1F;
        }

        return _requestedHashCode.Value;
    }

    public static bool operator ==(BaseEntity<TEntity, TId>? left, BaseEntity<TEntity, TId>? right)
    {
        return Equals(left, null) ? Equals(right, null) : left.Equals(right);
    }

    public static bool operator !=(BaseEntity<TEntity, TId>? left, BaseEntity<TEntity, TId>? right)
    {
        return !(left == right);
    }
}