using System.ComponentModel.DataAnnotations.Schema;

public class EventEntity
{
    public int Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Title { get; set; }
    public string? Location { get; set; }
    public string? Description { get; set; }
}