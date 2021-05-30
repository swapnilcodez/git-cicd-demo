using DraftNotes.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DraftNotes.Web.Controllers
{
    public class DraftNotesController : Controller
    {
        private readonly ILogger<DraftNotesController> _logger;
        private readonly DraftNotesDbContext _context;
        public DraftNotesController(ILogger<DraftNotesController> logger, DraftNotesDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Create()
        {
            var notes = _context.Notes.ToList();
            if (notes == null)
            {
                notes = new List<Note>();
            }
            return View(notes);
        }

        [HttpPost]
        public IActionResult Save(Note note)
        {
            try
            {
              
                    var newId = _context.Notes.Select(x => x.Id).Max() + 1;
                    note.Id = newId;

                    _context.Notes.Add(note);
                    _context.SaveChanges();

                return RedirectToAction("Create");
            }
            catch (Exception)
            {

                throw;
            }           
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var note = _context.Notes.Where(x => x.Id == id).FirstOrDefault();

            return View(note);
        }

        [HttpPost]
        public IActionResult Edit(Note note)
        {
            try
            {

                var updateNote = _context.Notes.Where(x => x.Id == note.Id).FirstOrDefault();

                _context.Update(note);
                _context.SaveChanges();

                return RedirectToAction("Create");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Delete(int id)
        {
            var notes = _context.Notes.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(notes);
            _context.SaveChanges();

            return RedirectToAction("Create");
        }

        [Route("About")]
        public IActionResult About()
        {
            return View();
        }
    }
}
