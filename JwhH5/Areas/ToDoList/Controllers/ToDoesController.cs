using System;
using System.Collections.Generic;
using JwhH5.Codes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JwhH5.Areas.ToDoList.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authorization;

namespace JwhH5.Areas.ToDoList.Controllers
{
    [Route("ToDoList/{controller}/{action}")]
    [Authorize("RequireAuthenticatedUser")]
    [Area("ToDoList")]
    public class ToDoesController : Controller
    {
        private readonly ToDoServerContext _context;
        private readonly IDataProtector _dataProtector;
        private readonly CryptExample _cryptExample;

        public ToDoesController(ToDoServerContext context, IDataProtectionProvider dataProtector, CryptExample cryptExample)
        {
            _context = context;
            _dataProtector = dataProtector.CreateProtector("JwhH5.ToDoesController.JwhSuperSecretKey");
            _cryptExample = cryptExample;
        }

     
        // GET: ToDoList/ToDoes
        public async Task<IActionResult> Index()
        {
            var UserNameIdentity = User.Identity.Name;

            var rows = await _context.ToDos.Where(s => s.UserName == UserNameIdentity).ToListAsync();
            bool matchFound = rows.Count > 0;

            if(matchFound)
            {
                foreach(Models.ToDo row in rows)
                {
                    string txtToEncrypt = row.Beskrivelse;
                    row.Beskrivelse = _cryptExample.Decrypt(txtToEncrypt, _dataProtector);
                }
                return View(rows);
            }          

            else
            {
                return View(new List<Models.ToDo>());
            }
        }

        // GET: ToDoList/ToDoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDoList/ToDoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoList/ToDoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Titel,Beskrivelse")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                string beskrivelse = toDo.Beskrivelse;
                toDo.Beskrivelse = _cryptExample.Encrypt(beskrivelse, _dataProtector);

                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDoList/ToDoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(toDo);
        }

        // POST: ToDoList/ToDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Titel,Beskrivelse")] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDoList/ToDoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDoList/ToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
