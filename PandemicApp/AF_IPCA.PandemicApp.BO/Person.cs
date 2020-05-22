/*
 * ********************************************************************************
 * <copyright file = "Person"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>4/3/2020 7:04:04 PM</date>
 * <description>This class will define a person. It has general information</description>
 * ********************************************************************************
 */

using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Pandemic App Business Object level DLL. 
/// Here is where everything is defined
/// </summary>
namespace AF_IPCA.PandemicApp.BO
{
    /// <summary>
    /// This is Person's class. This will define a person.
    /// </summary>
    [Serializable]
    public class Person
    {
        #region ------- MEMBER VARIABLES -------

        private string country;                                                     //Person's native country
        private string citizenship;                                                 //Person's citizenship
        private string language;                                                    //Person's language
        private string firstName;                                                   //Person's first name
        private string lastName;                                                    //Person's last name
        private string fullName;                                                    //Person's full name
        private DateTime birthDate;                                                 //Person's birthdate
        [NonSerialized]
        private int age;                                                            //Person's age
        private string gender;                                                      //Person's gender

        private ContactPerson contactInfo = new ContactPerson();

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// standard constructor for class Person
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Constructor with base parameters as Name and gender
        /// </summary>
        /// <param name="fName">First Name</param>
        /// <param name="lName">Last Name</param>
        /// <param name="gender">Gender</param>
        public Person(string fName, string lName, string gender)
        {
            FirstName = fName;
            LastName = lName;
            fullName = FirstName + " " + LastName;
            Gender = gender;
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        /// <summary>
        /// Responsible to handle a person's citizenship
        /// </summary>
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        /// <summary>
        /// Responsible to handle a person's citizenship
        /// </summary>
        public string Citizenship
        {
            get { return citizenship; }
            set { citizenship = value; }
        }

        /// <summary>
        /// Responsible to handle a person's native language
        /// </summary>
        public string Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
            }
        }

        /// <summary>
        /// manages a person's first name, making sure the first letter is capitalized, with assistant of a funtion
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        /// <summary>
        /// manages a person's last name, making sure the first letter is capitalized, with assistant of a funtion
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        /// <summary>
        /// Manages the concatenation of first and last name
        /// </summary>
        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
            }
        }

        /// <summary>
        /// Checks if inserted birthdate is valid. If it is, it will be passed to the variable birthDate
        /// </summary>
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }

        /// <summary>
        /// Calculates the person's age from the validated birthdate. if birthdate is not valid, age will be 0
        /// </summary>
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        /// <summary>
        /// Manages a Person's gender
        /// </summary>
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value.Equals("M") || value.Equals("m") || value.Equals("F") || value.Equals("f"))  //check if it's valid
                {
                    switch (value.ToUpper())
                    {
                        case "M":
                            gender = "Masculino";
                            break;

                        case "F":
                            gender = "Feminino";
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    gender = null;
                }
            }
        }

        /// <summary>
        /// property of type ContactPerson. It is responsible to parse the contacts of a person
        /// </summary>
        public ContactPerson ContactInfo
        {
            get => contactInfo; set => contactInfo = value;
        }

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------


        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}