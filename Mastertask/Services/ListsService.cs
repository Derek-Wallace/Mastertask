using System.Collections.Generic;
using Mastertask.Models;
using Mastertask.Repositories;

namespace Mastertask.Services
{
  public class ListsService
  {
    private readonly ListsRepository _lr;

    public ListsService(ListsRepository lr)
    {
      _lr = lr;
    }

    internal List Create(List data)
    {
      return _lr.Create(data);
    }

    internal List<List> GetAccountLists(string id)
    {
      return _lr.GetAccountLists(id);
    }
  }
}