using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Request
{
  public class RequestDTO
  {
    public int Id { get; set; }

    [StringLength(450)]
    [MaxLength(50, ErrorMessage = "Максимальна длина не должна превышать 50 символов")]
    [Required(ErrorMessage = "Поле не может быть пустым.")]
    public string Name { get; set; }

    [MaxLength(20, ErrorMessage = "Максимальна длина не должна превышать 20 символов")]
    public string Phone { get; set; }

    [StringLength(450)]
    [Required(ErrorMessage = "Поле не может быть пустым.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [StringLength(450)]
    public string Country { get; set; }

    [MaxLength(1000, ErrorMessage = "Максимальна длина не должна превышать 1000 символов")]
    [Required(ErrorMessage = "Поле не может быть пустым.")]
    public string Description { get; set; }

    public bool Viewed { get; set; }

    public bool Flag { get; set; }

    public int? RequestTypeId { get; set; } 

    [StringLength(450)]
    public string RequestTypeInString { get; set; }

    public DateTime Date { get; set; }

    [StringLength(450)]
    public string UserId { get; set; }
  }
}
