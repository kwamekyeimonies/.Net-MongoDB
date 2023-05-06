namespace Student_MS.Database
{
    public class StudentStoreDBConfiguration : IStudentStoreDatabaseConfiguration
    {
        public string StudentCoursesCollection { get; set; } = String.Empty;

        public string ConnectionString { get; set; } = String.Empty;

        public string DatabaseName { get; set; } = String.Empty;
    }
}