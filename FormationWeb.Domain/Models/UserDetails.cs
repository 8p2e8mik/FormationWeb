namespace FormationWeb.Domain.Models;

public class UserDetails : EntityRoot
{
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public Guid UserId { get; set; }
}