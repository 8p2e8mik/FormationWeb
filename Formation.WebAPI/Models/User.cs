using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Formation.WebAPI.Models;

public class User
{
    [Key] public Guid Id { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(50, ErrorMessage = "Error email cannot be longer than 50 characters.")]
    public required string Email { get; set; }

    [Required]
    [MinLength(8, ErrorMessage = "Error password must be at least 8 characters long.")]
    [MaxLength(50, ErrorMessage = "Error password cannot be long than 50 characters")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserDetails? Details { get; set; }
    public List<Role> Roles { get; set; } = [];
}