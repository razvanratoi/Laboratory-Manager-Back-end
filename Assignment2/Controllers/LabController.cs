using Assignment2.Models;
using Assignment2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabController : ControllerBase
    {
        private readonly LaboratoryService _labService;
        private readonly UserService _userService;
        public LabController(LaboratoryService labService, UserService userService)
        {
            _labService = labService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var labs = _labService.GetLaboratories();
            return Ok(labs);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id, [FromBody] int labId)
        {
            {
                var lab = _labService.GetLaboratory(labId);
                if (lab == null)
                    return NotFound();
                else
                    return Ok(lab);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete([FromRoute] int userId, [FromBody] int labId)
        {
            if (_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
                var lab = _labService.GetLaboratory(labId);
                if (lab == null)
                    return NotFound();
                else
                {
                    if (_labService.DeleteLaboratory(labId) != null)
                        return Ok(lab);
                    else
                        return BadRequest();
                }
            }
            else return BadRequest("Teacher only operation!");
        }

        [HttpPut("{userId}")]
        public IActionResult Update([FromRoute] int userId, [FromBody] Laboratory lab)
        {
            if (_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
                if (_labService.UpdateLaboratory(lab) != null)
                    return Ok(lab);
                else
                    return BadRequest();

            }
            else return BadRequest("Teacher only operation!");
        }

        [HttpPost("{userId}")]
        public IActionResult Create([FromRoute] int userId, [FromBody] Laboratory lab)
        {
            if (_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
                var lab1 = _labService.GetLaboratory(lab.Id);
                if (lab1 != null)
                    return BadRequest();
                else
                {
                    if (_labService.CreateLaboratory(lab) != null)
                        return Ok(lab);
                    else
                        return BadRequest();
                }
            }
            else return BadRequest("Teacher only operation!");
        }

        //get attendace by lab id only if user is teacher
        [HttpGet("attendance/{userId}")]
        public IActionResult GetAttendance([FromRoute] int userId, [FromBody] int labId)
        {
            if (_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
                var lab = _labService.GetLaboratory(labId);
                if (lab == null)
                    return NotFound("Lab not found");
                else
                {
                    var attendance = _labService.GetAttendances(labId);
                    return Ok(attendance);
                }
            }
            else return BadRequest("Teacher only operation!");
        }

        [HttpPost("attendance/{userId}")]
        public IActionResult CreateAttendance([FromRoute] int userId, [FromBody] Attendance attendance)
        {
            if (_userService.GetById(userId) != null && _userService.GetById(userId).Role == "Teacher")
            {
                var lab = _labService.GetLaboratory(attendance.LabId);
                if (lab == null)
                    return NotFound("Lab not found");
                else
                {
                    if (_labService.CreateAttendance(attendance.LabId, attendance.StudentId) != null)
                        return Ok(attendance);
                    else
                        return BadRequest();

                }
            }
            else return BadRequest("Teacher only operation!");
        }
    }
}