/*
 * ********************************************************************************
 * <copyright file = "EmergencyContactPerson"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>4/24/2020 6:40:51 PM</date>
 * <description>This class manages the emergency contact person</description>
 * ********************************************************************************
 */

using System;

/// <summary>
/// Pandemic App Domain mainspace. This is the space where classes are "linked" together in a library
/// </summary>
namespace AF_IPCA.PandemicApp.Domain
{
    /// <summary>
    /// This class is the structure of an emergency contact person. It inherits from class Person
    /// </summary>
    public class EmergencyContactPerson : Person
    {


        #region ------- MEMBER VARIABLES -------
        
        private bool hasEmergencyPersonContact;                                         //checks if the patient has a contact person in case of emergency
        private string relativeStatus;                                                  //stores the relationship status between the patient and the contact person
  
        
        #endregion


        #region ------- CONSTRUCTORS -------

        public EmergencyContactPerson()
        {

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
