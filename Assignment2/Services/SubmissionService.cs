using Assignment2.Models;
using Assignment2.Repositories.Interfaces;

namespace Assignment2.Services
{
    public class SubmissionService
    {
        private readonly IUserRepository _userRepo;
        private readonly ISubmissionRepository _submissionRepo;

        public SubmissionService(IUserRepository userRepository, ISubmissionRepository submissionRepository)
        {
            _userRepo = userRepository;
            _submissionRepo = submissionRepository;
        }

        public Submission? CreateSubmission(Submission submission)
        {
            if(_submissionRepo.Add(submission).Result)
                return submission;
            else
                return null;
        }

        public Submission? GetSubmission(int id)
        {
            var submission = _submissionRepo.GetById(id).Result;
            return submission == null ? null : submission;
        }

        public Submission? UpdateSubmission(Submission submission)
        {
            if(_submissionRepo.Update(submission).Result)
                return submission;
            else
                return null;
        }

        public Submission? DeleteSubmission(int id)
        {
            var submission = _submissionRepo.GetById(id).Result;
            if(submission == null)
                return null;
            else
            {
                if(_submissionRepo.Delete(submission).Result)
                    return submission;
                else
                    return null;
            }
        }

        //grade a submission
        public Submission? GradeSubmission(int id, int grade)
        {
            var submission = _submissionRepo.GetById(id).Result;
            if(submission == null)
                return null;
            else
            {
                submission.Grade = grade;
                if(_submissionRepo.Update(submission).Result)
                    return submission;
                else
                    return null;
            }
        }

        public IEnumerable<Submission> GetSubmissionsForAssignment(int assignmentId)
        {
            return _submissionRepo.GetAll().Result.Where(s => s.AssignmentId == assignmentId);
        }


        //get submission by assignment and student ids
        public Submission? GetSubmissionForAssignment(int assignmentId, int studentId)
        {
            return _submissionRepo.GetAll().Result.FirstOrDefault(s => s.AssignmentId == assignmentId && s.StudentId == studentId);
        }
    }
}