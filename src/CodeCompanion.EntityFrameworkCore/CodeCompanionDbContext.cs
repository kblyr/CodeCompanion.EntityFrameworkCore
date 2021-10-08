using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
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

        [Obsolete("Use 'TrySaveChanges(...)' or 'TrySaveChangesAsync(...)' instead")]
        public virtual int HotSaveChanges() => isHotSaveEnabled
            ? SaveChanges()
            : throw new HotSaveDisabledException();
        
        [Obsolete("Use 'TrySaveChanges(...)' or 'TrySaveChangesAsync(...)' instead")]
        public virtual int HotSaveChanges(bool acceptAllChangesOnSuccess) => isHotSaveEnabled
            ? SaveChanges(acceptAllChangesOnSuccess)
            : throw new HotSaveDisabledException();

        [Obsolete("Use 'TrySaveChangesAsync(...) instead'")]
        public virtual async Task<int> HotSaveChangesAsync(CancellationToken cancellationToken = default) => isHotSaveEnabled
            ? await SaveChangesAsync(cancellationToken)
            : throw new HotSaveDisabledException();

        [Obsolete("Use 'TrySaveChangesAsync(...) instead'")]
        public virtual async Task<int> HotSaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) => isHotSaveEnabled
            ? await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken)
            : throw new HotSaveDisabledException();

        [Obsolete("Use 'TrySaveChanges(...)' or 'TrySaveChangesAsync(...)' instead")]
        public virtual int? TryHotSaveChanges() => isHotSaveEnabled
            ? SaveChanges()
            : null;
        
        [Obsolete("Use 'TrySaveChanges(...)' or 'TrySaveChangesAsync(...)' instead")]
        public virtual int? TryHotSaveChanges(bool acceptAllChangesOnSuccess) => isHotSaveEnabled
            ? SaveChanges()
            : null;

        [Obsolete("Use 'TrySaveChangesAsync(...) instead'")]
        public virtual async Task<int?> TryHotSaveChangesAsync(CancellationToken cancellationToken = default) => isHotSaveEnabled
            ? await SaveChangesAsync(cancellationToken)
            : null;

        [Obsolete("Use 'TrySaveChangesAsync(...) instead'")]
        public virtual async Task<int?> TryHotSaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) => isHotSaveEnabled
            ? await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken)
            : null;

        public virtual int? TrySaveChanges() => isHotSaveEnabled ? SaveChanges() : null;

        public virtual int? TrySaveChanges(bool acceptAllChangesOnSuccess) => isHotSaveEnabled ? SaveChanges(acceptAllChangesOnSuccess) : null;

        public virtual async Task<int?> TrySaveChangesAsync(CancellationToken cancellationToken = default) => isHotSaveEnabled ? await SaveChangesAsync(cancellationToken) : null;

        public virtual async Task<int?> TrySaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) => isHotSaveEnabled ? await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken) : null;
    }
}