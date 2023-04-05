using Assignment2.Models;
using Assignment2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        
        private readonly SubmissionService _submissionService;
        private readonly UserService _userService;

        public SubmissionController(SubmissionService submissionService, UserService userService)
        {
            _submissionService = submissionService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateSubmission([FromBody] Submission submission)
        {
            var res = _submissionService.CreateSubmission(submission);
            if(res == null)
                return BadRequest();
            else
                return Ok(res);
        }

        [HttpGet("submissions")]
        public IActionResult GetSubmissions([FromBody] int assignmentId)
        {
            var res = _submissionService.GetSubmissionsForAssignment(assignmentId);
            if(res == null)
                return NotFound();
            else
                return Ok(res);
        }

        [HttpGet("/{studentId}")]
        public IActionResult GetSubmission([FromBody] int assignmentId, [FromRoute] int studentId)
        {
            var res = _submissionService.GetSubmissionForAssignment(assignmentId, studentId);
            if(res == null)
                return NotFound();
            else
                return Ok(res);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubmission([FromRoute] int id)
        {
            var res = _submissionService.GetSubmission(id);
            if(res == null)
                return NotFound();
            else
                return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubmission([FromRoute] int id, [FromBody] Submission submission)
        {
            var res = _submissionService.UpdateSubmission(submission);
            if(res == null)
                return BadRequest();
            else
                return Ok(res);
        }

        [HttpPut("{id}/{userId}")]
        public IActionResult GradeSubmission([FromRoute] int id, [FromRoute] int userId, [FromBody] int grade)
        {
            var user = _userService.GetById(userId);
            if(user == null || user.Role != "Teacher")
                return BadRequest("Teacher only operation!");
            var res = _submissionService.GradeSubmission(id, grade);
            if(res == null)
                return BadRequest();
            else
                return Ok(res);
        }

    }
}