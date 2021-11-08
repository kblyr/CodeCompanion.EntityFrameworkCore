using System.Diagnostics.CodeAnalysis;
using CodeCompanion.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CodeCompanion.EntityFrameworkCore
{
    public class CodeCompanionDbContext : DbContext
    {
        private bool isHotSaveEnabled = false;

        public CodeCompanionDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected CodeCompanionDbContext()
        {
        }

        public virtual Footprint CurrentFootprint => Database.GetService<ICurrentFootprintProvider>().Current;

        public void EnableHotSave() => isHotSaveEnabled = true;

        public void DisableHotSave() => isHotSaveEnabled = false;

        public virtual int? TrySaveChanges()
        {
            if (isHotSaveEnabled)
            {
                var result = SaveChanges();
                DisableHotSave();
                return result;
            }

            return null;
        }

        public virtual int? TrySaveChanges(bool acceptAllChangesOnSuccess)
        {
            if (isHotSaveEnabled)
            {
                var result = SaveChanges(acceptAllChangesOnSuccess);
                DisableHotSave();
                return result;
            }

            return null;
        }

        public virtual async Task<int?> TrySaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (isHotSaveEnabled)
            {
                var result = await SaveChangesAsync(cancellationToken);
                DisableHotSave();
                return result;
            }

            return null;
        }

        public virtual async Task<int?> TrySaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            if (isHotSaveEnabled)
            {
                var result = await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
                DisableHotSave();
                return result;
            }

            return null;
        }
    }
}