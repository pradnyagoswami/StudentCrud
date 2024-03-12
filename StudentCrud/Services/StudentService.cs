
using StudentCrud.Models;
using StudentCrud.Repository;
using System.Reflection.Metadata;

namespace StudentCrud.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentRepository repo;

        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;
        }

        public int AddStudentRecord(Student student)
        {

            return repo.AddStudentRecord(student);
      
        }

        public int DeleteStudent(int id)
        {
            return repo.DeleteStudent(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return repo.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return repo.GetStudentById(id);
        }

       

        public int UpdateStudent(Student student)
        {
            return repo.UpdateStudent(student);
            
        }
    }
}
