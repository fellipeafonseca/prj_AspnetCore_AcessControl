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
    public class UrlsController : AuthorizedAction
    {
        private readonly ApplicationDbContext _context;
        private readonly IActionDescriptorCollectionProvider _provider;

        public UrlsController(ApplicationDbContext context, 
            IActionDescriptorCollectionProvider provider) : base(context)
        {
            _context = context;
            _provider = provider;


            if (!_context.RaizUrl.Any())
            {
                RaizUrlsController raizUrlsController = new RaizUrlsController(_context, _provider);
                //  raizUrlsController.PreencherTabela();
            }

            // Procura por Urls
            if (!_context.Url.Any())
            {
                PreencherTabela();
            }

            

        }



        // GET: Urls
        public async Task<IActionResult> Index()
        {

            //// Procura por Urls
            //if (_context.Url.Any() )
            //{
            //    _context.RaizUrl.ToList();
            //    return View(await _context.Url.ToListAsync());   //O BD foi alimentado
            //}

            _context.RaizUrl.ToList();
            return View(await _context.Url.ToListAsync());
        }

        private void PreencherTabela()
        {
            var routes = _provider.ActionDescriptors.Items.Select(x => new
            {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"]
            }).Distinct().ToList();


            foreach (var route in routes)
            {
                if (route.Controller != null && route.Action != null)
                {
                    var url = new Url
                    {
                        RaizUrlId = _context.RaizUrl.Where(x => x.Nome.Equals(route.Controller)).First().Id,
                        Caminho = "/" + route.Controller + "/" + route.Action
                    };
                    _context.Url.Add(url);

                }
            }

            _context.SaveChanges();

        }
        // GET: Urls/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var url = await _context.Url
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (url == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(url);
        //}

        //// GET: Urls/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Urls/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Caminho")] Url url)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(url);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(url);
        //}

        //// GET: Urls/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var url = await _context.Url.FindAsync(id);
        //    if (url == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(url);
        //}

        //// POST: Urls/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("Id,Caminho")] Url url)
        //{
        //    if (id != url.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(url);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UrlExists(url.Id))
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
        //    return View(url);
        //}

        //// GET: Urls/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var url = await _context.Url
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (url == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(url);
        //}

        //// POST: Urls/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var url = await _context.Url.FindAsync(id);
        //    _context.Url.Remove(url);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool UrlExists(long id)
        {
            return _context.Url.Any(e => e.Id == id);
        }
    }
}
