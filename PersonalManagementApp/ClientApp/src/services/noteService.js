import * as request from "./requester";

const noteAPI = 'https://localhost:7156/api/Note';

export const getMyNotes = () => request.get(`${noteAPI}/getAll`,'', {'content-type': 'application/json'});

export const addNotes = (noteTitle, noteContent) => {

  let object = {
    title: noteTitle,
    content: noteContent

  }

  return request.post(`${noteAPI}/add`, object, {});
}

export const editNote = (noteId, data) => {

  let object = {
    id: noteId,
    title: data.title,
    content: data.content

  }

  return request.put(`${noteAPI}/edit`, object, {})
}

export const deleteNote = (id) => request.del(`${noteAPI}/deleteById?noteId=${id}`);

export const updateFavorited = (noteId, bool) => {
    const data = {
        noteId,
        favorited: bool,
    };
    return request.patch(`${noteAPI}/update`, data);
};