using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using RAP.Research;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace RAP.Database
{
    class ResearcherAdapter
    {
        // return all the researchers, part properties are available,just for the researcher list
        public static List<Researcher> fetchBasicResearcherDetails(MySqlConnection conn)
        {
            List<Researcher> researchers = new List<Researcher>();
            
            MySqlDataReader rdr = null;            

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select family_name,given_name,title,id,IFNULL(level, 'Student') as level,type from researcher", conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                   Researcher r = new Researcher
                    {
                        FamilyName = rdr.GetString(0),
                        GivenName = rdr.GetString(1),
                        Title = rdr.GetString(2),                        
                        Level = rdr.GetValue(4).ToString(),
                        Type = rdr.GetString(5)
                    };
                   r.setId(rdr.GetInt32(3));                  
                        
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                   researchers.Add(r);
                }

                return researchers;
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
            return researchers;

        }


        // by using the researcher id, get the researcher details
        public static Researcher fetchFullResearcherDetails(MySqlConnection conn, int id)
        {
            Researcher researcher = new Researcher();
            Student rStudent = new Student();
            Staff rStaff = new Staff();
            
            String type = "";
            
            MySqlDataReader rdr = null;
            //MySqlDataReader rdr2 = null;

            try
            {
                conn.Open();
                
                // This part will generate the supersision count of the researcher
                MySqlCommand cmd2 = new MySqlCommand("select count(*) as supervisioncount " +
                                                    "from researcher " +
                                                    "where supervisor_id=?supervisor_id", conn);

                cmd2.Parameters.AddWithValue("supervisor_id", id);
                rdr = cmd2.ExecuteReader();
                while (rdr.Read())
                {
                    researcher.Supervisions = rdr.GetInt32(0);
                }
                rdr.Close();
                

                // This part will generate the researcher detailed information
                MySqlCommand cmd = new MySqlCommand("select given_name, family_name, title, unit, campus, email, photo,level, current_start, utas_start, " +
                                                    "timestampdiff(day, DATE_FORMAT(utas_start,'%Y-%m-%d'),DATE_FORMAT(SYSDATE(), '%Y-%m-%d')) as days, " +
                                                    "type, IFNULL(degree, '') " +
                                                    "from researcher " +
                                                    "where id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    researcher.GivenName = rdr.GetString(0);
                    researcher.FamilyName = rdr.GetString(1);
                    researcher.Title = rdr.GetString(2);
                    researcher.Unit = rdr.GetString(3);
                    researcher.Campus = rdr.GetString(4);
                    researcher.Email = rdr.GetString(5);
                    researcher.Photo = rdr.GetString(6);

                    //Check whether 'Level' is null
                    if (!rdr.IsDBNull(7))
                    {
                        researcher.Level = rdr.GetString(7);
                    }
                    else
                    {
                        researcher.Level = "";
                    }

                    researcher.CurrentJobStart = rdr.GetDateTime(8);
                    researcher.EarliestStart = rdr.GetDateTime(9);
                    
                    float years = (float) rdr.GetInt32(10)/365;
                    int dayInt = (int)(years * 100);
                    years = (float)dayInt / 100;

                    researcher.Tenure = years;

                    
                    
                    type = rdr.GetString(11);

                    // if the researche type equals 'Student', generate student object
                    if (type == "Student")
                    {
                        rStudent.GivenName = researcher.GivenName;
                        rStudent.FamilyName = researcher.FamilyName;
                        rStudent.Title = researcher.Title;
                        rStudent.Unit = researcher.Unit;
                        rStudent.Campus = researcher.Campus;
                        rStudent.Email = researcher.Email;
                        rStudent.Photo = researcher.Photo;
                        rStudent.Level = researcher.Level;
                        rStudent.CurrentJobStart = researcher.CurrentJobStart;
                        rStudent.EarliestStart = researcher.EarliestStart;
                        rStudent.Tenure = researcher.Tenure;
                        rStudent.Supervisions = researcher.Supervisions;
                        rStudent.Degree = rdr.GetString(12);
                    }
                    // if the researche type equals 'Student', generate staff object
                    else
                    {
                        rStaff.GivenName = researcher.GivenName;
                        rStaff.FamilyName = researcher.FamilyName;
                        rStaff.Title = researcher.Title;
                        rStaff.Unit = researcher.Unit;
                        rStaff.Campus = researcher.Campus;
                        rStaff.Email = researcher.Email;
                        rStaff.Photo = researcher.Photo;
                        rStaff.Level = researcher.Level;
                        rStaff.CurrentJobStart = researcher.CurrentJobStart;
                        rStaff.EarliestStart = researcher.EarliestStart;
                        rStaff.Tenure = researcher.Tenure;
                        rStaff.Supervisions = researcher.Supervisions;
                    }
                }
            }
            catch (MySqlException e)
            {
                ERDAdapter.ReportError("loading training sessions", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }


            // return student object
            if (type == "Student")
            {
                //get the publication count
                rStudent.PublicationsCount = PublicationAdapter.fetchPublicationCounts(conn, id);
                return rStudent;
            }
            // return staff object
            else
            {
                //get the publication count
                rStaff.PublicationsCount = PublicationAdapter.fetchPublicationCounts(conn, id);
                rStaff.ThreeYearAverage = calThreeYearAveragePublications(conn, id);

                // according to the level of staff, calculate the performance data
                switch (rStaff.Level)
                {
                    case "A": rStaff.Performance = (float)(rStaff.ThreeYearAverage / 0.5);
                        break;
                    case "B":
                        rStaff.Performance = rStaff.ThreeYearAverage;
                        break;
                    case "C":
                        rStaff.Performance = (float)(rStaff.ThreeYearAverage / 2);
                        break;
                    case "D":
                        rStaff.Performance = (float)(rStaff.ThreeYearAverage / 3.2);
                        break;
                    case "E":
                        rStaff.Performance = (float)(rStaff.ThreeYearAverage / 4);
                        break;

                }

                return rStaff;
            }            
        }
        

        public static Researcher completeResearcherDetails(MySqlConnection conn, Researcher r)
        {

            return r;
        }
        

        // return the researcher's previous position list
        public static List<Position> fetchPreviousPositions(MySqlConnection conn, Researcher r)
        {
            List<Position> positions = new List<Position>();
            
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                int id = r.getId();

                //if the end time is null, set a defaut value '3000-01-01 00:00:00'
                MySqlCommand cmd = new MySqlCommand("select level,start, IFNULL(end, '3000-01-01 00:00:00') " +
                                                    "from position " +
                                                    "where end is not null and id=?id", conn);
                                
                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DateTime endTime = rdr.GetDateTime(2);
                    
                    //if the end time equals the default time, set the end time to 'new DateTime()'
                    if (endTime.Year == 3000)
                    {
                        DateTime rtEnd = new DateTime();
                        positions.Add(new Position
                        {
                            level = rdr.GetValue(0).ToString(),
                            start = rdr.GetDateTime(1),
                            end = rtEnd
                        });
                    }
                    else
                    {
                        positions.Add(new Position
                        {
                            level = rdr.GetValue(0).ToString(),
                            start = rdr.GetDateTime(1),
                            end = endTime
                        });
                    }
                }
            }
            catch (MySqlException e)
            {
                ERDAdapter.ReportError("loading training sessions", e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            /*
            foreach( Position p in positions)
                {
                Console.WriteLine("@@@@@@@@@@@@@@: " + p.ToString());
            }
            */

            return positions;
        }


        // fetch supervisor's student list.
        public static List<Student> fetchSupervisionStudents(MySqlConnection conn, Researcher r)
        {
            List<Student> students = new List<Student>();

            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select family_name, given_name, title, id, degree, unit, campus from researcher where supervisor_id=?supervisor_id", conn);
                cmd.Parameters.AddWithValue("supervisor_id", r.getId());

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    Student s = new Student();

                    s.FamilyName = rdr.GetString(0);
                    s.GivenName = rdr.GetString(1);
                    s.Title = rdr.GetString(2);
                   
                    s.Unit = rdr.GetString(5);
                    s.Campus = rdr.GetString(6);
                    
                    s.setId(rdr.GetInt32(3));
                                        
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    students.Add(s);
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

            return students; 
        }


        // Generate the number of the previous 3 years publications
        public static float calThreeYearAveragePublications(MySqlConnection conn, int id)
        {
            // the return value of the previous three years publications
            float averagePublications = 0;
                        
            // curent year
            int currentYear = DateTime.Now.Year;

            //get the previous years data
            int preYear1 = currentYear - 1;
            int preYear2 = currentYear - 2;
            int preYear3 = currentYear - 3;
            
            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();
                
                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("SELECT count(p.doi) / 3 as publicationCount FROM publication p, researcher_publication rp WHERE p.year in (?preYear1 ,?preYear2 ,?preYear3) and p.doi=rp.doi and rp.researcher_id = ?researcher_id", conn);
                cmd.Parameters.AddWithValue("researcher_id", id);
                cmd.Parameters.AddWithValue("preYear1", preYear1);
                cmd.Parameters.AddWithValue("preYear2", preYear2);
                cmd.Parameters.AddWithValue("preYear3", preYear3);                                

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    averagePublications = rdr.GetFloat(0);
                }

                return averagePublications;

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

            return averagePublications;
        }


    }
}
