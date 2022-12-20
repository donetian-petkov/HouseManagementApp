using Microsoft.EntityFrameworkCore;
using PersonalManagementApp.Core.Contracts;
using PersonalManagementApp.Core.Models.TodoList;
using PersonalManagementApp.Infrastructure.Data.Common;
using PersonalManagementApp.Infrastructure.Data.Models.TodoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagementApp.Core.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly IRepository repo;

        public TodoListService(IRepository _repo)
        {
            repo = _repo;
        }
        public async Task<string> Add(TodoModel todoListModel)
        {
            var todoToCreate = new Todo()
            {
                Id = todoListModel.id,
                Title = todoListModel.title,
                Complete = todoListModel.complete,
            };

            await repo.AddAsync(todoToCreate);
            await repo.SaveChangesAsync();

            return todoToCreate.Id;

        }

        public async Task DeleteById(string todoId)
        {
            await repo.DeleteAsync<Todo>(todoId);
            await repo.SaveChangesAsync();
        }

        public async Task<string> Edit(TodoModel todoListModel)
        {
            
            var todoToEdit = await repo.GetByIdAsync<Todo>(todoListModel.id);

            todoToEdit.Title = todoListModel.title;

            todoToEdit.Complete = todoListModel.complete;

            await repo.SaveChangesAsync();

            return todoToEdit.Id;
        }

        public async Task<IEnumerable<TodoModel>> GetAll()
        {
            return await repo.AllReadonly<Todo>()
                .Select(e => new TodoModel()
                {
                    id = e.Id,
                    title = e.Title,
                    complete = e.Complete,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> SetNewTodos(IEnumerable<TodoModel> todoListModel)
        {

           var currentTodos = repo.AllReadonly<Todo>();

           repo.DeleteRange(currentTodos);

           await repo.SaveChangesAsync();

            List<string> idList = new List<string>();

            foreach (TodoModel todoModel in todoListModel)
            {
                var todoToEdit = new Todo()
                {
                    Id = todoModel.id,
                    Title = todoModel.title,
                    Complete = todoModel.complete,
                };

                await repo.AddAsync(todoToEdit);
                await repo.SaveChangesAsync();

                idList.Add(todoModel.id);
            }

            return idList;

        }
    }
}
