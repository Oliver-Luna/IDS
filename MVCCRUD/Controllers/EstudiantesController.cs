using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly MVCCRUDContextEstudiante _context;
        public Estudiante estudiante1 = new Estudiante();
        public EstudiantesController(MVCCRUDContextEstudiante context)
        {
            _context = context;
        }
        // GET: Estudiantes
        public async Task<IActionResult> IndexEstudiante()
        {
            return _context.Estudiantes != null ?
                        View(await _context.Estudiantes.ToListAsync()) :
                        Problem("Entity set 'MVCCRUDContextEstudiante.Estudiantes'  is null.");
        }
        //Get Estudiantes / Details / 5
        public async Task<IActionResult> DetailsEstudiante(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult CreateEstudiante()
        {
            return View();
        }

        // Post : Estudiantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEstudiante([Bind("Id,Carnet,Nombre,Apellido,PrimerParcial,SegundoParcial, Sistematico, NotaFinal")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                estudiante1.Carnet = estudiante.Carnet;
                estudiante1.Nombre = estudiante.Nombre;
                estudiante1.Apellido = estudiante.Apellido;
                estudiante1.PrimerParcial = estudiante.PrimerParcial;
                estudiante1.SegundoParcial = estudiante.SegundoParcial;
                estudiante1.Sistematico = estudiante.Sistematico;
                estudiante1.NotaFinal = estudiante.PrimerParcial+estudiante.SegundoParcial+estudiante.Sistematico;

                _context.Add(estudiante1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexEstudiante));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> EditEstudiante(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            return View(estudiante);
        }

        private bool EstudianteExists(int id)
        {
            return (_context.Estudiantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEstudiante(int id, [Bind("Id,Carnet,Nombre,Apellido,PrimerParcial,SegundoParcial, Sistematico, NotaFinal")] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexEstudiante));
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> DeleteEstudiante(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedEstudiantes(int id)
        {
            if (_context.Estudiantes == null)
            {
                return Problem("Entity set 'MVCCRUDContextEstudiante.Estudiantes'  is null.");
            }
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexEstudiante));
        }

    }
}
