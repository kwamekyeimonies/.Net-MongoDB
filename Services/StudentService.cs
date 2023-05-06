using MongoDB.Driver;
using Student_MS.System.Model;
using Student_MS.Database;

namespace Student_MS.Service
{
    public class StudentServices : IStudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentServices(IStudentStoreDatabaseConfiguration config, IMongoClient mongoClient)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            if (string.IsNullOrEmpty(config.DatabaseName))
            {
                throw new ArgumentException("DatabaseName must be non-empty", nameof(config.DatabaseName));
            }

            if (string.IsNullOrEmpty(config.StudentCoursesCollection))
            {
                throw new ArgumentException("StudentCoursesCollection must be non-empty", nameof(config.StudentCoursesCollection));
            }

            var database = mongoClient.GetDatabase(config.DatabaseName);
            _students = database.GetCollection<Student>(config.StudentCoursesCollection);
        }


        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public List<Student> Get()
        {
            return _students.Find(student => true).ToList();
        }

        public Student Get(string id)
        {
            return _students.Find(student => student.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _students.DeleteOne(student => student.Id == id);
        }

        public void Update(string id, Student student)
        {
            _students.ReplaceOne(student => student.Id == id, student);
        }
    }
}