namespace CodeCompanion.EntityFrameworkCore
{
    public struct DbColumnInfo
    {
        public readonly string PropertyName;
        public readonly Type PropertyType;

        public DbColumnInfo(string propertyName, Type propertyType)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
        }
    }
}