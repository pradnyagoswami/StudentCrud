using StudentCrud.Models;

namespace StudentCrud.Repository
{
    public interface IStudentRepository
    {
        int AddStudentRecord(Student student);

        IEnumerable<Student> GetAllStudents();

        int DeleteStudent(int id);

        Student GetStudentById(int id);

        int UpdateStudent(Student student);


    }
}
