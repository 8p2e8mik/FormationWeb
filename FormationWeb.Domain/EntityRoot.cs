using System.ComponentModel.DataAnnotations;

namespace FormationWeb.Domain;

public class EntityRoot
{
    [Key] public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}