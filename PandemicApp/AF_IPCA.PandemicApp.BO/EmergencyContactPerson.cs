/*
 * ********************************************************************************
 * <copyright file = "EmergencyContactPerson"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>4/24/2020 6:40:51 PM</date>
 * <description>This class manages the emergency contact person</description>
 * ********************************************************************************
 */


/// <summary>
/// Pandemic App Business Object level DLL. 
/// Here is where everything is defined
/// </summary>
namespace AF_IPCA.PandemicApp.BO
{
    /// <summary>
    /// This class is the structure of an emergency contact person. It inherits from class Person
    /// </summary>
    [System.Serializable]
    public class EmergencyContactPerson : Person
    {


        #region ------- MEMBER VARIABLES -------
        
        private bool hasEmergencyPersonContact;                                         //checks if the patient has a contact person in case of emergency
        private string relativeStatus;                                                  //stores the relationship status between the patient and the contact person
  
        
        #endregion


        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// default constructor
        /// </summary>
        public EmergencyContactPerson()
        {

        }

        /// <summary>
        /// Parameterized constructor. It gives all the info needed to build this object
        /// </summary>
        /// <param name="fName">EMR first name</param>
        /// <param name="lName">EMR last name</param>
        /// <param name="phoneNum">EMR phone number</param>
        /// <param name="relStatus">EMR relationship with sick person</param>
        public EmergencyContactPerson(string fName, string lName, string phoneNum, string relStatus)
        {
            this.HasEPC = true;
            this.FirstName = fName;
            this.LastName = lName;
            this.FullName = fName + " " + lName;
            this.ContactInfo.PhoneNumber = phoneNum;
            this.RelativeStatus = relStatus;
        }
        #endregion


        #region ------- PROPERTIES -------
        /// <summary>
        /// Defines the relationship between the pacient and the emergency contact person
        /// </summary>
        public string RelativeStatus
        {
            get
            {
                return relativeStatus;
            }
            set
            {
                relativeStatus = value;
            }
        }

        /// <summary>
        /// stores bool value if there is a emergency contact person.
        /// </summary>
        public bool HasEPC
        {
            get
            {
                return hasEmergencyPersonContact;
            }
            set
            {
                hasEmergencyPersonContact = value;
            }
        }        
        #endregion


        #region ------- FUNCTIONS -------


        #endregion


        #region ------- ENUMS -------



        #endregion
    }
}
