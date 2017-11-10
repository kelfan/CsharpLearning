using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.Research;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Windows; //for generating a MessageBox upon encountering an error

namespace RAP.Database
{
    public abstract class ERDAdapter
    {
        private static bool reportingErrors = false;

        private const string db = "**";
        private const string user = "**";
        private const string pass = "**";
        private const string server = "utas.edu.au";

        //Generate the connection to the remote mysql database
        private static MySqlConnection conn;
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString =
                String.Format("Database={0};Data Source={1};User Id={2}; Password={3}",
                db, server, user, pass);
                connectionString += "; Allow Zero Datetime=True";
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        // it is the code from tutorial to convert others into enum
        // public util method to transfer data
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        // return the researcher list defaultly.
        public static List<Researcher> fetchBasicResearcherDetails()
        {
            MySqlConnection conn = GetConnection();
            return ResearcherAdapter.fetchBasicResearcherDetails(conn);
        }

        // return researcher detail by using researcher id
        public static Researcher fetchFullResearcherDetails(int id)
        {            
            MySqlConnection conn = GetConnection();
            return ResearcherAdapter.fetchFullResearcherDetails(conn, id);           
        }
             

        public Researcher completeResearcherDetails(Researcher r)
        {
            MySqlConnection conn = GetConnection();
            return ResearcherAdapter.completeResearcherDetails(conn, r);
        }

        // return publication list according to the researcher data (id)
        public static List<Publication> fetchBasicPublicationDetails(Researcher r)
        {
            MySqlConnection conn = GetConnection();
            return PublicationAdapter.fetchBasicPublicationDetails(conn, r);
        }

        // return publication detailed information accoring to the publication id
        public Publication completePublicationDetails(Publication p)
        {
            MySqlConnection conn = GetConnection();
            return PublicationAdapter.completePublicationDetails(conn, p);
        }

        // generate publication count group by Year, the years scope would be from 'from' to 'to'
        public static int[] fetchPublicationCounts(DateTime from, DateTime to)
        {
            MySqlConnection conn = GetConnection();
            return PublicationAdapter.fetchPublicationCounts(conn, from, to);     
        }

        // codes from tutorial to report errors 
        public static void ReportError(string msg, Exception e)
        {
            if (reportingErrors)
            {
                MessageBox.Show("An error occurred while " + msg + ". Try again later.\n\nError Details:\n" + e,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // return the position list in the organization, condition will be the researcher id which is stored in 'r'
        public static List<Position> fetchPreviousPositions(Researcher r)
        {
            MySqlConnection conn = GetConnection();
            return ResearcherAdapter.fetchPreviousPositions(conn, r);
        }

        // return the student list in which the students' supervisor is the rearcher
        public static List<Student> fetchSupervisionStudents(Researcher r)
        {
            MySqlConnection conn = GetConnection();
            return ResearcherAdapter.fetchSupervisionStudents(conn, r);
        }

        // return the year list of the researcher's publication
        public static List<int> fetchPublicationYearList(Researcher r)
        {
            MySqlConnection conn = GetConnection();
            return PublicationAdapter.fetchPublicationYearList(conn, r);
        }

        // generate the publication count group by year
        public static List<PublicationYearCount> genPublicationYearData(Researcher r)
        {
            MySqlConnection conn = GetConnection();
            return PublicationAdapter.genPublicationYearData(conn, r);
        }

    }
}
