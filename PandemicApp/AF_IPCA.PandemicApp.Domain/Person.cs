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

/// <summary>
/// Pandemic App Domain mainspace. This is the space where classes are "linked" together in a library
/// </summary>
namespace AF_IPCA.PandemicApp.Domain
{
    /// <summary>
    /// This is Person's class. This will define a person.
    /// </summary>
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
        private int age;                                                            //Person's age
        private string gender;                                                      //Person's gender

        private ContactPerson contactInfo = new ContactPerson();

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// standard constructor for class Nation
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
            set { country = CapitalLetter(value); }
        }

        /// <summary>
        /// Responsible to handle a person's citizenship
        /// </summary>
        public string Citizenship
        {
            get { return citizenship; }
            set { citizenship = CapitalLetter(value); }
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
                language = CapitalLetter(value);
            }
        }

        /// <summary>
        /// manages a person's first name, making sure the first letter is capitalized, with assistant of a funtion
        /// </summary>
        public string FirstName
        {
            get
            {
                return CapitalLetter(firstName);
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
                return CapitalLetter(lastName);
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
                fullName = CapitalLetter(value);
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
                            value = "Masculino";
                            break;

                        case "F":
                            value = "Feminino";
                            break;

                        default:
                            break;
                    }
                    gender = CapitalLetter(value);
                }
                else
                {
                    gender = "";
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

        /// <summary>
        /// checks if an inserted birthdate is correct, by parsing it to an aux variable. Also returns the age, using a procedure
        /// </summary>
        /// <param name="date"></param>
        /// <returns>birthDate and age</returns>
        public DateTime CheckDate(string date)
        {
            DateTime aux;
            bool b = DateTime.TryParse(date, out aux);

            this.BirthDate = b ? aux : DateTime.Today;

            this.Age = DateToAge(this.BirthDate);

            return this.BirthDate;
        }

        /// <summary>
        /// Converts a given birthdate into an age
        /// </summary>
        /// <param name="date">already parsed date, inputed from user</param>
        /// <returns>returns the age based on the difference of current date and the inserted birthdate</returns>
        private int DateToAge(DateTime date)
        {
            TimeSpan aux = DateTime.Now - date;
            double years = aux.Days / (365.242);                                  //365.242 is an accountability for leap years

            Age = (int)years;
            return Age;
        }

        /// <summary>
        /// will capitalize the first letter.
        /// </summary>
        /// <param name="s">receives a string as parameter</param>
        /// <returns>returns the string with the first letter capitalized</returns>
        public static string CapitalLetter(string s)
        {
            return System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(s.ToLower());
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}