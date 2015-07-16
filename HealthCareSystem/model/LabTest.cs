using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    /// <summary>
    /// Model of an lab test.
    /// </summary>
    class LabTest
    {
        private int testID;
        private String testType;

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public int TestId
        {
            get { return testID; }
            set { testID = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string TestType
        {
            get { return testType; }
            set { testType = value; }
        }
    }
}
