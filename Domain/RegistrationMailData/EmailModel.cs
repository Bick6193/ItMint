using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace Domain.RegistrationMailData
{
  public class EmailModel
  {
    public int Id { get; set; }

    public string FullName { get; set; }

    [NotNull]
    public string EmailFor { get; set; }
  }
}
