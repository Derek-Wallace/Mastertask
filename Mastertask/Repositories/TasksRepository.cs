using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Mastertask.Models;

namespace Mastertask.Repositories
{
  public class TasksRepository
  {
    private readonly IDbConnection _db;

    public TasksRepository(IDbConnection db)
    {
      _db = db;
    }

    public Task Create(Task data)
    {
      var sql = @"
      INSERT INTO tasks(name, creatorId, listId)
      VALUES(@Name, @CreatorId, @ListId);
      SELECT LAST_INSERT_ID();
      ";
      var id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public List<Task> GetTasksByLists(int id)
    {
      var sql = "SELECT * FROM tasks WHERE listId = @id";
      return _db.Query<Task>(sql, new { id }).ToList();
    }
  }
}