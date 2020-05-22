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
using System.Threading;

/// <summary>
/// Pandemic App Business Object level DLL. 
/// Here is where everything is defined
/// </summary>
namespace AF_IPCA.PandemicApp.BO
{
    /// <summary>
    /// This will struct the information, if a sickperson is admited at a hospital
    /// </summary>
    [Serializable]
    public class Hospital
    {
        #region ------- MEMBER VARIABLES -------

        private static int globalHospId;                                        //global count of id
        private int hospId;                                                     //defines the hospital id
        private string hospitalName;                                            //defines the name of the hospital
        private string hospitalDistrict;                                        //defines the district of the hospital
        private string hospitalCity;                                            //defines the city of the hospital
        private bool isPublic;                                                  //defines if the hospital is public or private
        private static DateTime admitDate;                                      //defines the date when this person has been hospitalized
        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// hospital default constructor
        /// </summary>
        public Hospital()
        {
            hospId = Interlocked.Increment(ref globalHospId);
        }

        public Hospital(string hName, string hDistrict, string hCity, bool isPublic)
        {
            this.HospId = Interlocked.Increment(ref globalHospId);
            this.HospitalName = hName;
            this.HospitalDistrict = hDistrict;
            this.HospitalCity = hCity;
            this.IsPublic = isPublic;
            this.AdmitDate = DateTime.Today;
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        /// <summary>
        /// This property defines the date when a sick person is hospitalized.
        /// </summary>
        public DateTime AdmitDate
        {
            get
            {
                return admitDate;
            }
            set
            {
                admitDate = value;
            }
        }

        /// <summary>
        /// Defines the hospital ID autoincremented
        /// </summary>
        public int HospId
        {
            get
            {
                return hospId;
            }
            private set
            {
                hospId = value;
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
                isPublic = value;
            }
        }

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// sets the autoincremented ID for hospital
        /// </summary>
        /// <returns></returns>
        protected int GetNextHospitalID()
        {
            return ++hospId;
        }

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
        public bool ValIsIsPublic(string n)
        {
            return IsPublic = n.Equals("Sim", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Prompts the user for additional information.
        /// </summary>
        public void AskUserForHospitalInfo()
        {
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