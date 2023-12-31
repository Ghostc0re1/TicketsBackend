﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using TicketsBackend.DTOs;
using TicketsBackend.Models;
using static TicketsBackend.Startup;

namespace TicketsBackend.Controllers
{
    [Route("api/[controller]")] // /api/Tickets
    [ApiController]
    [Authorize]
    public class TicketsController : ControllerBase
    {
        private readonly TestDbContext context;

        public TicketsController(TestDbContext context)
        {
            this.context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Tickets/id
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Tickets
        [HttpPost]
        public async Task<ActionResult<TicketsDto>> Post([FromBody] TicketsDto ticketsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ticket = new Ticket
            {
                // Map properties from TicketsDto to Ticket
                Subject = ticketsDto.Subject,
                Description = ticketsDto.Description,
                Priority = ticketsDto.Priority,
                Status = ticketsDto.Status,
                DepartmentId = ticketsDto.DepartmentId, // Ensure this matches the DTO
            };

            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticketsDto);
        }

        // PUT api/Tickets/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Tickets/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
