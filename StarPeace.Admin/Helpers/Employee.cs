using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace StarPeace.Admin.Helpers
{
    public class Employee
    {
        private List<Order> orders = null;

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        public Employee(int id)
        {
            this.EmployeeID = id;

            SqlConnection cnn = new SqlConnection(AppSettings.ConnectionString);
            SqlCommand cmd = new SqlCommand("select employeeid,firstname,lastname,title from employees where employeeid=@id", cnn);
            cmd.Parameters.Add(new SqlParameter("@id",id));
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                this.FirstName = reader.GetString(1);
                this.LastName = reader.GetString(2);
                this.Title = reader.GetString(3);
            }
            cnn.Close();
        }

        public List<Order> Orders
        {
            get
            {
                if(this.orders==null)
                {
                    SqlConnection cnn = new SqlConnection(AppSettings.ConnectionString);
                    SqlCommand cmd = new SqlCommand("select orderid,orderdate from orders where employeeid=@id", cnn);
                    cmd.Parameters.Add(new SqlParameter("@id", this.EmployeeID));
                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        this.orders = new List<Order>();
                    }
                    while(reader.Read())
                    {
                        Order order = new Order()
                        {
                            OrderID = reader.GetInt32(0),
                            OrderDate = reader.GetDateTime(1)
                        };
                        this.orders.Add(order);
                    }
                    cnn.Close();
                }
                return this.orders;
            }
        }
        
    }
}
