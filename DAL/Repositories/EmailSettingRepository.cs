using DAL.Context;
using DAL.Model;
using DAL.Repositories.RepositoriesAbstract;
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
