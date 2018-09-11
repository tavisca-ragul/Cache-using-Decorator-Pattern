using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bookings
{
    class SQLDatabase : IRepository
    {
        SqlConnectionStringBuilder Builder;
        SqlConnection Connection;
        SqlCommand Statement;
        String Query;

        public SQLDatabase()
        {
            Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "TAVDESK136";
            Builder.UserID = "sa";
            Builder.Password = "test123!@#";
            Builder.InitialCatalog = "Products";
            Connection = new SqlConnection(Builder.ConnectionString);
            Query = null;
            Statement = null;
        }

        public List<ProductModel> GetProducts(IProduct product)
        {
            string productType = product.GetTypeOfProduct();
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                Query = string.Format("select * from {0}", productType);
                Statement = new SqlCommand(Query, Connection);
                Statement.CommandType = CommandType.Text;
                Connection.Open();
                SqlDataReader ResultSet = Statement.ExecuteReader();
                while(ResultSet.Read())
                {
                    products.Add(new ProductModel(Convert.ToInt32(ResultSet.GetValue(0)), ResultSet.GetValue(1).ToString(), Convert.ToDouble(ResultSet.GetValue(2))));
                }
                Connection.Close();
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ProductModel>();
            }
        }
    }
}