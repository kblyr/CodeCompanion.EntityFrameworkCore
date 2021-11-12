using CodeCompanion.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeCompanion.EntityFrameworkCore
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

        public static TEntity? FindById<TEntity>(this DbSet<TEntity> entities, short id) where TEntity : class => entities
            .Find(new object[] { id });

        public static TEntity? FindById<TEntity>(this DbSet<TEntity> entities, int id) where TEntity : class => entities
            .Find(new object[] { id });

        public static TEntity? FindById<TEntity>(this DbSet<TEntity> entities, long id) where TEntity : class => entities
            .Find(new object[] { id });

        public static async Task<TEntity?> FindByIdAsync<TEntity>(this DbSet<TEntity> entities, short id, CancellationToken cancellationToken = default) where TEntity : class => await entities
            .FindAsync(new object[] { id }, cancellationToken);

        public static async Task<TEntity?> FindByIdAsync<TEntity>(this DbSet<TEntity> entities, int id, CancellationToken cancellationToken = default) where TEntity : class => await entities
            .FindAsync(new object[] { id }, cancellationToken);

        public static async Task<TEntity?> FindByIdAsync<TEntity>(this DbSet<TEntity> entities, long id, CancellationToken cancellationToken = default) where TEntity : class => await entities
            .FindAsync(new object[] { id }, cancellationToken);
    }
}