/*
 * ********************************************************************************
 * <copyright file = "Disease"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/16/2020 5:59:00 PM</date>
 * <description>This class defines a pandemic disease</description>
 * ********************************************************************************
 */

using System;
using System.Threading;

/// <summary>
/// Pandemic App Business Object level DLL. 
/// Here is where everything is defined
/// </summary>
namespace AF_IPCA.PandemicApp.BO
{
    /// <summary>
    /// This class handls the diseases. It is the template of a disease
    /// </summary>
    [Serializable]
    public class Disease
    {

        #region ------- MEMBER VARIABLES -------
        private static int globalDiseaseID;                                             //global count of id
        private int diseaseID;                                                          //id of disease
        private string typeOfDisease;                                                   //type of disease (COVID, BIRDFLUE, Others)
        private string diseaseSintoms;                                                  //describes the sintoms
        private int incubationPeriod;                                                   //indicates the number of days that the virus takes to incubate

        

        #endregion


        #region ------- CONSTRUCTORS -------

        public Disease()
        {
            this.diseaseID = Interlocked.Increment(ref globalDiseaseID);
        }


        public Disease(string diseaseType, string diseaseSintoms, int diseaseIncPeriod )
        {
            this.TypeOfDisease = diseaseType;
            this.DiseaseSintoms = diseaseSintoms;
            this.IncubationPeriod = diseaseIncPeriod;
            this.DiseaseID = Interlocked.Increment(ref globalDiseaseID);
        }

        #endregion


        #region ------- PROPERTIES -------

        /// <summary>
        /// Manages the diseases incubation period for reference.
        /// </summary>
        public int IncubationPeriod
        {
            get
            {
                return incubationPeriod;
            }
            set
            {

                incubationPeriod = value >= 0 ? value : 0;
            }
        }

        /// <summary>
        /// Defines the disease ID autoincremented
        /// </summary>
        public int DiseaseID
        {
            get
            {
                return diseaseID;
            }
            private set
            {
                diseaseID = value;
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



        #endregion


        #region ------- FUNCTIONS -------

        #endregion


        #region ------- ENUMS -------



        #endregion
    }
}
