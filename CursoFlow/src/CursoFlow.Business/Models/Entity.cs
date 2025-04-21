﻿namespace CursoFlow.Business.Models;

public abstract class Entity
{
    public Guid Id { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    protected Entity(Guid id)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other) return false;
        if (ReferenceEquals(this, other)) return true;

        return Id.Equals(other.Id);
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b) => !(a == b);

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString() => $"{GetType().Name} [Id={Id}]";
}
