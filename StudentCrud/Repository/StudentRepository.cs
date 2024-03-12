using StudentCrud.Data;
using StudentCrud.Models;

namespace StudentCrud.Repository
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext db;

        public StudentRepository(ApplicationDbContext db) 
        {
            this.db = db;
        
        }


        public int AddStudentRecord(Student student)
        {
            db.Students.Add(student);
            int result = db.SaveChanges();
            return result;

        }

        public int DeleteStudent(int id)
        {
            int res = 0;
            var result = db.Students.Where(x => x.Id == id).FirstOrDefault();

            if(result != null) 
            {

                db.Students.Remove(result);
                res = db.SaveChanges();
            
            
            }
            
            return res;

        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.Students.ToList();

        }

        public Student GetStudentById(int id)
        {

            var result=db.Students.Where(db => db.Id == id).SingleOrDefault();

            return result;
            
        }
        public int UpdateStudent(Student student)
        {
            int res = 0;
            var result = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            if (result != null)
            {

                result.Name = student.Name;
                result.Standard = student.Standard;
                result.FeeRecord = student.FeeRecord;

                res = db.SaveChanges();

            }
            return res;
        }
    }
}
