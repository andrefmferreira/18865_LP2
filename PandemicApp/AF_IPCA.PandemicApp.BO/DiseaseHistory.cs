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

/// <summary>
/// Pandemic App Business Object level DLL. 
/// Here is where everything is defined
/// </summary>
namespace AF_IPCA.PandemicApp.BO
{
    /// <summary>
    /// This class is responsible to manage a person's disease. As so, it will become a patient.
    /// </summary>
    [Serializable]
    public class DiseaseHistory
    {
        #region ------- MEMBER VARIABLES -------

        private static int diseaseID;
        private string typeOfDisease;                                                   //type of disease (COVID, BIRDFLUE, Others)
        private string diseaseSintoms;                                                  //describes the sintoms
        private DateTime diagnosticDate;                                                //date of diagnose
        private DateTime medDischargeDate;                                              //date of medical discharge from the pandemic virus infection
        private bool isCured;                                                           //bool value, if the patient is cured or not

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// Default constructor for DiseaseHistory class
        /// </summary>
        public DiseaseHistory()
        {
        }

        /// <summary>
        /// Constructor for DiseaseHistory object class
        /// </summary>
        /// <param name="d">receives the disease type with "default" values</param>
        /// <param name="personSintoms">Sick person's sintoms</param>
        public DiseaseHistory(Disease d, string personSintoms)
        {
            this.DiseaseID = d.DiseaseID;
            this.TypeOfDisease = d.TypeOfDisease;
            this.DiseaseSintoms = personSintoms;
            isCured = false;
            medDischargeDate = MedDischargeDate;
            DiagnosticDate = DateTime.Today;
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        /// <summary>
        /// this property manages the medical discharge date. It defines when a sick person, is no longer sick!
        /// </summary>
        public DateTime MedDischargeDate
        {
            get
            {
                return medDischargeDate;
            }
            set
            {
                medDischargeDate = value;
            }
        }

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
                typeOfDisease = value;
            }
        }

        /// <summary>
        /// Defines the disease ID based on the diseases selected
        /// </summary>
        public int DiseaseID
        {
            get
            {
                return diseaseID;
            }
            set
            {
                diseaseID = value;
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
                diagnosticDate = value;
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

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}