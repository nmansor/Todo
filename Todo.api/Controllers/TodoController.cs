using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Dtos.Requests;
namespace Todo.api.Controllers
{
    using global::Todo.Application.Dtos.Responses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    using Microsoft.Extensions.Caching.Distributed;
    using System.Text.Json;

    namespace Todo.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class TodoController : ControllerBase
        {
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                List<TodoResponseDto> list = [];
                list.Add(new TodoResponseDto(Name: "start researching Langchain", IsCompleted: true));
                list.Add(new TodoResponseDto(Name: "start researching VectorDb", IsCompleted: true));

                return Ok(list);
            }
        }
        //public class TodoController : ControllerBase
        //{
        //    private readonly ITodoService _todoService;
        //    private readonly ILogger<TodoController> logger;
        //    private readonly IDistributedCache distributedCache;

        //    public TodoController(
        //        ITodoService todoService, ILogger<TodoController> logger, IDistributedCache distributedCache)
        //    {
        //        this._todoService = todoService;
        //        this.logger = logger;
        //        this.distributedCache = distributedCache;
        //    }


        //    [HttpGet]
        //    public async Task<IActionResult> Get()
        //    {
        //        logger.LogInformation($"Executing GET method inside a TodoController at {DateTime.Now}");

        //        var cache
        //             = await distributedCache.GetStringAsync("todo");


        //        if (!string.IsNullOrEmpty(cache) && cache != "[]")
        //        {
        //            return Ok(JsonSerializer.Deserialize<List<TodoResponseDto>>(cache));
        //        }

        //        var result = await _todoService.GetItems();

        //        if (result.IsFailure)
        //            return result.ToProblemDetails();

        //        var options = new DistributedCacheEntryOptions
        //        {
        //            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        //        };

        //        await distributedCache.SetStringAsync("todo", JsonSerializer.Serialize(result.Value), options);

        //        logger.LogInformation($"Execution of  GET method inside a TodoController completed at {DateTime.Now}");
        //        return Ok(result.Value);
        //    }


        //    [HttpPost]
        //    public async Task<IActionResult> Post(
        //        [FromBody] CreateTodoDto todo)
        //    {
        //        logger.LogInformation("Executing POST method inside a TodoController at {0}", DateTime.Now);
        //        var result = await _todoService.CreateTodoAsync(todo);
        //        return result.IsSuccess ? Created() : result.ToProblemDetails();
        //    }
       }

    }
