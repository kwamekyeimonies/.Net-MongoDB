namespace Student_MS.Database
{
    public interface IStudentStoreDatabaseConfiguration
    {
        string StudentCoursesCollection
        {
            get;
            set;
        }

        string ConnectionString
        {
            get;
            set;
        }

        string DatabaseName
        {
            get;
            set;
        }
    }
}