using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareSystem.dbAccess;
using HealthCareSystem.model;

namespace HealthCareSystem.controller
{
    /// <summary>
    /// LabTestController controls the flow of lab test data.
    /// </summary>
    class LabTestController
    {
        /// <summary>
        /// Gets all of the lab tests from the db.
        /// </summary>
        /// <returns>Every lab test in the db</returns>
        public static List<LabTest> GetAllLabTests()
        {
            return LabTestDB.GetAllLabTests();
        }

        public static LabTest GetLabTestByID(int testID)
        {
            return LabTestDB.GetLabTestByID(testID);
        }

        public static int AddLabTest(LabTest labTest)
        {
            return LabTestDB.InsertLabTest(labTest);
        }

        public static bool DeleteLabTest(int labTestId)
        {
            return LabTestDB.DeleteLabTest(labTestId);
        }

        public static bool UpdateLabTest(LabTest oldLabTest , LabTest newLabTest)
        {
            return LabTestDB.UpdateLabTest(oldLabTest, newLabTest);
        }
    }
}
