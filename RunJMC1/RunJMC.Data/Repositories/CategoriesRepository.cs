using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunJMC.Data.Interfaces;
using RunJMC.Models.Tables;

namespace RunJMC.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        public IEnumerable<Category> GetAllCategories()
        {
            List<Category> results = new List<Category>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllCategories", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Category category = new Category();

                        category.CategoryId = int.Parse(dr["CategoryId"].ToString());
                        category.CategoryName = dr["CategoryName"].ToString();

                        results.Add(category);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public void AddCategory(Category category)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("AddCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }

            }
        }
    }
}
