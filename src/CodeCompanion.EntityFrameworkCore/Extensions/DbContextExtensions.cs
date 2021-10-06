namespace CodeCompanion.EntityFrameworkCore.Extensions
{
    public static class DbContextExtensions 
    {
        public static TDbContext WithHotSave<TDbContext>(this TDbContext context) where TDbContext : CodeCompanionDbContext
        {
            context.EnableHotSave();
            return context;
        }
    }
}