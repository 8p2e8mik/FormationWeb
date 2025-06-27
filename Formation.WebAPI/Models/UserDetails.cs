namespace Formation.WebAPI.Models;

public class UserDetails
{
    public Guid Id { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public string? Address { get; set; }
    public Guid UserId { get; set; }
}