using HealthCareSystem.dbAccess;
using HealthCareSystem.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareSystem.controller
{
    /// <summary>
    /// ResultController controls the flow of result data.
    /// </summary>
    class ResultController
    {
        public static int AddTestToAppointment(Result newResult)
        {
            int appointmentID = -1;

            try
            {
                appointmentID = ResultDB.AddTest(newResult);

                if (appointmentID == -1)
                {
                    throw new Exception("Error scheduling test!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }

            return appointmentID;
        }

        public static List<Result> GetOpenTestsByAppointment()
        {
            List<Result> openTestList = new List<Result>();

            try
            {
                openTestList = ResultDB.GetOpenTestsByAppointment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return openTestList;
        }

        public static Result GetTestInfo(int appointmentID)
        {
            Result aResult = new Result();

            try
            {
                aResult = ResultDB.GetTestInfo(appointmentID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);

            }
            return aResult;
        }

        public static List<Result> GetOpenTestList(int appointmentID)
        {
            List<Result> resList = new List<Result>();
            try
            {
                resList = ResultDB.GetOpenTestList(appointmentID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);
            }
            return resList;
        }

        public static bool UpdateTestResult(Result oldTest, Result newTest)
        {
            Boolean success = false;

            try
            {
                success = ResultDB.UpdateTestResult(oldTest, newTest);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);

            }
            return success;
        }

        public static List<Result> GetAllResults()
        {
            List<Result> allResults = new List<Result>();

            try
            {
                allResults = ResultDB.GetAllResultsByAppointment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);

            }
            return allResults;
        }

        public static List<Result> GetTestsForAppointment(int apptID)
        {
            List<Result> testListForAppt = new List<Result>();
            try
            {
                testListForAppt = ResultDB.GetTestsForAppointment(apptID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK);

            }
            return testListForAppt;
        }

    }
}
