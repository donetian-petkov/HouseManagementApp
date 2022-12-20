using PersonalManagementApp.Core.Models.TodoList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalManagementApp.Core.Contracts
{
    public interface ITodoListService
    {
        Task<IEnumerable<TodoModel>> GetAll();

        Task<String> Add(TodoModel todoListModel);

        Task<IEnumerable<String>> SetNewTodos(IEnumerable<TodoModel> todosModels);

        Task<String> Edit(TodoModel todoListModel);

        Task DeleteById(string todoId);
    }
}
