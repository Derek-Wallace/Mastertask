using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Mastertask.Models;

namespace Mastertask.Repositories
{
  public class ListsRepository
  {
    private readonly IDbConnection _db;

    public ListsRepository(IDbConnection db)
    {
      _db = db;
    }

    public List Create(List data)
    {
      var sql = @"
      INSERT INTO lists(name, creatorId)
      VALUES(@Name, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public List<List> GetAccountLists(string id)
    {
      var sql = "SELECT * FROM lists WHERE creatorId = @id";
      return _db.Query<List>(sql, new { id }).ToList();
    }
  }
}