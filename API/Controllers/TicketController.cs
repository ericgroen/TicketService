using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.DataTransferObjects;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IDataService service;
        private readonly IMapper mapper;

        public TicketController(IDataService service, IMapper mapper)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/ticket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketReadDto>>> GetAllAsync()
        {
            var tickets = await service.GetAllAsync();
            return Ok(mapper.Map<IEnumerable<TicketReadDto>>(tickets));
        }

        // GET: api/ticket/5
        [HttpGet("{id:int}", Name = "GetByIdAsync")]
        public async Task<ActionResult<TicketReadDto>> GetByIdAsync(int id)
        {
            var ticket = await service.GetByIdAsync(id);
            if (ticket != null)
            {
                return Ok(mapper.Map<TicketReadDto>(ticket));
            }
            return Ok(ticket);
        }

        // POST: api/ticket
        [HttpPost]
        public async Task<ActionResult<TicketCreateDto>> CreateAsync(TicketCreateDto ticketCreateDto)
        {
            var ticketModel = mapper.Map<Ticket>(ticketCreateDto);
            service.CreateAsync(ticketModel);
            service.SaveChanges();

            var ticketReadDto = mapper.Map<TicketReadDto>(ticketModel);

            return CreatedAtRoute(nameof(GetByIdAsync), new { ticketReadDto.Id }, ticketReadDto);
        }

        // PUT: api/ticket/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, TicketUpdateDto ticketUpdateDto)
        {
            var ticket = await service.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            var ticketModel = mapper.Map<Ticket>(ticketUpdateDto);
            service.UpdateAsync(ticketModel);
            service.SaveChanges();

            var ticketReadDto = mapper.Map<TicketUpdateDto>(ticketModel);

            return CreatedAtRoute(nameof(GetByIdAsync), new { ticketReadDto.Id }, ticketReadDto);
        }

        // DELETE: api/ticket/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TicketDeleteDto>> DeleteAsync(int id)
        {
            var ticket = await service.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            service.DeleteAsync(ticket);
            service.SaveChanges();

            return Ok(ticket);
        }
    }
}
