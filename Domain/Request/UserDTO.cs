using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Request
{
  public class UserDTO
  {
    
    public int Id { get; set; }

    [StringLength(450)]
    [MaxLength(20, ErrorMessage = "Максимальна длина не должна превышать 20 символов")]
    [Required(ErrorMessage = "Поле не может быть пустым.")]
    public string Login { get; set; }

    public string Position { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public UserType Type { get; set; }

    public bool Active { get; set; }

    public bool ForceToResetPassword { get; set; }

    public bool IsAdministrative { get; set; }
  }
}
