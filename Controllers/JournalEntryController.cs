using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using daily.Models;
using System.Collections;

namespace daily.Controllers
{
    [Route("/api/JournalEntry")]
    [ApiController]
    public class JournalEntryController : ControllerBase
    {
        private readonly DailyContext _context;

        public JournalEntryController(DailyContext context)
        {
            _context = context;
        }

        // GET: api/JournalEntry
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalEntry>>> GetJournalEntries()
        {
            return await _context.JournalEntries.ToListAsync();
        }

        // GET: api/JournalEntry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JournalEntry>> GetJournalEntry(long id)
        {
            var journalEntry = await _context.JournalEntries.FindAsync(id);

            if (journalEntry == null)
            {
                return NotFound();
            }

            return journalEntry;
        }

        
        // GET: api/JournalEntry/User/1
        [HttpGet("/api/JournalEntry/User/{userId}")]
        public async Task<ActionResult<IEnumerable<JournalEntry>>> GetEntriesForUser(long userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) {
                return NotFound();
            }
            Console.WriteLine(user);
            return user.JournalEntries.ToList();
        
        }

        // PUT: api/JournalEntry/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJournalEntry(long id, JournalEntry journalEntry)
        {
            if (id != journalEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(journalEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JournalEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/JournalEntry
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JournalEntry>> PostJournalEntry(JournalEntry journalEntry)
        {
            _context.JournalEntries.Add(journalEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJournalEntry), new { id = journalEntry.Id }, journalEntry);
        }

        // DELETE: api/JournalEntry/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJournalEntry(long id)
        {
            var journalEntry = await _context.JournalEntries.FindAsync(id);
            if (journalEntry == null)
            {
                return NotFound();
            }

            _context.JournalEntries.Remove(journalEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JournalEntryExists(long id)
        {
            return _context.JournalEntries.Any(e => e.Id == id);
        }
    }
}
