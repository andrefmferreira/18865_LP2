/*
 * ********************************************************************************
 * <copyright file = "ContactPerson"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>4/23/2020 4:35:15 PM</date>
 * <description>This class handles a person contact's</description>
 * ********************************************************************************
 */

using System.Text.RegularExpressions;
/// <summary>
/// Pandemic App Domain mainspace. This is the space where classes are "linked" together in a library
/// </summary>
namespace AF_IPCA.PandemicApp.BO
{
    /// <summary>
    /// this class handls a person's contact.
    /// </summary>
    public class ContactPerson
    {
        #region ------- MEMBER VARIABLES -------

        private string phoneNumber;                                                 //Person's phone contact without country prefix
        private string email;                                                       //Person's email contact
        private string addressCountry;                                              //Person's country of residence
        private string addressDistrict;                                             //Person's district of residence
        private string addressCity;                                                 //Person's city of residence
        private string addressDesc;                                                 //Person's address of residence
        private string addressZipCode;                                              //Person's zipcode of residence

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        public ContactPerson()
        {
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        /// <summary>
        /// Validates a Person's contact phone number;
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                bool b = (value.Length == 9) ? true : false;
                if (b)
                {
                    long aux;
    
                    bool c = long.TryParse(value, out aux);

                    phoneNumber = c ? aux.ToString() : "";
                    return;
                }
                phoneNumber = "";
            }
        }

        /// <summary>
        /// validates the inserted email (as an alternative contact method)
        /// </summary>
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                string pattern = (@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");         //REGEX pattern for email valid

                bool b = Validate(value.ToLower(), pattern);                                //validates all chars of a valid email.
   
                email = b ? value : "no-email";
            }
        }

        /// <summary>
        /// defines the country of address of a person
        /// </summary>
        public string AddressCountry
        {
            get
            {
                return addressCity;
            }
            set
            {
                addressCountry = (value.Length <= 50) ? CapitalLetter(value) : "";
            }
        }

        /// <summary>
        /// defines the district of address of a person
        /// </summary>
        public string AddressDistrict
        {
            get
            {
                return addressDistrict;
            }
            set
            {
                addressDistrict = (value.Length <= 50) ? CapitalLetter(value) : "";
            }
        }

        /// <summary>
        /// defines the city of address of a person
        /// </summary>
        public string AddressCity
        {
            get
            {
                return addressCity;
            }
            set
            {
                addressCity = (value.Length <= 50) ? CapitalLetter(value) : "";
            }
        }

        /// <summary>
        /// defines the address of a person
        /// </summary>
        public string AddressDesc
        {
            get
            {
                return addressDesc;
            }
            set
            {
                addressDesc = (value.Length <= 50) ? CapitalLetter(value) : "";
            }
        }

        /// <summary>
        /// defines the zipcode of person's address
        /// </summary>
        public string AddressZipCode
        {
            get
            {
                return addressZipCode;
            }
            set
            {
                bool b = Validate(value, @"^[1-9]\d{3}(-\d{3})?$");             //validates if the zip code is correct. Also checks if the first digit is not a 0

                addressZipCode = b ? value : "0000-000";
            }
        }

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// will capitalize the first letter.
        /// </summary>
        /// <param name="s">receives a string as parameter</param>
        /// <returns>returns the string with the first letter capitalized</returns>
        public static string CapitalLetter(string s)
        {
            return System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(s.ToLower());
        }

        /// <summary>
        /// Using regular expression library, and specifics patterns, it validates data.
        /// </summary>
        /// <param name="n">receives a string to validate</param>
        /// <param name="pattern">receives a patter to be the base to validate the string n</param>
        /// <returns>returns true if n is valid or false if not</returns>
        private bool Validate(string n, string pattern)
        {
            return Regex.IsMatch(n, pattern);
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}