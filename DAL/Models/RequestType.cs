using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
  public class RequestType
  {
    public int Id { get; set; }

    [MaxLength(20, ErrorMessage = "Максимальна длина не должна превышать 20 символов")]
    [Required(ErrorMessage = "Поле не может быть пустым.")]
    public string Type { get; set; }

    public virtual List<Request> RequestForms { get; set; }

    [DataType(DataType.EmailAddress)]
    public string EmployeesEmail { get; set; }

    public string EmployeesName { get; set; }

    public bool SendEmailToEmployee { get; set; }

    public bool SendEmailToCustomer { get; set; }

    [DataType(DataType.Html)]
    public string MessageToCustomer { get; set; }

    public string MessageBodyToCustomer { get; set; }

    public bool IsDefault { get; set; }

    public bool IsEnabled { get; set; }

    public int OrderWeight { get; set; }

    public string Color { get; set; }
  }
}
