namespace CodeCompanion.EntityFrameworkCore
{
    public static class DbContextExtensions 
    {
        public static TDbContext WithHotSave<TDbContext>(this TDbContext context) where TDbContext : CodeCompanionDbContext
        {
            context.EnableHotSave();
            return context;
        }

        public static TDbContext WithoutHotSave<TDbContext>(this TDbContext context) where TDbContext : CodeCompanionDbContext
        {
            context.DisableHotSave();
            return context;
        }
    }
}