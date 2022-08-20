using ASPMVCDemo.Models;
using System.Data.SqlClient;

namespace ASPMVCDemo.Services
{
    public class CourseService
    {
        private readonly IConfiguration configuration;

        public CourseService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(configuration.GetConnectionString("SQLConnection"));
        }

        public IEnumerable<CourseModel> GetCourses()
        {
            List<CourseModel> _lst = new List<CourseModel>();
            string _statement = "SELECT CourseID,CourseName,rating from Course";
            SqlConnection _connection = GetConnection();
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    CourseModel _course = new CourseModel()
                    {
                        CourseID = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }

    }
}