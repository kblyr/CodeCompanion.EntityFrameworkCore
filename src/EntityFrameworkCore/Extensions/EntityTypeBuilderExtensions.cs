using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeCompanion.EntityFrameworkCore.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static PropertyBuilder Property(this EntityTypeBuilder builder, DbColumnInfo columnInfo) => builder.Property(columnInfo.PropertyType, columnInfo.PropertyName);

        public static EntityTypeBuilder<TEntity> AsSoftDeletable<TEntity>(this EntityTypeBuilder<TEntity> builder, DbColumnInfo columnInfo) where TEntity : class 
        {
            builder.Property(columnInfo);
            return builder;
        }

        public static EntityTypeBuilder<TEntity> AsSoftDeletable<TEntity>(this EntityTypeBuilder<TEntity> builder, bool isQueryFiltered = true) where TEntity : class
        {
            builder.Property<bool>(ShadowProperties.IsDeleted);

            if (isQueryFiltered)
                builder.HasQueryFilter(_ => EF.Property<bool>(_, ShadowProperties.IsDeleted) == false);

            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasInsertFootprint<TEntity>(this EntityTypeBuilder<TEntity> builder, DbColumnInfo insertedByIdColumnInfo, DbColumnInfo insertedOnColumnInfo) where TEntity : class
        {
            builder.Property(insertedByIdColumnInfo);
            builder.Property(insertedOnColumnInfo);
            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasInsertFootprint<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
        {
            builder.Property<int?>(ShadowProperties.InsertedById);
            builder.Property<DateTimeOffset?>(ShadowProperties.InsertedOn);
            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasUpdateFootprint<TEntity>(this EntityTypeBuilder<TEntity> builder, DbColumnInfo updatedByIdColumnInfo, DbColumnInfo updatedOnColumnInfo) where TEntity : class
        {
            builder.Property(updatedByIdColumnInfo);
            builder.Property(updatedOnColumnInfo);
            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasUpdateFootprint<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
        {
            builder.Property<int?>(ShadowProperties.UpdatedById);
            builder.Property<DateTimeOffset?>(ShadowProperties.UpdatedOn);
            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasDeleteFootprint<TEntity>(this EntityTypeBuilder<TEntity> builder, DbColumnInfo deletedByIdColumnInfo, DbColumnInfo deletedOnColumnInfo) where TEntity : class
        {
            builder.Property(deletedByIdColumnInfo);
            builder.Property(deletedOnColumnInfo);
            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasDeleteFootprint<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
        {
            builder.Property<int?>(ShadowProperties.DeletedById);
            builder.Property<DateTimeOffset?>(ShadowProperties.DeletedOn);
            return builder;
        }
    }
}