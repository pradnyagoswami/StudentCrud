using StudentCrud.Models;

namespace StudentCrud.Services
{
    public interface IStudentService
    {
       
        int AddStudentRecord(Student student);

        IEnumerable<Student> GetAllStudents();

        int DeleteStudent(int id);

        Student GetStudentById(int id);

       
        int UpdateStudent(Student student);
    }
}
