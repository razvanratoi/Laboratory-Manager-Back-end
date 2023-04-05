using Assignment2.Models;
using Assignment2.Repositories.Interfaces;

namespace Assignment2.Services
{
    public class LaboratoryService
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly ILaboratoryRepository _labRepo;
        private readonly IAssignmentRepository _assignmentRepo;
        private readonly IUserRepository _userRepo;

        public LaboratoryService(ILaboratoryRepository laboratoryRepository, 
                                IAttendanceRepository attendanceRepo, 
                                IAssignmentRepository assignmentRepository,
                                IUserRepository userRepository)
        {
            _labRepo = laboratoryRepository;
            _attendanceRepo = attendanceRepo;
            _assignmentRepo = assignmentRepository;
            _userRepo = userRepository;
        }

        public Laboratory CreateLaboratory(Laboratory laboratory)
        {
            //create a new laboratory in the database
            //and return the newly created laboratory
            if(_labRepo.Add(laboratory).Result)
                return laboratory;
            else
                return null;
        }

        public Laboratory? GetLaboratory(int id)
        {
            var lab = _labRepo.GetById(id).Result;
            return lab == null ? null : lab;
        }

        public Laboratory? UpdateLaboratory(Laboratory laboratory)
        {
            if(_labRepo.Update(laboratory).Result)
                return laboratory;
            else
                return null;
        }

        public Laboratory? DeleteLaboratory(int id)
        {
            var lab = _labRepo.GetById(id).Result;
            if(lab == null)
                return null;
            else
            {
                if(_labRepo.Delete(lab).Result)
                    return lab;
                else
                    return null;
            }
        }

        public List<Laboratory> GetLaboratories()
        {
            return (List<Laboratory>)_labRepo.GetAll().Result;
        }

        //get all attendances based on lab id
        public List<string> GetAttendances(int labId)
        {
            var attendace = (List<Attendance>)_attendanceRepo.GetByLabId(labId).Result;
            var students = new List<string>();
            students.Add("Students present at lab " + labId + ": ");
            for(int i = 0; i < attendace.Count; i++)
            {
                students.Add(_userRepo.GetById(attendace[i].StudentId).Result.Name);
            }
            return students;
        }

        //delete an attendance
        public bool DeleteAttendance(int id)
        {
            var attendance = _attendanceRepo.GetById(id).Result;
            if(attendance == null)
                return false;
            else
                return _attendanceRepo.Delete(attendance).Result;
        }

        public bool InsertAttendance(Attendance attendance)
        {
            return _attendanceRepo.Add(attendance).Result;
        }

        public bool UpdateAttendance(Attendance attendance)
        {
            return _attendanceRepo.Update(attendance).Result;
        }

        //CRUD on assignments
        public Assignment CreateAssignment(Assignment assignment)
        {
            if(_assignmentRepo.Add(assignment).Result)
                return assignment;
            else
                return null;
        }

        public Assignment? GetAssignment(int id)
        {
            var assignment = _assignmentRepo.GetById(id).Result;
            return assignment == null ? null : assignment;
        }

        public Assignment? UpdateAssignment(Assignment assignment)
        {
            if(_assignmentRepo.Update(assignment).Result)
                return assignment;
            else
                return null;
        }

        public Assignment? DeleteAssignment(int id)
        {
            var assignment = _assignmentRepo.GetById(id).Result;
            if(assignment == null)
                return null;
            else
            {
                if(_assignmentRepo.Delete(assignment).Result)
                    return assignment;
                else
                    return null;
            }
        }
        
        public bool CreateAttendance(int labId, int studentId)
        {
            var attendance = new Attendance
            {
                LabId = labId,
                StudentId = studentId
            };
            return _attendanceRepo.Add(attendance).Result;
        }
    }
}