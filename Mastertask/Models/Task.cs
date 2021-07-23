using System;

namespace Mastertask.Models
{
  public class Task
  {
    public int Id { get; set; }
    public int ListId { get; set; }
    public string Name { get; set; }
    public bool IsDone { get; set; } = false;
    public string CreatorId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
  }
}