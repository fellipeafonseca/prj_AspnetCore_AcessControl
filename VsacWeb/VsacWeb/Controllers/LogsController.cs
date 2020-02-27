using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VsacWeb.Data;
using VsacWeb.Models;

namespace VsacWeb.Controllers
{
    public class LogsController : AuthorizedAction
    {
        private readonly ApplicationDbContext _context;

        public LogsController(ApplicationDbContext context)  : base(context)
        {
            
            _context = context;


        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Logs.Include(l => l.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        //// GET: Logs/Create
        //public IActionResult Create()
        //{
        //    ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id");
        //    return View();
        //}

        //// POST: Logs/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Tabela,Data,Operacao,ValorAntigo,ValorNovo,AppUserId")] Log log)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(log);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", log.AppUserId);
        //    return View(log);
        //}

        // GET: Logs/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var log = await _context.Logs.FindAsync(id);
        //    if (log == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", log.AppUserId);
        //    return View(log);
        //}

        //// POST: Logs/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("Id,Tabela,Data,Operacao,ValorAntigo,ValorNovo,AppUserId")] Log log)
        //{
        //    if (id != log.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(log);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LogExists(log.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", log.AppUserId);
        //    return View(log);
        //}

        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var log = await _context.Logs.FindAsync(id);
            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogExists(long id)
        {
            return _context.Logs.Any(e => e.Id == id);
        }
    }
}
