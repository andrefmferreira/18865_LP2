/*
 * ********************************************************************************
 * <copyright file = "CrossRules"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>5/19/2020 5:33:44 PM</date>
 * <description>This class handles all the rules that are common to all business logic classes</description>
 * ********************************************************************************
 */


/// <summary>
/// This is the business logic DLL. This handles all rules and some validations.
/// It does not store information.
/// </summary>
namespace AF_IPCA.PandemicApp.BL
{
    /// <summary>
    /// this class stores the rules that are common to the classes at this level
    /// </summary>
    public class CrossRules
    {

        #region ------- MEMBER VARIABLES -------



        #endregion


        #region ------- CONSTRUCTORS -------

        public CrossRules()
        {

        }

        #endregion


        #region ------- PROPERTIES -------



        #endregion


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



        #endregion


        #region ------- ENUMS -------



        #endregion
    }
}
