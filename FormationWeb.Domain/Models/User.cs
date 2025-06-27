using System.ComponentModel.DataAnnotations;

namespace FormationWeb.Domain.Models;

public class User : EntityRoot
{
    [Required]
    [EmailAddress]
    [StringLength(50, ErrorMessage = "Error email cannot be longer than 50 characters.")]
    public required string Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Error password must be at least 8 characters long.")]
    [MaxLength(50, ErrorMessage = "Error password cannot be long than 50 characters")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}