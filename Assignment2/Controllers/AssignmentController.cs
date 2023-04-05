using Assignment2.Models;
using Assignment2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly LaboratoryService _labService;
        private readonly AssignmentService _assignmentService;

        public AssignmentController(UserService userService, LaboratoryService labService, AssignmentService assignmentService)
        {
            _userService = userService;
            _labService = labService;
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var assignments = _assignmentService.GetAssignments();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id, [FromBody] int assignmentId)
        {
            {
                var assignment = _assignmentService.GetAssignment(assignmentId);
                if (assignment == null)
                    return NotFound();
                else
                    return Ok(assignment);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete([FromRoute] int userId, [FromBody] int assignmentId)
        {
            if (_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
                var assignment = _assignmentService.GetAssignment(assignmentId);
                if (assignment == null)
                    return NotFound();
                else
                {
                    if (_assignmentService.DeleteAssignment(assignmentId) != null)
                        return Ok(assignment);
                    else
                        return BadRequest();
                }
            }
            else return BadRequest("Teacher only operation!");
        }

        [HttpPut("{userId}")]
        public IActionResult Update([FromRoute] int userId, [FromBody] Assignment assignment)
        {
            if (_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
                var lab = _labService.GetLaboratory(assignment.LabId);
                if (lab == null)
                    return NotFound();
                else
                {
                    if (_assignmentService.UpdateAssignment(assignment) != null)
                        return Ok(assignment);
                    else
                        return BadRequest();
                }
            }
            else return BadRequest("Teacher only operation!");
        }
        
        //create assignment
        [HttpPost("{userId}")]
        public IActionResult Create([FromRoute] int userId, [FromBody] Assignment assignment)
        {
            if (_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
                var lab = _labService.GetLaboratory(assignment.LabId);
                if (lab == null)
                    return NotFound();
                else
                {
                    if (_assignmentService.CreateAssignment(assignment) != null)
                        return Ok(assignment);
                    else
                        return BadRequest();
                }
            }
            else return BadRequest("Teacher only operation!");
        }
    }
}