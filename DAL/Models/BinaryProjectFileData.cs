
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
  public class BinaryProjectFileData
  {
    [Key]
    public int Id { get; set; }

    public byte[] Content { get; set; }

    public virtual ProjectFile ProjectFile { get; set; }
  }
}
