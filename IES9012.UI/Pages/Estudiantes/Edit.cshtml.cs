using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IES9012.CORE.Models;
using IES9012.UI.Data;

namespace IES9012.UI.Pages.Estudiantes
{
    public class EditModel : PageModel
    {
        private readonly IES9012.UI.Data.IES9012Context _context;

        public EditModel(IES9012.UI.Data.IES9012Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Estudiante Estudiante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Estudiante = await _context.Estudiantes.FindAsync(id);
            if (Estudiante == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var estudianteToUpdate = await _context.Estudiantes.FindAsync(id);
            if (estudianteToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Estudiante>(
            estudianteToUpdate,
            "estudiante",
            s => s.Nombre, s => s.Apellido, s => s.FechaInscripcion))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private bool EstudianteExists(int id)
        {
          return (_context.Estudiantes?.Any(e => e.EstudianteId == id)).GetValueOrDefault();
        }
    }
}
