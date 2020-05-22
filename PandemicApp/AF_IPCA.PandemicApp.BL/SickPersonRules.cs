/*
 * ********************************************************************************
 * <copyright file = "SickPersonRules"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/16/2020 9:46:16 PM</date>
 * <description>This class handles the logic of a sick person</description>
 * ********************************************************************************
 */

using System;
using AF_IPCA.PandemicApp.BO;
using AF_IPCA.PandemicApp.DAO;

/// <summary>
/// This is the business logic DLL. This handles all rules and some validations.
/// It does not store information.
/// </summary>
namespace AF_IPCA.PandemicApp.BL
{
    /// <summary>
    /// This class handles the comunication between frontend and data
    /// </summary>
    public class SickPersonRules : CrossRules
    {

        #region ------- MEMBER VARIABLES -------



        #endregion


        #region ------- CONSTRUCTORS -------

        public SickPersonRules()
        {

        }

        #endregion


        #region ------- PROPERTIES -------

        #endregion


        #region ------- FUNCTIONS -------

        /// <summary>
        /// this methodo mediates the request to set a sickperson as a death person.
        /// </summary>
        /// <param name="fullName">uses the full name to search (not ideal)</param>
        /// <returns>true if sucess, or false if not</returns>
        public static bool SetDeathOfSickPersonRequest(string fullName)
        {
            return fullName != null ? SickPersons.SetDeathOfSickPerson(fullName) : false;
        }

        /// <summary>
        /// This method gives the link needed to the frondend insert a new SickPerson
        /// </summary>
        /// <param name="sickPerson"></param>
        /// <returns></returns>
        public static bool InsertsSickPerson(SickPerson sickPerson)
        {
            return sickPerson.FirstName != null ? SickPersons.AddSickPerson(sickPerson) : false;
        }

        /// <summary>
        /// This methodo access the stored information in order to return a more "friendly" designation of gender
        /// </summary>
        /// <param name="sickPerson">Its the object it self.</param>
        /// <returns>Sr or Sra</returns>
        public static string GetGender(SickPerson sickPerson)
        {
            return sickPerson.Gender == null ? null : String.Compare(SickPersons.GetGenderFromList(sickPerson), "M") == 1 ? "Sr." : "Sra.";
        }


        /// <summary>
        /// This methodo sets the contact information of the sickperson.
        /// </summary>
        /// <param name="sickPerson">sick person object</param>
        /// <param name="phoneNum">Sick person's phone number</param>
        /// <param name="email">Sick person's email</param>
        /// <param name="addDesc">Sick person's address</param>
        /// <param name="addZipCode">Sick person's zip code</param>
        /// <param name="addCity">Sick person's city</param>
        /// <param name="addDistrict">Sick person's district</param>
        /// <param name="addCountry">Sick person's country</param>
        /// <returns></returns>
        public static bool SetContactInfo(
            SickPerson sickPerson,
            string phoneNum,
            string email,
            string addDesc,
            string addZipCode,
            string addCity,
            string addDistrict,
            string addCountry
            )
        {
            //Confirmar com professor, se as validações que estao nas properties devem passar para esta camada

            return SickPersons.SetPersonsContact(
        sickPerson,
        phoneNum,
        email,
        CapitalLetter(addDesc),
        addZipCode,
        CapitalLetter(addCity),
        CapitalLetter(addDistrict),
        CapitalLetter(addCountry)
        );
        }

        /// <summary>
        /// This method is a mediator and sends the information for set in the sickPersons's "object"
        /// </summary>
        /// <param name="sickPerson">Sick persons object</param>
        /// <param name="fName">emergency contact person's first name</param>
        /// <param name="lName">emergency contact person's last name</param>
        /// <param name="phoneNum">emergency contact person's phone number</param>
        /// <param name="relStatus">emergency contact person's relative status of sick person</param>
        /// <returns></returns>
        public static bool SetEmrContact(SickPerson sickPerson, string fName, string lName, string phoneNum, string relStatus)
        {
            if(fName!=null && lName!=null && phoneNum!=null && relStatus!=null)
            {
                return SickPersons.SetEmrContactPerson(sickPerson, new EmergencyContactPerson(fName, lName, phoneNum, relStatus));
            }

            return false;
        }

