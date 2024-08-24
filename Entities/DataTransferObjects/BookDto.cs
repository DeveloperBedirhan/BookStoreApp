namespace Entities.DataTransferObjects
{
    public record BookDto
    {
        public int Id { get; init; }
        public string? Title { get; init; }
        public double Price { get; init; }
    }
}
