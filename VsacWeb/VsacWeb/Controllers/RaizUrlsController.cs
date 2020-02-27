using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VsacWeb.Data;
using VsacWeb.Models;

namespace VsacWeb.Controllers
{
    [Authorize]
    public class RaizUrlsController : AuthorizedAction
    {
        private readonly ApplicationDbContext _context;
        private readonly IActionDescriptorCollectionProvider _provider;

        public RaizUrlsController(ApplicationDbContext context,
            IActionDescriptorCollectionProvider provider) : base(context)
        {
            _context = context;
            _provider = provider;

            if (!_context.RaizUrl.Any())
            {
                PreencherTabela();
            }
        }

        private void PreencherTabela()
        {
            var actions = _provider.ActionDescriptors.Items.Select(x => new
            {
                Action = x.RouteValues["Controller"]
            }).Distinct().ToList();


            foreach (var action in actions)
            {
                if (action.Action!=null)
                {
                    var raizUrl = new RaizUrl
                    {
                        Nome = action.Action
                    };
                    _context.RaizUrl.Add(raizUrl);
                }
            }

            _context.SaveChanges();
        }

        // GET: RaizUrls
        public async Task<IActionResult> Index()
        {
            //if (_context.RaizUrl.Any())
            //{
            //    return View(await _context.RaizUrl.ToListAsync());

            //}

            return View(await _context.RaizUrl.ToListAsync());

        }

        // GET: RaizUrls/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raizUrl = await _context.RaizUrl
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raizUrl == null)
            {
                return NotFound();
            }

            return View(raizUrl);
        }

        //// GET: RaizUrls/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: RaizUrls/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Nome")] RaizUrl raizUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(raizUrl);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(raizUrl);
        //}

        //// GET: RaizUrls/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var raizUrl = await _context.RaizUrl.FindAsync(id);
        //    if (raizUrl == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(raizUrl);
        //}

        //// POST: RaizUrls/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("Id,Nome")] RaizUrl raizUrl)
        //{
        //    if (id != raizUrl.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(raizUrl);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RaizUrlExists(raizUrl.Id))
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
        //    return View(raizUrl);
        //}

        //// GET: RaizUrls/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var raizUrl = await _context.RaizUrl
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (raizUrl == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(raizUrl);
        //}

        //// POST: RaizUrls/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var raizUrl = await _context.RaizUrl.FindAsync(id);
        //    _context.RaizUrl.Remove(raizUrl);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool RaizUrlExists(long id)
        {
            return _context.RaizUrl.Any(e => e.Id == id);
        }
    }
}
