using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    class AppointmentInfo : Appointment
    {
        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }
    }
}
