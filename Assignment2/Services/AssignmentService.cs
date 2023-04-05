using Assignment2.Models;
using Assignment2.Repositories.Interfaces;

namespace Assignment2.Services
{
    public class AssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepo;
        private readonly ILaboratoryRepository _labRepo;
        private readonly IUserRepository _userRepo;

        //ctor with these fields
        public AssignmentService(IAssignmentRepository assignmentRepository, 
                                ILaboratoryRepository laboratoryRepository, 
                                IUserRepository userRepository)
        {
            _assignmentRepo = assignmentRepository;
            _labRepo = laboratoryRepository;
            _userRepo = userRepository;
        }

        public Assignment? CreateAssignment(Assignment assignment)
        {
            if(_assignmentRepo.Add(assignment).Result)
                return assignment;
            else
                return null;
        }

        public IEnumerable<Assignment> GetAssignments()
        {
            return _assignmentRepo.GetAll().Result;
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

        public Assignment? GetAssignmentByLabId(int labId)
        {
            var assignment = _assignmentRepo.GetAll().Result.Where(a => a.LabId == labId).FirstOrDefault();
            return assignment == null ? null : assignment;
        }
    }
}