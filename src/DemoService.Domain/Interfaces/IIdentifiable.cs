namespace DemoService.Domain.Interfaces
{
    public interface IIdentifiable<TId>
    {
        TId Id { get; set; }
    }
}
