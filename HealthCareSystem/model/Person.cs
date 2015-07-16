using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.model
{
    /// <summary>
    /// Model of a person.
    /// </summary>
    public class Person
    {
        private int personID;
        private String ssn;
        private String lastName;
        private char? middleInitial;
        private String firstName;
        private DateTime dateOfBirth;
        private char gender;
        private String address;
        private String city;
        private String state;
        private String zip;
        private String phone;

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public int PersonId
        {
            get { return personID; }
            set { personID = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public char? MiddleInitial
        {
            get { return middleInitial; }
            set { middleInitial = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string FullName
        {
            get { return firstName + " " + lastName; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        /// <summary>
        /// Public getter/setter
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    /* 
    Database reference
    SELECT TOP 1000 [personID]
      ,[ssn]
      ,[lastName]
      ,[middleInitial]
      ,[firstName]
      ,[dateOfBirth]
      ,[gender]
      ,[address]
      ,[city]
      ,[state]
      ,[zip]
      ,[phone]
    FROM Person
     */
}
