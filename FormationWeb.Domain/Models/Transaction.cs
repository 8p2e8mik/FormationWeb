namespace FormationWeb.Domain.Models;

public class Transaction : EntityRoot
{
    public string? TransactionTitle { get; set; }
    public string? Description { get; set; }
    public Guid UserId { get; set; }
}