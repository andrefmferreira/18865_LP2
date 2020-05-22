/*
 * ********************************************************************************
 * <copyright file = "Hospital"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>4/9/2020 2:43:24 PM</date>
 * <description>This class determs the data if a person is being treated in a hospital or at home</description>
 * ********************************************************************************
 */

using System;
/// <summary>
/// Pandemic App Domain mainspace. This is the space where classes are "linked" together in a library
/// </summary>
namespace AF_IPCA.PandemicApp.BO
{
    /// <summary>
    /// This will struct the information, if a sickperson is admited at a hospital
    /// </summary>
    public class InHospital
    {
        #region ------- MEMBER VARIABLES -------


        private bool isICU;                                                     //defines if a patient is on the ICU
        private string hospitalName;                                            //defines the name of the hospital
        private string hospitalDistrict;                                        //defines the district of the hospital
        private string hospitalCity;                                            //defines the city of the hospital
        private bool isPublic;                                                  //defines if the hospital is public or private

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// hospital constructor
        /// </summary>
        public InHospital()
        {
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        /// <summary>
        /// this property is responsible to receive and "translate" if a persons has been at the intesive care in a hospital
        /// </summary>
        public bool IsICU
        {
            get
            {
                return isICU;
            }
            set
            {
                isICU = IsICU;
            }
        }

        /// <summary>
        /// stores the name of the hospital in wich a patient is hospitalized
        /// </summary>
        public string HospitalName
        {
            get
            {
                return hospitalName;
            }
            set
            {
                hospitalName = value.Length <= 100 ? CapitalLetter(value) : "";
            }
        }

        /// <summary>
        /// stores the district of the hospital in wich a patient is hospitalized
        /// </summary>
        public string HospitalDistrict
        {
            get
            {
                return hospitalDistrict;
            }
            set
            {
                hospitalDistrict = value.Length <= 50 ? CapitalLetter(value) : "";
            }
        }

        /// <summary>
        /// stores the city of the hospital in wich a patient is hospitalized
        /// </summary>
        public string HospitalCity
        {
            get
            {
                return hospitalCity;
            }
            set
            {
                hospitalCity = value.Length <= 50 ? CapitalLetter(value) : "";
            }
        }

        /// <summary>
        /// as a patient is at a hospital, for "future statistical mesures", stores if it is a public or private hospital
        /// </summary>
        public bool IsPublic
        {
            get
            {
                return isPublic;
            }
            set
            {
                isPublic = IsPublic;
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

        /// <summary>
        /// Receives an answer from user and converts the y or Y to bool
        /// </summary>
        /// <param name="n">Input from user</param>
        /// <returns>true if y or Y, else false</returns>
        public bool ValIsICU(string n)
        {
            return IsICU = n.Equals("Sim", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Receives an answer from user and converts the y or Y to bool
        /// </summary>
        /// <param name="n">Input from user</param>
        /// <returns>true if y or Y, else false</returns>
        public bool ValIsIsPublic(string n)
        {
            return IsPublic = n.Equals("Sim", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Prompts the user for additional information.
        /// </summary>
        public void AskUserForHospitalInfo()
        {
            //Console.WriteLine("Indicou que o paciente está internado. Indique:");
            //Console.Write("Está nos cuidados intensivos? (Sim/Não)");
            ValIsICU("Sim");                                                        //hardcoded for testing purpose

            //Console.Write("Qual o nome do hospital: ");
            this.HospitalName = "São João de Deus";                                 //hardcoded for testing purpose

            //Console.Write("Qual o distrito do hospital: ");
            this.HospitalDistrict = "Braga";                                        //hardcoded for testing purpose

            //Console.Write("Qual o concelho do hospital: ");
            this.HospitalCity = "Vila Nova de Famalicão";                           //hardcoded for testing purpose

            //Console.Write("o hospital {0} é publico? (Sim/Não) ", HospitalName);    
            ValIsIsPublic("Sim");                                                   //hardcoded for testing purpose
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}