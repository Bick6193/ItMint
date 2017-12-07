using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RegistrationMailData
{
  public interface ISetPasswordIdentity
  {
    void SendEmailRuntime(EmailModel emailModel, string message);
  }
}
