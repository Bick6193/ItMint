using AutoMapper;
using DAL.Model;
using Domain.User;

namespace DAL.Mapping
{
    public class ApplicationUserProfile:Profile
    {
      public ApplicationUserProfile()
      {
        CreateMap<ApplicationUser, ApplicationUserLogin>();
      }
    }
}
