namespace DemoApi.Entities;

public class Demo
{
    public int Id { get; set; }
    public required string ClientName { get; set; }
    public DateTimeOffset Date { get; set; }
}
