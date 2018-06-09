using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

/// <summary>
/// Data access layer namespace
/// </summary>
namespace DataAccessLayer
{
    /// <summary>
    /// Data access layer class
    /// </summary>
    public class DAL
    {
        /// <summary>
        /// Connection string
        /// </summary>
        private string cnnStr;

        /// <summary>
        /// List of all DAL products
        /// </summary>
        public List<DALProduct> Products { get; private set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public DAL()
        {
            this.cnnStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            Products = new List<DALProduct>();
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = cnnStr;
                cnn.Open();
                var sqlQuery = "SELECT * from dbo.Prod";
                var command = new SqlCommand(sqlQuery, cnn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var prod = new DALProduct();
                    prod.ID = (int)reader["ID"];
                    prod.Name = (string)reader["Name"];
                    prod.Price = (double)reader["Price"];
                    prod.Group = (string)reader["Group"];
                    Products.Add(prod);
                }
                reader.Close();
            }
        }

        /// <summary>
        /// Getting product by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public DALProduct Get(int ID)
        {
            var prod = new DALProduct();
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = cnnStr;
                cnn.Open();
                var sqlQuery = "SELECT ID, [Name], Price, [Group] from dbo.Prod where ID = @ID";
                var command = new SqlCommand(sqlQuery, cnn);
                command.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    prod.ID = (int)reader["ID"];
                    prod.Name = (string)reader["Name"];
                    prod.Price = (double)reader["Price"];
                    prod.Group = (string)reader["Group"];
                }
                reader.Close();
            }
            return prod;
        }

        /// <summary>
        /// Inserting product
        /// </summary>
        /// <param name="prod"></param>
        public void Insert(DALProduct prod)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = cnnStr;
                cnn.Open();
                var sqlQuery = @"insert into Prod(ID, Name, Price, Group) values (@ID, @Name, @Price, @Group)";
                var command = new SqlCommand(sqlQuery, cnn);
                command.Parameters.AddWithValue("@ID", prod.ID);
                command.Parameters.AddWithValue("@Name", prod.Name);
                command.Parameters.AddWithValue("@Price", prod.Price);
                command.Parameters.AddWithValue("@Group", prod.Group);
                command.ExecuteNonQuery();
                Products.Add(prod);
            }
        }

        /// <summary>
        /// Deleting Product
        /// </summary>
        /// <param name="prod"></param>
        public void Delete(DALProduct prod)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = cnnStr;
                cnn.Open();
                string sqlQuery = @"delete from Prod where ID = @ID";
                var command = new SqlCommand(sqlQuery, cnn);
                command.Parameters.AddWithValue("@ID", prod.ID);
                command.ExecuteNonQuery();
                Products.Remove(prod);
            }
        }

        /// <summary>
        /// Updating product
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newName"></param>
        /// <param name="newPrice"></param>
        /// <param name="newGroup"></param>
        public void Update(int ID, string newName, double newPrice, string newGroup)
        {
            using (var cnn = new SqlConnection())
            {
                cnn.ConnectionString = cnnStr;
                cnn.Open();
                var sqlQuery = @"update Prod set Name=@newName, Price=@newPrice, Group=@newGroup where ID=@ID";
                var command = new SqlCommand(sqlQuery, cnn);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@newName", newName);
                command.Parameters.AddWithValue("@newPrice", newPrice);
                command.Parameters.AddWithValue("@newGroup", newGroup);
                command.ExecuteNonQuery();
            }
        }
    }
}


