using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeCompanion.EntityFrameworkCore.Extensions
{
    public static class EntityEntryExtensions
    {
        public static EntityEntry<TEntity> AsSoftDeleted<TEntity>(this EntityEntry<TEntity> entry) where TEntity : class
        {
            entry.Property<bool>(ShadowProperties.IsDeleted).CurrentValue = true;
            return entry;
        }

        public static EntityEntry<TEntity> AsSoftDeleted<TEntity>(this EntityEntry<TEntity> entry, Footprint footprint) where TEntity : class => entry
            .AsSoftDeleted()
            .WithDeleteFootprint(footprint); 

        public static EntityEntry<TEntity> WithInsertFootprint<TEntity>(this EntityEntry<TEntity> entry, Footprint footprint) where TEntity : class
        {
            entry.Property<int?>(ShadowProperties.InsertedById).CurrentValue = footprint.UserId;
            entry.Property<DateTimeOffset?>(ShadowProperties.InsertedOn).CurrentValue = footprint.Timestamp;
            return entry;
        }

        public static EntityEntry<TEntity> WithUpdateFootprint<TEntity>(this EntityEntry<TEntity> entry, Footprint footprint) where TEntity : class
        {
            entry.Property<int?>(ShadowProperties.UpdatedById).CurrentValue = footprint.UserId;
            entry.Property<DateTimeOffset?>(ShadowProperties.UpdatedOn).CurrentValue = footprint.Timestamp;
            return entry;
        }

        public static EntityEntry<TEntity> WithDeleteFootprint<TEntity>(this EntityEntry<TEntity> entry, Footprint footprint) where TEntity : class
        {
            entry.Property<int?>(ShadowProperties.DeletedById).CurrentValue = footprint.UserId;
            entry.Property<DateTimeOffset?>(ShadowProperties.DeletedOn).CurrentValue = footprint.Timestamp;
            return entry;
        }
    }
}