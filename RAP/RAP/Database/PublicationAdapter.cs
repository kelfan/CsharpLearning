using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using RAP.Research;

namespace RAP.Database
{
    class PublicationAdapter
    {
        // by using researcher id, fetch the publication list
        public static List<Publication> fetchBasicPublicationDetails(MySqlConnection conn, Researcher r)
        {
            List<Publication> publications = new List<Publication>();
            
            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select p.doi, p.title, p.authors, p.year, p.cite_as, p.available from publication p, researcher_publication rp WHERE p.doi = rp.doi and rp.researcher_id = ?researcher_id order by year asc ", conn);
                cmd.Parameters.AddWithValue("researcher_id", r.getId());

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    publications.Add(new Publication
                    {
                        DOI = rdr.GetString(0),
                        Title = rdr.GetString(1),
                        Authors = rdr.GetString(2),
                        Year  = rdr.GetInt32(3),
                        CiteAs = rdr.GetString(4),
                        Available = rdr.GetDateTime(5)

                    });
                }
            }
            catch (MySqlException e)
            {
                ERDAdapter.ReportError("loading training sessions", e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return publications;
        }

        // get the publication list
        public static Publication completePublicationDetails(MySqlConnection conn, Publication p)
        {
            return p;
        }

        // count the researcher's publication count
        public static int[] fetchPublicationCounts(MySqlConnection conn, DateTime from, DateTime to)
        {            
            int[] i = { 1, 2 };
            return i;
        }

        // return the year list of the researcher's publication
        public static List<int> fetchPublicationYearList(MySqlConnection conn, Researcher r)
        {
            List<int> yearList = new List<int>();

            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("SELECT distinct year FROM publication p, researcher_publication rp WHERE p.doi = rp.doi and rp.researcher_id = ?researcher_id order by year asc", conn);
                cmd.Parameters.AddWithValue("researcher_id", r.getId());

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    yearList.Add( rdr.GetInt32(0));
                }
            }
            catch (MySqlException e)
            {
                ERDAdapter.ReportError("loading training sessions", e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return yearList;

        }

        // return the publication count
        public static int fetchPublicationCounts(MySqlConnection conn, int id)
        {
            int publicationCount = 0;

            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("SELECT count(p.doi) publicationCount FROM publication p, researcher_publication rp WHERE p.doi = rp.doi and rp.researcher_id = ?researcher_id", conn);
                cmd.Parameters.AddWithValue("researcher_id", id);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    publicationCount = rdr.GetInt32(0);
                }
            }
            catch (MySqlException e)
            {
                ERDAdapter.ReportError("loading training sessions", e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            Researcher r = new Researcher();
            r.setId(id);

            /*
            List<int> i = fetchPublicationYearList(conn, r);
            for(int j=0; j<i.Count; j++)
            { 
                Console.WriteLine("@@@@@@@@@@@@@@@@ + " + i[j]);
            }
            */

            return publicationCount;
            
        }

        // Generate publication count group by year
        public static List<PublicationYearCount> genPublicationYearData(MySqlConnection conn, Researcher r)
        {
            List<PublicationYearCount> pList = new List<PublicationYearCount>();
                   
            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("SELECT count(p.doi) as publicationCount, p.Year FROM publication p, researcher_publication rp WHERE p.doi = rp.doi and rp.researcher_id = ?researcher_id group by p.year order by year", conn);
                cmd.Parameters.AddWithValue("researcher_id", r.getId());

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // generate publication count group by year
                while (rdr.Read())
                {
                    pList.Add( new PublicationYearCount {count = rdr.GetInt32(0) , year = rdr.GetInt32(1)});
                }
            }
            catch (MySqlException e)
            {
                ERDAdapter.ReportError("loading training sessions", e);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return pList;
        }

    }
}
