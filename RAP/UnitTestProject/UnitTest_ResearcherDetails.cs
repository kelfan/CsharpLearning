using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RAP.Database;
using RAP.Research;

namespace UnitTestProject
{
    class UnitTest_ResearcherDetails
    {
        [TestMethod]
        public void ResearcherPerformance()
        {
            // arrange a value to the parameter
            int researcher_id = 123461;

            // the expected value for the researcher's performance 
            float expected = 1.667f;

            // action - call the method to get researcher details including performance
            Staff s = (Staff)ERDAdapter.fetchFullResearcherDetails(researcher_id);

            // assert actual
            float actual = s.Performance;

            // compare the actual value with the expected value
            Assert.AreEqual(expected, actual, 0.001, "The value of performance is compared...");
        }
    }
}
