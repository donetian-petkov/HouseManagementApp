using PersonalManagementApp.Core.Models.Notes;
using PersonalManagementApp.Infrastructure.Data.Models.Notes;

namespace PersonalManagementApp.Core.Contracts;

public interface INoteService
{
    Task<IEnumerable<NoteModel>> GetAll();

    Task<Note> Add(NoteAddModel noteModel);
    
    Task<String> Edit(NoteModel noteModel);

    Task<Note> Update(NoteUpdateModel noteModel);

    Task DeleteById(string noteId);
}