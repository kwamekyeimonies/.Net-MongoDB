using Microsoft.AspNetCore.Mvc;
using Student_MS.Service;
using Student_MS.System.Model;

namespace Student_MS.Controller
{
    [ApiController]
    [Route("api/students")]

    public class StudentServiceController : ControllerBase
    {
        private readonly IStudentService? studentService;

        public StudentServiceController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return studentService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = studentService.Get(id);

            if (student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            return student;
        }

        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            studentService.Create(student);

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("id")]
        public ActionResult Put(string id, [FromBody] Student student)
        {
            var existingStudent = studentService.Get(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            studentService.Update(id, student);

            return NoContent();
        }

        [HttpDelete("id")]
        public ActionResult Delete(string id)
        {
            var student = studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            studentService.Remove(student.Id);

            return Ok($"Student with ID = {id} Deleted Succcessfully");
        }
    }
}