        /// <summary>
        /// This method mediates the request for adding a disease into a sick person's disease history
        /// </summary>
        /// <param name="sickPerson">sickperson</param>
        /// <param name="personDisease">registered disease</param>
        /// <param name="sickPersonSintoms">disease sintoms</param>
        /// <returns></returns>
        public static bool AddDiseaseToSickPersonHistoryRequest(SickPerson sickPerson, Disease personDisease, string sickPersonSintoms)
        {
            return personDisease!=null ? SickPersons.AddDiseaseToSickPersonHistory(sickPerson,new DiseaseHistory(personDisease, CapitalLetter(sickPersonSintoms))):false;
        }

        /// <summary>
        /// This method mediates the request for adding more info to a person's file
        /// </summary>
        /// <param name="sickPerson">sick person object</param>
        /// <param name="birthdate">person's birthdate</param>
        /// <param name="nationality">person's nationality</param>
        /// <param name="country">person's country</param>
        /// <param name="citizenship">person's citizenship</param>
        /// <param name="language">person's language</param>
        /// <returns></returns>
        public static bool AddBaseInfoToSickPersonRequest(SickPerson sickPerson, string birthdate, string country, string citizenship, string language)
        {
            if(sickPerson!=null)
            {
                _ = DateTime.TryParse(birthdate, out DateTime bdate) ? bdate : DateTime.Today;

                string pCountry = country != null ? CapitalLetter(country) : null;
                string pCitizen = citizenship != null ? CapitalLetter(citizenship) : null;
                string pLang = language != null ? CapitalLetter(language) : null;

                return SickPersons.AddBaseInfoToSickPerson(sickPerson, bdate, pCountry, pCitizen, pLang);
            }

            return false;
        }

        /// <summary>
        /// Method that mediates the request for seek a sickperson by name. In the future, more reliable parameters should be implemented
        /// </summary>
        /// <param name="fullName">uses the full name as search method</param>
        /// <returns></returns>
        public static SickPerson GetSickPersonRequest(string fullName)
        {
            return fullName != null ? SickPersons.GetSickPerson(fullName) : null;

        }

        /// <summary>
        /// Returns the person's current age, given the birthdate
        /// </summary>
        /// <param name="sickPerson">passes the sickperson's object to extract the birthdate</param>
        /// <returns>an int age</returns>
        public static void GetAge(SickPerson sickPerson)
        {
           sickPerson.Age=DateToAge(sickPerson.BirthDate);
        }

        /// <summary>
        /// Converts a given birthdate into an age
        /// </summary>
        /// <param name="date">already parsed date, inputed from user</param>
        /// <returns>returns the age based on the difference of current date and the inserted birthdate</returns>
        private static int DateToAge(DateTime date)
        {
            TimeSpan aux = DateTime.Now - date;
            double years = aux.Days / (365.242);                                  //365.242 is an accountability for leap years

            int age = (int)years;
            return age;
        }

        /// <summary>
        /// This methodo mediates the rquest for mark a sick person as cured. This means the person is no longer sick.
        /// </summary>
        /// <param name="spName">Person's Name</param>
        /// <returns></returns>
        public static bool MedDischargeSickPersonRequest(string spName)
        {
            return spName!=null? SickPersons.MedDischargeSickPerson(spName):false;
        }

        /// <summary>
        /// This method mediates the request for saving an entire structure into a file
        /// </summary>
        /// <param name="fName">Full path and name of bin file</param>
        /// <returns>true if sucess false if not</returns>
        public static bool SaveAllRequest(string fName)
        {
            return fName != null ? SickPersons.SaveAll(fName) : false;
        }

        /// <summary>
        /// This method mediates the request for loading an entire structure into memory (not ideal)
        /// </summary>
        /// <param name="fName">Full path and name of bin file</param>
        /// <returns>true if sucess false if not</returns>
        public static bool LoadAllRequest(string fName)
        {
            return fName != null ? SickPersons.LoadAll(fName) : false;
        }

        /// <summary>
        /// This method handles a the request to gather information to print a dashboard related to stats of the pandemic situation
        /// </summary>
        /// <param name="numSP">Number of active sickperson</param>
        /// <param name="totSP">Total number of sickperson</param>
        /// <param name="numDeads">Number of deaths</param>
        /// <returns>true if there is data, or false if not</returns>
        public static bool ListSickPersonDashBoardRequest(out int numSP, out int totSP, out int numDeaths)
        {
            return SickPersons.ListSickPersonDashBoard(out numSP, out totSP, out numDeaths);
        }

        #endregion


        #region ------- ENUMS -------



        #endregion
    }
}
