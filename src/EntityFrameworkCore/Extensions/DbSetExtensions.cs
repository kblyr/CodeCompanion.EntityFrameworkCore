using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeCompanion.EntityFrameworkCore.Extensions
{
    public static class DbSetExtensions
    {
        public static EntityEntry<TEntity> Add<TEntity>(this DbSet<TEntity> entities, TEntity entity, Footprint footprint) where TEntity : class => entities
            .Add(entity)
            .WithInsertFootprint(footprint);

        public static EntityEntry<TEntity> Update<TEntity>(this DbSet<TEntity> entities, TEntity entity, Footprint footprint) where TEntity : class => entities
            .Update(entity)
            .WithUpdateFootprint(footprint);

        public static EntityEntry<TEntity> SoftDelete<TEntity>(this DbSet<TEntity> entities, TEntity entity) where TEntity : class => entities
            .Update(entity)
            .AsSoftDeleted();

        public static EntityEntry<TEntity> SoftDelete<TEntity>(this DbSet<TEntity> entities, TEntity entity, Footprint footprint) where TEntity : class => entities
            .Update(entity)
            .AsSoftDeleted(footprint);
    }
}