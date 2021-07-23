using System;

namespace Mastertask.Models
{
  public class List
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}