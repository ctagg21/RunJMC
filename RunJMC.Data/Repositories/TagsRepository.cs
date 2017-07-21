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
    public class TagsRepository : ITagsRepository
    {
        public IEnumerable<Tag> GetAllTags()
        {
            List<Tag> results = new List<Tag>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllTags", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Tag tag = new Tag();

                        tag.TagId = int.Parse(dr["TagId"].ToString());
                        tag.TagName = dr["TagName"].ToString();

                        results.Add(tag);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public void AddTag(Tag tag)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("AddTag", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TagName", tag.TagName);
               
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
