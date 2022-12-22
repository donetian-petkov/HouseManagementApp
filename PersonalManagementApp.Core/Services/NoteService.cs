using Microsoft.EntityFrameworkCore;
using PersonalManagementApp.Core.Contracts;
using PersonalManagementApp.Core.Models.Notes;
using PersonalManagementApp.Infrastructure.Data.Common;
using PersonalManagementApp.Infrastructure.Data.Models.Notes;
using Microsoft.EntityFrameworkCore;

namespace PersonalManagementApp.Core.Services;

public class NoteService : INoteService
{
    private readonly IRepository repo;

    public NoteService(IRepository _repo)
    {
        repo = _repo;
    }
    public async Task<IEnumerable<NoteModel>> GetAll()
    {
        return await repo.AllReadonly<Note>()
            .Select(n => new NoteModel()
            {
                id = n.Id,
                title = n.Title,
                content = n.Content,
                favourited = n.Favourited
            })
            .ToListAsync();
    }

    public async Task<string> Add(NoteModel noteModel)
    {
        var noteToCreate = new Note()
        {
            Id = noteModel.id,
            Title = noteModel.title,
            Favourited = noteModel.favourited,
        };

        await repo.AddAsync(noteToCreate);
        await repo.SaveChangesAsync();

        return noteToCreate.Id;
    }

    public async Task<string> Edit(NoteModel noteModel)
    {
        var noteToEdit = await repo.GetByIdAsync<Note>(noteModel.id);

        noteToEdit.Title = noteModel.title;
        
        noteToEdit.Content = noteModel.content;

        noteToEdit.Favourited = noteModel.favourited;

        await repo.SaveChangesAsync();

        return noteToEdit.Id;
    }

    public async Task<string> Update(NoteModel noteModel)
    {
        var noteToEdit = await repo.GetByIdAsync<Note>(noteModel.id);

        noteToEdit.Favourited = noteModel.favourited;
        
        await repo.SaveChangesAsync();

        return noteToEdit.Id;
    }

    public async Task DeleteById(string noteId)
    {
        await repo.DeleteAsync<Note>(noteId);
        await repo.SaveChangesAsync();
    }
}