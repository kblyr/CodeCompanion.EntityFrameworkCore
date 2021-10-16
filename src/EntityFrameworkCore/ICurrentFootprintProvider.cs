namespace CodeCompanion.EntityFrameworkCore
{
    public interface ICurrentFootprintProvider
    {
        Footprint Current { get; }
    }
}