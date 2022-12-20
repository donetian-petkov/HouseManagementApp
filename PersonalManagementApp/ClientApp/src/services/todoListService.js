import * as request from "./requester";

const todoListAPI = 'https://localhost:7156/api/TodoList';

export const getAll = () => request.get(`${todoListAPI}/getAll`,'', {'content-type': 'application/json'});

export const add = (todoToBeCreated) => {

    let object = {
        id: todoToBeCreated.id,
        title: todoToBeCreated.title,
        complete: todoToBeCreated.complete

    }

    return request.post(`${todoListAPI}/add`, object, {});
}

export const edit = (todoToBeEdited) => {

    let object = {
        id: todoToBeEdited.id,
        title: todoToBeEdited.title,
        complete: todoToBeEdited.complete

    }

   return request.put(`${todoListAPI}/edit`, object, {})
}

export const deleteById = (id) => request.del(`${todoListAPI}/deleteById?todoListId=${id}`);

export const setNewTodos = (todos) => {

    let newTodos = [];

    for(let todo in todos) {

        let item = todos[todo];

        newTodos.push({
            id: item.id,
            title: item.title,
            complete: item.complete
        });
    }

    return request.post(`${todoListAPI}/setNewTodos`, newTodos, {});

}