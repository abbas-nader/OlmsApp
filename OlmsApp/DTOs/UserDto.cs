using System.ComponentModel.DataAnnotations;

namespace OlmsApp.DTOs;

public class UserDto
{
 [Required(ErrorMessage = "Enter UserName")]  [MinLength(3)] public string UserName { get; set; } = null!;
 [Required(ErrorMessage ="Enter UserName")]  [MaxLength(4)] public string Password { get; set; } = null!; 

}