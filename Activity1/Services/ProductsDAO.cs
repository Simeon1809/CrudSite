using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Activity1.Models;

namespace Activity1.Services
{
    public class ProductsDAO 
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-MyDemoApp-6C303BCB-95A5-4792-88AF-AB73041EB362;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       
        public bool Delete(ProductModel product)
        {
            int newIdNumber = -1;

            string sqlStatement = "DELETE FROM dbo.Products WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                
                command.Parameters.AddWithValue(@"Id", product.Id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                { 
                    Console.WriteLine(ex.Message);
                }

            }
            return (newIdNumber > 0);
        }

        public List<ProductModel> AllProducts()
        {

            List<ProductModel> foundProducts = new List<ProductModel>();

            string sqlStatement = "SELECT * FROM dbo.Products";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel 
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundProducts;
        }

        public ProductModel GetProductById(int id)
        { 
            ProductModel foundProduct = null;

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Id = @Id ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id",id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProduct = new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundProduct;
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            List<ProductModel> foundProducts = new List<ProductModel>();

            string sqlStatement = "SELECT * FROM dbo.Products WHERE Name LIKE @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue(@"Name", "%" + searchTerm + "%");

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundProducts.Add(new ProductModel
                        {
                            Id = (int)reader[0],
                            Name = (string)reader[1],
                            Price = (decimal)reader[2],
                            Description = (string)reader[3]
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundProducts;
        }

        public int Update(ProductModel product)
        {
           int newIdNumber = -1;

            string sqlStatement = "Update dbo.Products SET Name = @Name,Price = @Price, Description = @Description WHERE Id =@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue(@"Name", product.Name);
                command.Parameters.AddWithValue(@"Price", product.Price);
                command.Parameters.AddWithValue(@"Description", product.Description);
                command.Parameters.AddWithValue(@"Id", product.Id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32 (command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return newIdNumber;
        }

        public int Insert(ProductModel productModel)
        {
            int newId = -1 ;

            string sqlStatement = "INSERT INTO dbo.Products (Name,Price, Description) VALUES (@Name, @Price, @Description)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Name", productModel.Name);
                command.Parameters.AddWithValue("@Price", productModel.Price);
                command.Parameters.AddWithValue("@Description", productModel.Description);
             
                try
                {
                    connection.Open();
                    newId = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return newId;
        }
    }     
}
     
