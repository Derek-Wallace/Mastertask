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
  public class ListsController : ControllerBase
  {
    private readonly ListsService _ls;

    public ListsController(ListsService ls)
    {
      _ls = ls;
    }
    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<List>>> GetAccountLists()
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          var lists = _ls.GetAccountLists(userInfo.Id);
          return Ok(lists);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<List>> Create([FromBody] List data)
    {
      try
      {
          Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
          data.CreatorId = userInfo.Id;
          var l = _ls.Create(data);
          return Ok(l);
      }
      catch (System.Exception e)
      {
          return BadRequest(e.Message);
      }
    }
  }
}