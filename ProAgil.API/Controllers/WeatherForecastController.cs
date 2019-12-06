using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            this._context = context;

        }

       

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);

                return Ok(result);
            }
            catch (System.Exception)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados Falhou");
            }

            
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();

                return Ok(results);
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados Falhou");
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento evento) 
        {
            try
            {
                var result = await _context.Eventos.AddAsync(evento);
                await _context.SaveChangesAsync();
                
                return this.StatusCode(StatusCodes.Status201Created,"Sucesso");
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados Falhou");
            }
        }


    }
}
