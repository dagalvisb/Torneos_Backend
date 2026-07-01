using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parcial_backend.Data;
using parcial_backend.Models;

namespace parcial_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PosicionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("tablaPosiciones")]
        public async Task<ActionResult<IEnumerable<TablaPosicion>>> TablaPosiciones()
        {
            var equipos = await _context.Teams.ToListAsync();
            var partidos = await _context.Matches.ToListAsync();

            var tabla = equipos.Select(e =>
            {
                var partidosLocal = partidos.Where(p => p.EquipoLocalId == e.Id);
                var partidosVisitante = partidos.Where(p => p.EquipoVisitanteId == e.Id);

                var todosPartidos = partidosLocal.Concat(partidosVisitante);

                int pj = todosPartidos.Count();
                int pg = todosPartidos.Count(p =>
                    (p.EquipoLocalId == e.Id && p.GolesLocal > p.GolesVisitante) ||
                    (p.EquipoVisitanteId == e.Id && p.GolesVisitante > p.GolesLocal));
                int pp = todosPartidos.Count(p =>
                    (p.EquipoLocalId == e.Id && p.GolesLocal < p.GolesVisitante) ||
                    (p.EquipoVisitanteId == e.Id && p.GolesVisitante < p.GolesLocal));
                int pe = todosPartidos.Count(p =>
                    (p.EquipoLocalId == e.Id || p.EquipoVisitanteId == e.Id) &&
                    p.GolesLocal == p.GolesVisitante);

                int gf = partidosLocal.Sum(p => p.GolesLocal) + partidosVisitante.Sum(p => p.GolesVisitante);
                int gc = partidosLocal.Sum(p => p.GolesVisitante) + partidosVisitante.Sum(p => p.GolesLocal);

                return new TablaPosicion
                {
                    EquipoId = e.Id,
                    EquipoNombre = e.Nombre,
                    PJ = pj,
                    PG = pg,
                    PE = pe,
                    PP = pp,
                    GF = gf,
                    GC = gc,
                    DG = gf - gc,
                    Puntos = pg * 3 + pe * 1
                };
            })
            .OrderByDescending(t => t.Puntos)
            .ThenByDescending(t => t.DG)
            .ThenByDescending(t => t.GF)
            .ToList();

            return Ok(tabla);
        }
    }
}
