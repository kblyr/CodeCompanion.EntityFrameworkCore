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

        public virtual int? TrySaveChanges() => isHotSaveEnabled ? SaveChanges() : null;

        public virtual int? TrySaveChanges(bool acceptAllChangesOnSuccess) => isHotSaveEnabled ? SaveChanges(acceptAllChangesOnSuccess) : null;

        public virtual async Task<int?> TrySaveChangesAsync(CancellationToken cancellationToken = default) => isHotSaveEnabled ? await SaveChangesAsync(cancellationToken) : null;

        public virtual async Task<int?> TrySaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) => isHotSaveEnabled ? await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken) : null;
    }
}