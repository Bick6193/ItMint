using DAL.Context;
using DAL.Repository;
using DAL.Model;
using Domain.MailSettings;

namespace DAL.Repositories
{
    public class EmailSettingRepository : RepWithStandartApi<EmailSettings, EmailSettingsDetails>
    {
        public EmailSettingRepository(ApplicationContext context) : base(context)
        {
            
        }
    }
}
