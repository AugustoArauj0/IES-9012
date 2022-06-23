using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IES9012.CORE.Models;
using IES9012.UI.Data;

namespace IES9012.UI.Pages.Estudiantes
{
    public class DetailsModel : PageModel
    {
        private readonly IES9012.UI.Data.IES9012Context _context;

        public DetailsModel(IES9012.UI.Data.IES9012Context context)
        {
            _context = context;
        }

      public Estudiante Estudiante { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Estudiantes == null)
            {
                return NotFound();
            }

            Estudiante = await _context.Estudiantes
            .Include(s => s.Inscripciones)
            .ThenInclude(e => e.Materias)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.EstudianteId == id);

            if (Estudiante == null)
            {
                return NotFound();
            }
            else 
            {
                Estudiante = Estudiante;
            }
            return Page();
        }
    }
}
