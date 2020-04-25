/*
 * ********************************************************************************
 * <copyright file = "DiseaseHistory"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>4/9/2020 2:23:47 PM</date>
 * <description>This class will be responsible to define the decease history necessary data of a person</description>
 * ********************************************************************************
 */

using System;
using System.Collections.Generic;
/// <summary>
/// Pandemic App Domain mainspace. This is the space where classes are "linked" together in a library
/// </summary>
namespace AF_IPCA.PandemicApp.Domain
{
    /// <summary>
    /// This class is responsible to manage a person's disease. As so, it will become a patient.
    /// </summary>
    public class DiseaseHistory
    {
        #region ------- MEMBER VARIABLES -------

        private string typeOfDisease;                                                   //type of disease (COVID, BIRDFLUE, Others)
        private string diseaseSintoms;                                                  //describes the sintoms
        private DateTime diagnosticDate;                                                //date of diagnose
        private bool isCured;                                                           //bool value, if the patient is cured or not


        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        public DiseaseHistory()
        {
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------


        /// <summary>
        /// This property handles the type of diseases
        /// </summary>
        public string TypeOfDisease
        {
            get
            {
                return typeOfDisease;
            }
            set
            {
                typeOfDisease = CapitalLetter(value);
            }
        }

        /// <summary>
        /// describes the disease sintoms
        /// </summary>
        public string DiseaseSintoms
        {
            get
            {
                return diseaseSintoms;
            }
            set
            {
                diseaseSintoms = value;
            }
        }

        /// <summary>
        /// defines the diagnostic date of the disease. By default is the insertion date.
        /// </summary>
        public DateTime DiagnosticDate
        {
            get
            {
                return diagnosticDate;
            }
            set
            {
                diagnosticDate = value;                //sets the date of "creation" as the date of diagnose
            }
        }

        /// <summary>
        /// Bool value for a cured or not status
        /// </summary>
        public bool IsCured
        {
            get
            {
                return isCured;
            }
            set
            {
                isCured = value;
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

      

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}