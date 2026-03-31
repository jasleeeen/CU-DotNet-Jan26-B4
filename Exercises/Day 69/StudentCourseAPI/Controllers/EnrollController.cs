using Microsoft.AspNetCore.Mvc;
using StudentCourseAPI.Data;
using StudentCourseAPI.DTOs;
using StudentCourseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentCourseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(EnrollDTO dto)
        {
            var studentExists = await _context.Students.AnyAsync(s => s.Id == dto.StudentId);
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == dto.CourseId);

            if (!studentExists || !courseExists)
                return BadRequest("Invalid Student or Course");

            var enrollment = new StudentCourse
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };

            _context.StudentCourses.Add(enrollment);
            await _context.SaveChangesAsync();

            return Ok("Enrolled successfully");
        }
    }
}
