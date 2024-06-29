using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Api_Post.Data;
using Api_Post.Models;

namespace Api_Post.Controllers
{
    public class PublicacionesController : Controller
    {
        private readonly MyDbContext _context;

        public PublicacionesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Publicaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Publicaciones.ToListAsync());
        }

        // GET: Publicaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.Publicaciones
                .FirstOrDefaultAsync(m => m.idPost == id);
            if (publicaciones == null)
            {
                return NotFound();
            }

            return View(publicaciones);
        }

        // GET: Publicaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publicaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPost,nombrePost,descripcion,idDeUsuario")] Publicaciones publicaciones)
        {
            if (ModelState.IsValid)
            {
                // Aquí estableces manualmente idDeUsuario a 1
                publicaciones.idDeUsuario = 1;

                _context.Add(publicaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicaciones);
        }

        // GET: Publicaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.Publicaciones.FindAsync(id);
            if (publicaciones == null)
            {
                return NotFound();
            }
            return View(publicaciones);
        }

        // POST: Publicaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPost,nombrePost,descripcion,idDeUsuario")] Publicaciones publicaciones)
        {
            if (id != publicaciones.idPost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    publicaciones.idDeUsuario = 1;
                    _context.Update(publicaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicacionesExists(publicaciones.idPost))
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
            return View(publicaciones);
        }

        // GET: Publicaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publicaciones = await _context.Publicaciones
                .FirstOrDefaultAsync(m => m.idPost == id);
            if (publicaciones == null)
            {
                return NotFound();
            }

            return View(publicaciones);
        }

        // POST: Publicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publicaciones = await _context.Publicaciones.FindAsync(id);
            _context.Publicaciones.Remove(publicaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicacionesExists(int id)
        {
            return _context.Publicaciones.Any(e => e.idPost == id);
        }
    }
}
