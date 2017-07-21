using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunJMC.Data.Interfaces;
using RunJMC.Models;
using RunJMC.Models.Tables;

namespace RunJMC.Data.Repositories
{
    public class EntriesRepository : IEntriesRepository
    {
        public IEnumerable<Entry> GetAllEntries()
        {
            List<Entry> results = new List<Entry>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllEntries", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Entry entry = new Entry();

                        entry.EntryId = int.Parse(dr["EntryId"].ToString());
                        entry.Content = dr["Content"].ToString();
                        entry.IsApproved = bool.Parse(dr["IsApproved"].ToString());
                        entry.PublishDate = DateTime.Parse(dr["PublishDate"].ToString());
                        entry.CategoryId = int.Parse(dr["CategoryId"].ToString());
                        entry.UserId = dr["UserId"].ToString();
                        entry.Title = dr["Title"].ToString();
                        entry.IsStatic = bool.Parse(dr["IsStatic"].ToString());

                        results.Add(entry);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public Entry GetEntryById(int id)
        {
            Entry entry = null;
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("GetEntryById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EntryId", id);

                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    // if instead of while?
                    while (dr.Read())
                    {
                        Entry tempEntry = new Entry();

                        tempEntry.EntryId = int.Parse(dr["EntryId"].ToString());
                        tempEntry.Content = dr["Content"].ToString();
                        tempEntry.IsApproved = bool.Parse(dr["IsApproved"].ToString());
                        tempEntry.PublishDate = DateTime.Parse(dr["PublishDate"].ToString());
                        tempEntry.CategoryId = int.Parse(dr["CategoryId"].ToString());
                        tempEntry.UserId = dr["UserId"].ToString();
                        tempEntry.Title = dr["Title"].ToString();
                        tempEntry.IsStatic = bool.Parse(dr["IsStatic"].ToString());

                        entry = tempEntry;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }
            return entry;
        }

        public IEnumerable<Entry> GetEntriesByTag(int id)
        {
            List<Entry> results = new List<Entry>();

            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetEntriesByTag", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TagId", id);
                try
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Entry entry = new Entry();

                        entry.EntryId = int.Parse(dr["EntryId"].ToString());
                        entry.Content = dr["Content"].ToString();
                        entry.IsApproved = bool.Parse(dr["IsApproved"].ToString());
                        entry.PublishDate = DateTime.Parse(dr["PublishDate"].ToString());
                        entry.CategoryId = int.Parse(dr["CategoryId"].ToString());
                        entry.UserId = dr["UserId"].ToString();
                        entry.Title = dr["Title"].ToString();
                        entry.IsStatic = bool.Parse(dr["IsStatic"].ToString());

                        results.Add(entry);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);

                }
            }

            return results;
        }

        public IEnumerable<Entry> GetEntriesByCategory(int id)
        {
            List<Entry> results = new List<Entry>();
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetEntriesByCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CategoryId", id);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Entry entry = new Entry();

                    entry.EntryId = int.Parse(dr["EntryId"].ToString());
                    entry.Content = dr["Content"].ToString();
                    entry.IsApproved = bool.Parse(dr["IsApproved"].ToString());
                    entry.PublishDate = DateTime.Parse(dr["PublishDate"].ToString());
                    entry.CategoryId = int.Parse(dr["CategoryId"].ToString());
                    entry.UserId = dr["UserId"].ToString();
                    entry.Title = dr["Title"].ToString();
                    entry.IsStatic = bool.Parse(dr["IsStatic"].ToString());

                    results.Add(entry);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }

        return results;
        }

        public void AddEntry(Entry entry)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("AddEntry", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Content", entry.Content);
                cmd.Parameters.AddWithValue("@IsApproved", entry.IsApproved);
                cmd.Parameters.AddWithValue("@CategorId", entry.CategoryId);
                cmd.Parameters.AddWithValue("@UserId", entry.UserId);
                cmd.Parameters.AddWithValue("@Title", entry.Title);
                cmd.Parameters.AddWithValue("@IsStatic", entry.IsStatic);
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

        public void UpdateEntry(Entry entry)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateEntry", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Content", entry.Content);
                cmd.Parameters.AddWithValue("@IsApproved", entry.IsApproved);
                cmd.Parameters.AddWithValue("@CategorId", entry.CategoryId);
                cmd.Parameters.AddWithValue("@UserId", entry.UserId);
                cmd.Parameters.AddWithValue("@Title", entry.Title);
                cmd.Parameters.AddWithValue("@IsStatic", entry.IsStatic);


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

        public void DeleteEntry(int id)
        {
            using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
            {


                SqlCommand cmd = new SqlCommand("DeleteEntry", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EntryId", id);
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
