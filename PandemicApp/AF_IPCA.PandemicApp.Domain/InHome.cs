/*
 * ********************************************************************************
 * <copyright file = "InHome"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>4/24/2020 6:31:13 PM</date>
 * <description>This class handls the procedure and comunications when a sick person will recover at home</description>
 * ********************************************************************************
 */

using System;

/// <summary>
/// Pandemic App Domain mainspace. This is the space where classes are "linked" together in a library
/// </summary>
namespace AF_IPCA.PandemicApp.Domain
{
    /// <summary>
    /// Class InHome will manage comunication and procedure if a sickperson will recover at home.
    /// </summary>
    public class InHome
    {
        private EmergencyContactPerson emrContactPerson = new EmergencyContactPerson();

        #region ------- MEMBER VARIABLES -------

        private string proceduresForPatientAtHome;                              //procedures for a patient to follow at home

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        public InHome()
        {
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        public string ProceduresForPatientAtHome
        {
            get
            {
                return proceduresForPatientAtHome;
            }
            set
            {
                int x = 200; //string limit
                this.proceduresForPatientAtHome = value.Length < x ? value : value.Substring(0, x);
            }
        }

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// This method informes patient of procedures at home.
        /// </summary>
        public void informPatientProcedures()
        {
            Console.WriteLine(proceduresForPatientAtHome);
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}