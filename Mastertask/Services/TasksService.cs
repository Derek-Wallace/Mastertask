using System.Collections.Generic;
using Mastertask.Models;
using Mastertask.Repositories;

namespace Mastertask.Services
{
  public class TasksService
  {
    private readonly TasksRepository _tr;

    public TasksService(TasksRepository tr)
    {
      _tr = tr;
    }

    internal Task Create(Task data)
    {
      return _tr.Create(data);
    }

    internal List<Task> GetTasksByLists(int id)
    {
      return _tr.GetTasksByLists(id);
    }
  }
}