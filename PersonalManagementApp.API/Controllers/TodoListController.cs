using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalManagementApp.Core.Contracts;
using PersonalManagementApp.Core.Models.TodoList;

namespace PersonalManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {

        private readonly ITodoListService todoListService;

        public TodoListController(ITodoListService _todoListService)
        {
            todoListService = _todoListService;
        }


        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await todoListService.GetAll());
        }

        [HttpPost]
        [Route("add")]
        public async Task<String> Add([FromBody] TodoModel todoObject)
        {

            return await todoListService.Add(todoObject);
        }

        [HttpPost]
        [Route("setNewTodos")]
        public async Task<List<String>> SetNewTodos([FromBody] IEnumerable<TodoModel> todoObjects)
        {

            return (List<string>) await todoListService.SetNewTodos(todoObjects);
        }


        [HttpPut]
        [Route("edit")]
        public async Task<String> Edit([FromBody] TodoModel todoObject)
        {

            return await todoListService.Edit(todoObject);
        }

       

        [HttpDelete]
        [Route("deleteById")]
        public async Task DeleteById([FromQuery] string todoId)
        {

            await todoListService.DeleteById(todoId);
        }
    }
}
