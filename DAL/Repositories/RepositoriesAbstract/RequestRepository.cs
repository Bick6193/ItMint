using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Infrastructure;
using Domain.Request;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class RequestRepository : IRequestRepository
  {
    private ApplicationContext ApplicationContext { get; }

    public RequestRepository(ApplicationContext context)
    {
      ApplicationContext = context;
    }

    public IEnumerable<RequestDTO> GetAll()
    {
      return AutoMapper.Mapper.Map<List<RequestDTO>>(ApplicationContext.Requests.OrderByDescending(key => key.Id));
    }

    public RequestDTO GetById(int id)
    {
      var temp = ApplicationContext.Requests.Where(value => value.Id == id);
      foreach (var items in temp)
      {
        if (!items.Viewed)
        {
          items.Viewed = true;
        }
      }
      ApplicationContext.SaveChanges();

      return AutoMapper.Mapper.Map<RequestDTO>(ApplicationContext.Requests.Find(id));
    }

    public IEnumerable<RequestDTO> BasicSearch(InboxPanelService dataContainer)
    {
      if (!string.IsNullOrEmpty(dataContainer.SearchDataContainer.SearchTerm))
      {
        var temp = dataContainer.SearchDataContainer.SearchTerm
          .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
          .Select(x => x.ToLower()).ToList();
        try
        {
          return AutoMapper.Mapper.Map<List<RequestDTO>>(ApplicationContext.Requests
              .Where(x => temp.All(term => x.Email.ToLower().Contains(term)
                                           || x.Name.ToLower().Contains(term)
                                           || x.RequestTypeInString.ToLower().Contains(term)
                                           || x.Country.ToLower().Contains(term))))
            .OrderByDescending(key => key.Id);
        }
        catch (Exception e)
        {
          return null;
        }
        
      }
      return GetAll();
    }

    public DataRequestServices CountRequests()
    {

      DataRequestServices dataRequestServices = new DataRequestServices();

      int notViewed = (from i in ApplicationContext.Requests
                       where i.Viewed == false
                       select i.Id).Count();
      dataRequestServices.NotViewed = notViewed;

      DateTime latestRequest = (from i in ApplicationContext.Requests
                                select i.Date)
                                .LastOrDefault();

      dataRequestServices.LatestRequest = latestRequest;

      int totalRequest = ApplicationContext.Requests.Count();

      dataRequestServices.TotalRequests = totalRequest;

      List<string> topTypes = ApplicationContext.Requests
        .GroupBy(q => q.RequestTypeInString)
        .OrderByDescending(gp => gp.Count())
        .Take(3)
        .Select(g => g.Key).ToList();

      dataRequestServices.TopTypes = topTypes;

      List<string> topCountry = ApplicationContext.Requests
        .GroupBy(q => q.Country)
        .OrderByDescending(gp => gp.Count())
        .Take(3)
        .Select(g => g.Key).ToList();

      dataRequestServices.TopCountry = topCountry;

      //int decrease = 

      return dataRequestServices;
    }

    public void Insert(Request request)
    {
      request.Country = "Minsk, Belarus";
      ApplicationContext.Requests.Add(request);
      ApplicationContext.SaveChanges();
    }

    public void GetFlag(int id)
    {
      var tempFlag = ApplicationContext.Requests.Where(x => x.Id == id);
      foreach (var item in tempFlag)
      {
        if (!item.Flag)
        {
          item.Flag = true;
        }
        else if(item.Flag)
        {
          item.Flag = false;
        }
      }
      ApplicationContext.SaveChanges();
    }

    public void Delete(int id)
    {
      Request request = ApplicationContext.Requests.Find(id);
      if (request != null)
      {
        ApplicationContext.Requests.Remove(request);
      }
      ApplicationContext.SaveChanges();
    }


  }
}
