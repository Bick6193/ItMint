using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain
{
  public class FolderVersion : IFolderVersion
  {
    public string GetFolderVersion(string path)
    {
      int versionNumber = 0;
      List<string> versionCollection = new List<string>();
      try
      {
        Regex name = new Regex("Version");
        var folders = Directory.GetDirectories(path);
        foreach (var collection in folders)
        {
          if (name.IsMatch(collection))
          {
            versionCollection.Add(collection);
          }
        }

        versionNumber = versionCollection.Count + 1;
        return "\\Version" + versionNumber.ToString();
      }
      catch (Exception e)
      {
        return null;
      }
    }
  }
}
