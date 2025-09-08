using System.Data;
using ClickMart.API.DAO;
using ClickMart.API.DTO;
using Microsoft.Data.SqlClient;
using ClickMart.API.Models;

namespace ClickMart.API.DAO
{
    public class ProductDAO
    {
        public int InsertProduct(ProductDTO product)
        {
            using var conn = DbConnectionFactory.GetConnection();
            using var cmd = new SqlCommand("InsertProduct", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Identifier", product.Identifier);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@PublishDate", product.PublishDate);
            cmd.Parameters.AddWithValue("@Image", product.Image);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public List<ProductDTO> GetAllProducts()
        {
            var list = new List<ProductDTO>();

            using var conn = DbConnectionFactory.GetConnection();
            using var cmd = new SqlCommand("GetAllProducts", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new ProductDTO
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Identifier = reader.GetString(reader.GetOrdinal("Identifier")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Category = reader.IsDBNull(reader.GetOrdinal("Category"))
                        ? (int?)null
                        : reader.GetInt32(reader.GetOrdinal("Category")),
                    PublishDate = reader.GetDateTime(reader.GetOrdinal("PublishDate")),
                    Image = reader.GetString(reader.GetOrdinal("Image")),
                    CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                    UpdateDate = reader.GetDateTime(reader.GetOrdinal("UpdateDate")),
                    DeletionDate = reader.IsDBNull(reader.GetOrdinal("DeletionDate"))
                        ? null
                        : reader.GetDateTime(reader.GetOrdinal("DeletionDate"))
                });
            }

            return list;
        }

        public int UpdateProduct(ProductDTO productDTO)
        {
            using var conn = DbConnectionFactory.GetConnection();
            using var cmd = new SqlCommand("UpdateProduct", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", productDTO.Id);
            cmd.Parameters.AddWithValue("@Identifier", productDTO.Identifier);
            cmd.Parameters.AddWithValue("@Name", productDTO.Name);
            cmd.Parameters.AddWithValue("@Price", productDTO.Price);
            cmd.Parameters.AddWithValue("@Description", productDTO.Description);
            cmd.Parameters.AddWithValue("@Category", productDTO.Category);
            cmd.Parameters.AddWithValue("@Image", productDTO.Image);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int DeleteProduct(int id)
        {
            using var conn = DbConnectionFactory.GetConnection();
            using var cmd = new SqlCommand("DeleteProduct", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Id", id);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int DeleteProductByIdentifier(string identifier)
        {
            using var conn = DbConnectionFactory.GetConnection();
            using var cmd = new SqlCommand("DeleteProductByIdentifier", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@Identifier", identifier);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public Product? GetProductByIdentifier(string identifier)
        {
            Product? product = null;
            using var conn = DbConnectionFactory.GetConnection();
            using (SqlCommand cmd = new SqlCommand("GetProductByIdentifier", (SqlConnection)conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Identifier", identifier);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product
                        {
                            Identifier = reader.GetString(reader.GetOrdinal("Identifier")),
                        };
                    }
                }
            }
            return product;
        }

    }
}
