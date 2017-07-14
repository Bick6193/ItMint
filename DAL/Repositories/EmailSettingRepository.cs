using DAL.Context;
using DAL.Repository;
using DAL.Model;
using Domain.MailSettings;
using ScheduleModelLib.DB;

namespace DAL.Repositories
{
    public class EmailSettingRepository : RepositoryBase<EmailSettings, EmailSettingsDetails>
    {
        public EmailSettingRepository(AppContext context) : base(context)
        {
            
        }
    }
}
