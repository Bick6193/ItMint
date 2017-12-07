using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;

namespace Domain.RegistrationMailData
{
  public class SetPasswordIdentity : ISetPasswordIdentity
  {
    public void SendEmailRuntime(EmailModel emailModel, string message)
    {
      try
      {
        string fromAddress = "sviridovich1nikita@gmail.com"; //temporary


        string fromAdressTitle = "ItMint";
        string toAddress = emailModel.EmailFor;
        string toAdressTitle = "For";
        string subject = "ItMint";
        string bodyContent = message;

        string SmtpServer = "smtp.gmail.com";
        int SmtpPortNumber = 587;

        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(fromAdressTitle, fromAddress));
        mimeMessage.To.Add(new MailboxAddress(toAdressTitle, toAddress));
        mimeMessage.Subject = subject;
        mimeMessage.Body = new TextPart("plain")
        {
          Text = bodyContent

        };

        using (var client = new SmtpClient())
        {
          client.Connect(SmtpServer, SmtpPortNumber, false);
          client.Authenticate("sviridovich1nikita@gmail.com", "280697bick"); //default email
          client.Send(mimeMessage);
          client.Disconnect(true);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
