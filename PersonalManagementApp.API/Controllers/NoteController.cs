using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalManagementApp.Core.Contracts;
using PersonalManagementApp.Core.Models.Notes;
using PersonalManagementApp.Core.Models.TodoList;

namespace PersonalManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;

        public NoteController(INoteService _noteService)
        {
            noteService = _noteService;
        }


        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await noteService.GetAll());
        }

        [HttpPost]
        [Route("add")]
        public async Task<String> Add([FromBody] NoteModel noteObject)
        {

            return await noteService.Add(noteObject);
        }
        

        [HttpPut]
        [Route("edit")]
        public async Task<String> Edit([FromBody] NoteModel noteObject)
        {

            return await noteService.Edit(noteObject);
        }

        [HttpPatch]
        [Route("update")]
        public async Task<String> Update([FromBody] NoteModel noteObject)
        {

            return await noteService.Update(noteObject);
        }
       

        [HttpDelete]
        [Route("deleteById")]
        public async Task DeleteById([FromQuery] string noteId)
        {

            await noteService.DeleteById(noteId);
        }
    }
}
