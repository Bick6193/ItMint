using AutoMapper;
using DAL.Models;
using Domain.Authorization;
using Domain.Request;

namespace DAL.Mapping
{
  public class RequestConfiguration : Profile
  {
    public RequestConfiguration()
    {
      CreateMap<Request, RequestDTO>();
      CreateMap<AppUser, UserDTO>();
      CreateMap<File, FileDTO>();
      CreateMap<RequestType, RequestTypeDTO>();
      CreateMap<RefreshTokenDetails, Token>();
      CreateMap<ProjectDTO, Projects>();
      CreateMap<UserDTO, AppUser>();
      CreateMap<Token, RefreshTokenDetails>();
      CreateMap<ApiUser, ApiClientDetails>();
    }
  }
}
