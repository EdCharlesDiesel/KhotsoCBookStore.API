using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace StarPeace.Admin.Helpers
{
    public class OrderHistory : IEnumerable<Order>
    {
        // !Need to fix this
       // public SqlDataReader Cursor { get; set; }

        public OrderHistory(bool openImmediately)
        {
            if (openImmediately)
            {
                this.OpenCursor();
            }
        }

        public void OpenCursor()
        {
            SqlConnection cnn = new SqlConnection(AppSettings.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select OrderID,CustomerID,OrderDate,ShippedDate from orders where shippeddate is not null order by orderdate";
            cnn.Open();
            // ! Need to fix this.
         //   this.Cursor = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public IEnumerator<Order> GetEnumerator()
        {
            return new OrderEnumerator(this);
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }
    }

}
