using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseRegistrationAPI.Data;
using StudentCourseRegistrationAPI.Models;

namespace StudentCourseRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{roll}")]
        public async Task<ActionResult<Student>> GetStudent(int roll)
        {
            var student = await _context.Students.FindAsync(roll);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // GET: api/Students/login/{roll}
        [HttpGet("login/{roll}")]
        public async Task<IActionResult> LoginByRoll(int roll)
        {
            var student = await _context.Students.FindAsync(roll);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // PUT: api/Students/5
        [HttpPut("{roll}")]
        public async Task<IActionResult> PutStudent(int roll, Student student)
        {
            if (roll != student.Roll)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(roll))
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

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { roll = student.Roll }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{roll}")]
        public async Task<IActionResult> DeleteStudent(int roll)
        {
            var student = await _context.Students.FindAsync(roll);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int roll)
        {
            return _context.Students.Any(e => e.Roll == roll);
        }
    }
}
