/*
 * ********************************************************************************
 * <copyright file = "PandemicExceptions"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/22/2020 6:17:18 PM</date>
 * <description>This class will manage exceptions</description>
 * ********************************************************************************
 */

using System;

/// <summary>
/// This is the lowest level dll. This handles all file and lists mediation.
/// It stores information.
/// </summary>
namespace AF_IPCA.PandemicApp.DAO
{
    /// <summary>
    /// this class handles all the exceptions, on this level.
    /// </summary>
    internal class PandemicExceptions : ApplicationException
    {
        #region ------- MEMBER VARIABLES -------

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// default exception constructor
        /// </summary>
        public PandemicExceptions() : base("Erro Input/Output")
        {
        }

        /// <summary>
        /// constructor with custom message
        /// </summary>
        public PandemicExceptions(string s) : base(s)
        {
        }

        /// <summary>
        /// constructor with custom message and generic exception
        /// </summary>
        public PandemicExceptions(string s, Exception e)
        {
            throw new PandemicExceptions(e.Message + " --> " + s);
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}