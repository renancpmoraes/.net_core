using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Repository.Data;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        public ProAgilContext _proAgilContext { get; }
        public ProAgilRepository(ProAgilContext proAgilContext)
        {
            this._proAgilContext = proAgilContext;

            // ver esse negocio de NoTracking
            _proAgilContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

        }


        // Gerais
        public void Add<T>(T entity) where T : class
        {
            _proAgilContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _proAgilContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
           _proAgilContext.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _proAgilContext.SaveChangesAsync()) > 0;
        }

        // Eventos

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _proAgilContext.Eventos.Include(c => c.Lotes).Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();

        }
        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _proAgilContext.Eventos.Include(c => c.Lotes).Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento).Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventoAsyncById(int eventoId, bool includePalestrantes) 
        {
            IQueryable<Evento> query = _proAgilContext.Eventos.Include(c => c.Lotes).Include(c => c.RedesSociais);

            if(includePalestrantes)
            {
                query = query.Include(p => p.PalestrantesEventos).ThenInclude(p => p.Palestrante);
            }

            query = query.OrderByDescending(c => c.DataEvento).Where(c => c.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        

        // Palestrante

        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string nome, bool includeEventos = false)
        {
           IQueryable<Palestrante> query = _proAgilContext.Palestrantes.Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);
            }

            query = query.Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos)
        {
          IQueryable<Palestrante> query = _proAgilContext.Palestrantes.Include(c => c.RedesSociais);

            if(includeEventos)
            {
                query = query.Include(pe => pe.PalestrantesEventos).ThenInclude(e => e.Evento);
            }

            query = query.OrderBy(c => c.Nome).Where(p => p.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

        
    }
}