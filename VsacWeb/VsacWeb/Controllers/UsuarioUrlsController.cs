using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public class UsuarioUrlsController : AuthorizedAction
    {

        
        private readonly ApplicationDbContext _context;
        private readonly IActionDescriptorCollectionProvider _provider;

        public UsuarioUrlsController(ApplicationDbContext context, 
            IActionDescriptorCollectionProvider provider) : base(context)
        {
           
            _context = context;
            _provider = provider;


            if (!_context.RaizUrl.Any())
            {
                RaizUrlsController raizUrlsController = new RaizUrlsController(_context, _provider);
               
            }

            if (!_context.Url.Any())
            {
                UrlsController urlsController = new UrlsController(_context, _provider);
               
            }
        }



        private List<UsuarioUrls> GetUrlsUser(string idUser)
        {
            var urlsUser = _context.UsuarioUrls.Where(x => x.AppUserId.Equals(idUser));

            return (urlsUser.ToList());
        }

        // GET: UsuarioUrls
        public async Task<IActionResult> Index()
        {
            //if (!_context.RaizUrl.Any())
            //{
            //    RaizUrlsController raizUrlsController = new RaizUrlsController(_context, _provider);
            //    raizUrlsController.PreencherTabela();
            //}

            //if (!_context.Url.Any())
            //{
            //    UrlsController urlsController = new UrlsController(_context, _provider);
            //    urlsController.PreencherTabela();
            //}


            var applicationDbContext = _context.UsuarioUrls.Include(u => u.Url).Include(u => u.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UsuarioUrls/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioUrls = await _context.UsuarioUrls
                .Include(u => u.Url)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioUrls == null)
            {
                return NotFound();
            }

            return View(usuarioUrls);
        }

        // GET: UsuarioUrls/Create
        public IActionResult Create()
        {
            //ViewData["UrlId"] = new SelectList(_context.Url, "Id", "Caminho");


            var vm = new UsuarioUrlsViewModel()
            {
                Users = new SelectList(_context.Users, "Id", "Nome"),
                Urls = new MultiSelectList(_context.Url, "Id", "Caminho")
            };


            vm.KeyUrls = new Dictionary<string, IEnumerable<SelectListItem>>();

            foreach (var raizUrl in _context.RaizUrl.ToList())
            {
                var fg = _context.Url.Where(
                        x => x.RaizUrl.Nome.Equals(raizUrl.Nome));

                vm.KeyUrls.Add(raizUrl.Nome, 
                    new MultiSelectList(fg, "Id", "Caminho"));
            }

         
          //  ViewData["UrlId"] = new MultiSelectList(_context.Url, "Id", "Caminho");
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Nome");
            return View(vm);
        }

        // POST: UsuarioUrls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind(List<"Id,AppUserId,UrlId")>] List<UsuarioUrls> usuarioUrls)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(usuarioUrls);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //  ViewData["UrlId"] = new SelectList(_context.Url, "Id", "Id", usuarioUrls.UrlId);
        //    //  ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Id", usuarioUrls.AppUserId);
        //    return View(usuarioUrls);
        //}



        // POST: UsuarioUrls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioUrlsViewModel usuarioUrlsViewModel)
        {
            if (ModelState.IsValid)
            {

                foreach (var idUrlSelecionada in usuarioUrlsViewModel.UrlIds)
                {
                    var user = new UsuarioUrls()
                    {
                        AppUserId = usuarioUrlsViewModel.AppUserId,
                        UrlId = idUrlSelecionada
                    };

                    _context.Add(user);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


           // ViewData["UrlId"] = new MultiSelectList(_context.Url, "Id", "Caminho", usuarioUrlsViewModel.Urls);
            ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Nome", usuarioUrlsViewModel.AppUserId);


            return View(usuarioUrlsViewModel);
        }





        // GET: UsuarioUrls/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usuarioUrls = await _context.UsuarioUrls.FindAsync(id);
        //    if (usuarioUrls == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UrlId"] = new SelectList(_context.Url, "Id", "Caminho", usuarioUrls.UrlId);
        //    ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Nome", usuarioUrls.AppUserId);
        //    return View(usuarioUrls);
        //}

        //// POST: UsuarioUrls/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("Id,AppUserId,UrlId")] UsuarioUrls usuarioUrls)
        //{
        //    if (id != usuarioUrls.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(usuarioUrls);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UsuarioUrlsExists(usuarioUrls.Id))
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
        //    ViewData["UrlId"] = new SelectList(_context.Url, "Id", "Caminho", usuarioUrls.UrlId);
        //    ViewData["AppUserId"] = new SelectList(_context.Users, "Id", "Nome", usuarioUrls.AppUserId);
        //    return View(usuarioUrls);
        //}

        // GET: UsuarioUrls/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioUrls = await _context.UsuarioUrls
                .Include(u => u.Url)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarioUrls == null)
            {
                return NotFound();
            }

            return View(usuarioUrls);
        }

        // POST: UsuarioUrls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var usuarioUrls = await _context.UsuarioUrls.FindAsync(id);
            _context.UsuarioUrls.Remove(usuarioUrls);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioUrlsExists(long id)
        {
            return _context.UsuarioUrls.Any(e => e.Id == id);
        }
    }
}
