
using eb4395u202117303.API.Assets.Infrastructure.Persistence;
using eb4395u202117303.API.Operations.Application.ACL;
using Microsoft.EntityFrameworkCore;

namespace eb4395u202117303.API.Operations.Infrastructure.ACL
{
    /// <summary>
    /// Facade para operaciones de consulta sobre el contexto de buses (\`AssetsDbContext\`).
    /// Proporciona métodos de solo lectura usados por la capa de aplicación para verificar
    /// existencia y disponibilidad de asientos.
    /// </summary>
    public class BusContextFacade : IBusContextFacade
    {
        private readonly AssetsDbContext _context;

        /// <summary>
        /// Crea una nueva instancia de <see cref="BusContextFacade"/>.
        /// </summary>
        /// <param name="context">Instancia de <see cref="AssetsDbContext"/> usada para las consultas.</param>
        /// <exception cref="ArgumentNullException">Si <paramref name="context"/> es <c>null</c>.</exception>
        public BusContextFacade(AssetsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Determina si existe un bus con el identificador especificado.
        /// </summary>
        /// <param name="busId">Identificador del bus a comprobar.</param>
        /// <returns>Una tarea que registra <c>true</c> si existe al menos un bus con ese id; de lo contrario <c>false</c>.</returns>
        public async Task<bool> ExistsBusAsync(int busId)
        {
            return await _context.Buses.AnyAsync(b => b.Id == busId);
        }

        /// <summary>
        /// Comprueba si hay asientos disponibles en el bus considerando las asignaciones actuales.
        /// </summary>
        /// <param name="busId">Identificador del bus a comprobar.</param>
        /// <param name="currentAssignmentsCount">Número actual de asignaciones para ese bus.</param>
        /// <returns>
        /// Una tarea que registra <c>true</c> si el número de asignaciones actuales es menor que
        /// el total de asientos del bus; <c>false</c> si el bus no existe o no hay asientos disponibles.
        /// </returns>
        public async Task<bool> HasAvailableSeatsAsync(int busId, int currentAssignmentsCount)
        {
            var bus = await _context.Buses.FindAsync(busId);
            if (bus == null) return false;
            return currentAssignmentsCount < bus.TotalSeats;
        }
    }
}
