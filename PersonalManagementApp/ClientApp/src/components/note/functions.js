import axios from "axios";

const customAxios = axios.create({
  baseURL: "https://notes-demo-backend.herokuapp.com",
});


export const getMyNotes = () => {
  return customAxios.get("/me/notes");
};

export const addNotes = (title, content) => {
  const data = {
    title: title,
    content: content,
  };
  return customAxios.post("/notes", data);
};

export const deleteNote = (id) => {
  return customAxios.delete(`/notes/${id}`);
};

export const editNote = (noteId, data) => {
  return customAxios.put(`/notes/${noteId}`, data);
};

export const updateFavorited = (noteId, bool) => {
  const data = {
    favorited: bool,
  };
  return customAxios.put(`/notes/favorite/${noteId}`, data);
};

export const logOut = () => {
  return fetch("https://notes-demo-backend.herokuapp.com/logout", {
    method: "POST",
    mode: "cors",
  });
};
// POST  https://notes-demo-backend.herokuapp.com/notes
// obje olarak title ve content yollanacak
