using Microsoft.AspNetCore.Mvc;
using StudentCrudApi.Students.Model;
using StudentCrudApi.Students.Repository.interfaces;

namespace StudentCrudApi.Students.Controller
{
    [ApiController]
    [Route("student/api/v1")]
    public class StudentController:ControllerBase
    {

        private readonly ILogger _logger;
        private IStudentRepository _studentRepository;

        public StudentController(ILogger<StudentController>logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            var students=await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Student>>>GetById(int id)
        {
            var students=await _studentRepository.GetByIdAsync(id);
            return Ok(students);
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Student>>>GetByName(string name)
        {
            var students=await _studentRepository.GetByNameAsync(name);
            return Ok(students);
        }

    }
}
