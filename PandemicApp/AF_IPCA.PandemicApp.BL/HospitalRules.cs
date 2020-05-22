/*
 * ********************************************************************************
 * <copyright file = "HospitalRules"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/19/2020 4:28:28 PM</date>
 * <description>This class handles the logic and rules in the hospitals portfolio</description>
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
    /// This class handles the logic and rules in the hospitals portfolio
    /// </summary>
    public class HospitalRules : CrossRules
    {
        #region ------- MEMBER VARIABLES -------

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        public HospitalRules()
        {
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------


        /// <summary>
        /// this method moderates the rquest made by user, filtering the hospital database in order to print the hospitals acording to the district
        /// </summary>
        /// <param name="hDistrict">user input a district for norrow information</param>
        /// <returns>returns true if sucessd, or false if no hospitals found in the district</returns>
        public static bool PrintHospitalsFromDistrictRequest(string hDistrict, out int[] ids)
        {
            bool b;
            if (hDistrict != null)
            {
                b = Hospitals.PrintHospitalsFromDistrict(CapitalLetter(hDistrict), out int[] x);
                ids = x;
                return b;
            }
            ids = null;
            return false;
        }

        public static Hospital GetHospitalByIDRequest(int id)
        {
            return Hospitals.GetHospitalByID(id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="hName"></param>
        /// <param name="hDistrict"></param>
        /// <param name="hCity"></param>
        /// <param name="hPublic"></param>
        /// <returns></returns>
        public static bool AddNewHospitalRequest(string hName, string hDistrict, string hCity, string hPublic, out int id)
        {
            if (hName != null && hDistrict != null && hCity != null && hPublic != null)
            {
                _ = Boolean.TryParse(hPublic, out bool isPublic) ? isPublic : false;

                Hospitals.AddToHospitalList(new Hospital(hName, hDistrict, hCity, isPublic), out int x);
                id = x;
                return true;
            }
            id = -1;
            return false;
        }

        /// <summary>
        /// This method mediates the request for saving an entire structure into a file
        /// </summary>
        /// <param name="fName">Full path and name of bin file</param>
        /// <returns>true if sucess false if not</returns>
        public static bool SaveAllRequest(string fName)
        {
            return fName != null ? Hospitals.SaveAll(fName) : false;
        }


        /// <summary>
        /// This method mediates the request for loading an entire structure into memory (not ideal)
        /// </summary>
        /// <param name="fName">Full path and name of bin file</param>
        /// <returns>true if sucess false if not</returns>
        public static bool LoadAllRequest(string fName)
        {
            return fName != null ? Hospitals.LoadAll(fName) : false;
        }


        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}