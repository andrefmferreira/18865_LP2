/*
 * ********************************************************************************
 * <copyright file = "DiseaseRules"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/17/2020 7:07:31 PM</date>
 * <description>This class mediates the logic on the process realated to diseases</description>
 * ********************************************************************************
 */

using AF_IPCA.PandemicApp.BO;
using AF_IPCA.PandemicApp.DAO;

/// <summary>
/// This is the business logic DLL. This handles all rules and some validations.
/// It does not store information.
/// </summary>
namespace AF_IPCA.PandemicApp.BL
{
    /// <summary>
    /// This class mediates the logic on the process realated to diseases
    /// </summary>
    public class DiseaseRules : CrossRules
    {
        #region ------- MEMBER VARIABLES -------

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        public DiseaseRules()
        {
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// this method mediates a request for printing a list
        /// </summary>
        public static void ShowDiseasesRequest()
        {
            Diseases.ShowDiseases();
        }

        /// <summary>
        /// This methodo mediates the request to get a disease from a given list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Disease GetDiseaseRequest(int id)
        {
            return id > 0 ? Diseases.GetDisease(id) : null;
        }

        /// <summary>
        /// Mthod that parses a request to add a new disease to the list. It will return false.
        /// </summary>
        /// <param name="d">object disease</param>
        /// <returns>return true if added, false if object already exists</returns>
        public static bool AddDiseaseRequest(string dType, string dSintoms, string incubationPer)
        {
            if (dType != null && dSintoms!=null && incubationPer!=null)
            {
                _ = int.TryParse(incubationPer, out int incPer) ? incPer : 0;
                return Diseases.AddToDiseases(new Disease(CapitalLetter(dType), CapitalLetter(dSintoms), incPer));
            }

            return false;
        }



        /// <summary>
        /// This method mediates the request for saving an entire structure into a file
        /// </summary>
        /// <param name="fName">Full path and name of bin file</param>
        /// <returns>true if sucess false if not</returns>
        public static bool SaveAllRequest(string fName)
        {
            return fName != null ? Diseases.SaveAll(fName) : false;
        }


        /// <summary>
        /// This method mediates the request for loading an entire structure into memory (not ideal)
        /// </summary>
        /// <param name="fName">Full path and name of bin file</param>
        /// <returns>true if sucess false if not</returns>
        public static bool LoadAllRequest(string fName)
        {
            return fName != null ? Diseases.LoadAll(fName) : false;
        }


        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}