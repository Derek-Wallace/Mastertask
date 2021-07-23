using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Mastertask.Models;
using Mastertask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mastertask.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TasksController : ControllerBase
  {
    private readonly TasksService _ts;

    public TasksController(TasksService ts)
    {
      _ts = ts;
    }
    [Authorize]
    [HttpGet("{lid}")]
    public async Task<ActionResult<List<Models.Task>>> GetTasksByLists(int lid)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          var Tasks = _ts.GetTasksByLists(lid);
          return Ok(Tasks);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost("{lid}")]
    public async Task<ActionResult<Models.Task>> Create([FromBody] Models.Task data, int lid)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          data.CreatorId = userInfo.Id;
          data.ListId = lid;
          var l = _ts.Create(data);
          return Ok(l);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}