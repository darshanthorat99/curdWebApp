using Microsoft.Data.SqlClient;
using System.Xml.Linq;
namespace curdWebApp.Models
{
    public class EmployeeDAL
    {

        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        public EmployeeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("default"));
        }

        public IEnumerable<Employee> GetAllEmployee()
        {

            List<Employee> emplist = new List<Employee>();
            string qry = "select * from Employee";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee e = new Employee();
                    e.Id = Convert.ToInt32(dr["id"]);
                    e.Name = dr["name"].ToString();
                    e.Contact = dr["contact"].ToString();
                    e.Department = dr["department"].ToString();
                    e.Salary = Convert.ToDouble(dr["salary"]);
                    emplist.Add(e);
                }
            }
            con.Close();
            return emplist;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee e = new Employee();
            string qry = "select * from Employee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {


                    e.Name = dr["name"].ToString();
                    e.Contact = dr["contact"].ToString();
                    e.Department = dr["department"].ToString();
                    e.Salary = Convert.ToDouble(dr["salary"]);





                }
            }

            con.Close();
            return e;




        }






        public int AddEmployee(Employee employee)
        {
            string qry = "insert into Employee values(@name,@contact,@department,@salary)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@contact", employee.Contact);
            cmd.Parameters.AddWithValue("@department", employee.Department);
            cmd.Parameters.AddWithValue("@salary",Convert.ToDouble(employee.Salary));
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int UpdateEmployee(Employee employee)
        {
            string qry = "update Employee  set name=@name,contact=@contact,department=@department,salary=@salary where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", employee.Name);
            cmd.Parameters.AddWithValue("@contact", employee.Contact);
            cmd.Parameters.AddWithValue("@department", employee.Department);
            cmd.Parameters.AddWithValue("@salary", employee.Salary);

            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(employee.Id));
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteEmployee(int id)
        {
            string qry = "delete from Employee where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(id));
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;



        }

    }
}
