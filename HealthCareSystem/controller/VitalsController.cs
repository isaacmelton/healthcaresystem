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
    /// VitalsController controls the flow of vitals data.
    /// </summary>
    class VitalsController
    {
        /// <summary>
        /// Adds vitals records to the db.
        /// </summary>
        /// <param name="vitals">The vitals to add</param>
        /// <returns>The id of the vitals records</returns>
        public static int AddVitals(Vitals vitals)
        {
            return VitalsDB.AddVitals(vitals);
        }

        /// <summary>
        /// Adds vitals records to the db.
        /// </summary>
        /// <param name="appID">The patients appointment id</param>
        /// <param name="bloodPress">The patients blood pressure</param>
        /// <param name="bodyTemp">The patients body temperature</param>
        /// <param name="pulse">The patients pulse</param>
        /// <returns>The id of the vitals records</returns>
        public static int AddVitals(int appID, String bloodPress, Decimal bodyTemp, Decimal pulse)
        {
            Vitals vit = new Vitals();

           vit.AppointmentId = appID;
           vit.BloodPressure = bloodPress;
           vit.BodyTemperature = bodyTemp;
           vit.Pulse = pulse;

            return AddVitals(vit);
        }
    }
}
