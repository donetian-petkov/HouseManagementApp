using PersonalManagementApp.Core.Models.Notes;

namespace PersonalManagementApp.Core.Contracts;

public interface INoteService
{
    Task<IEnumerable<NoteModel>> GetAll();

    Task<String> Add(NoteModel noteModel);
    
    Task<String> Edit(NoteModel noteModel);

    Task<String> Update(NoteModel noteModel);

    Task DeleteById(string noteId);
}