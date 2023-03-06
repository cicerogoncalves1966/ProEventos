using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private IEnumerable<Evento> _eventos = new Evento[] {
            new Evento() {
                EventoId = 1,
                Local = "Suzano",
                DataEvento = "18/03/2023",
                Tema = "Casamento da Fê",
                Lote = "L1",
                QtdPessoas = 100,
                ImagemURL = "xyz"
            },
            new Evento() {
                EventoId = 2,
                Local = "Guarulhos",
                DataEvento = "24/03/2023",
                Tema = "Acampadentro",
                Lote = "L1",
                QtdPessoas = 20,
                ImagemURL = "foto2"
            },
        };

        private readonly ILogger<EventoController> _logger;

        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _eventos;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _eventos.Where(evento => evento.EventoId == id);
        }
        [HttpPost]
        public string Post()
        {
            return "Post - Hello world";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Put - Hello world com id = {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Delete - Hello world com id = {id}";
        }
    }
}
