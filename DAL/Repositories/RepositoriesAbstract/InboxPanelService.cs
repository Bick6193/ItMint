using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.RepositoriesAbstract
{
  public class SearchData
  {
    public string SearchTerm { get; set; }

    public string SearchFilter1 { get; set; }
    public string SearchFilter2 { get; set; }
    public string SearchFilter3 { get; set; }
    public string SearchFilter4 { get; set; }
    public string SearchFilter5 { get; set; }
  }

  public class DataContainer : SearchData
  {
    public string Field1 { get; set; }
    public string Field2 { get; set; }
  }

  public class InboxPanelService
  {
    public DataContainer SearchDataContainer { get; }

    public InboxPanelService()
    {
      SearchDataContainer = new DataContainer();
    }
    
  }
}
