/*
 * ********************************************************************************
 * <copyright file = "Patient"   Developer: Andre Ferreira @ipca-EST</copyright>
 * <author>andrefmferreira</author>
 * <email>a18865@alunos.ipca.pt</email>
 * <date>4/16/2020 8:58:56 PM</date>
 * <description>defines a sick person.</description>
 * ********************************************************************************
 */

using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// Pandemic App Business Object level DLL. 
/// Here is where everything is defined
/// </summary>
namespace AF_IPCA.PandemicApp.BO
{
    /// <summary>
    /// sickperson class. This class handles all information related to a person wich is infected.
    /// </summary>
    [Serializable]
    public class SickPerson : Person
    {
        #region ------- COMPOSITION -------

        private EmergencyContactPerson emrContactPerson = new EmergencyContactPerson();  //Contact person. Its a diferent person, and will store basic info

        public List<DiseaseHistory> diseases;                                            //disease history where all pandemic virus that this sickperson has or had

        #endregion ------- COMPOSITION -------

        #region ------- MEMBER VARIABLES -------

        private static int hospitalId;                                                                   //id of hospital where sick person is hospitalized
        private bool isAdmited = false;                                                                  //defines if a patient is hospitalized
        private int pId;                                                                                 //id of the infected/sickPerson.
        private static int globalPID;                                                                    //global count of id
        private bool isAlive;                                                                            //bool true if person is alive, false if its dead.

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        /// <summary>
        /// Default constructor. It will set the person's id
        /// </summary>
        public SickPerson()
        {
            this.pId = GetNextId();
            this.diseases = new List<DiseaseHistory>();
            this.isAlive = true;
        }

        /// <summary>
        /// constructor for a sickPerson, passing some data
        /// </summary>
        /// <param name="fN">first name</param>
        /// <param name="lN">last name</param>
        /// <param name="g">gender</param>
        public SickPerson(string fN, string lN, string g)
        {
            this.FirstName = fN;
            this.LastName = lN;
            this.FullName = fN + " " + lN;
            this.Gender = g;
            this.pId = Interlocked.Increment(ref globalPID);
            this.diseases = new List<DiseaseHistory>();
            this.isAlive = true;
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        /// <summary>
        /// This property manages the life status
        /// </summary>
        public bool IsAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                isAlive = value;
            }
        }

        /// <summary>
        /// This property manages the link between a sick person and the hospital where it is hospitalized
        /// </summary>
        public int HospitalId
        {
            get
            {
                return hospitalId;
            }
            set
            {
                IsAdmited = true;               //As a value for hospital is assigned, then sets to true for isAdmited
                hospitalId = value;
            }
        }

        /// <summary>
        /// This property manages the autoincremented id, for every sick persons recorded
        /// </summary>
        public int PID
        {
            get
            {
                return pId;
            }
            private set
            {
                pId = value;
            }
        }

        /// <summary>
        /// this property is responsible to receive and "translate" if a persons has been admited in a hospital
        /// </summary>
        public bool IsAdmited
        {
            get
            {
                return isAdmited;
            }
            set
            {
                isAdmited = value;
            }
        }

        /// <summary>
        /// property for emergency contact person object
        /// </summary>
        public EmergencyContactPerson EmrContactPerson { get => emrContactPerson; set => emrContactPerson = value; }

        /// <summary>
        /// property for contact person data. This will store all the contact information required for a sick person
        /// </summary>
        //public ContactPerson ContactData { get => contactData; set => contactData = value; }

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// This method has the responsability to autoincrement the sickpersons id. It will be unique
        /// </summary>
        /// <returns></returns>
        protected int GetNextId()
        {
            return ++pId;
        }

        ///// <summary>
        ///// Custom prompts to store aditional info, related to the recovery place.
        ///// </summary>
        //public void CheckHospitalStatus()
        //{
        //    //Console.Write("Vai ficar internado?");
        //    IsAdmited = true;    //true for testing

        //    if (IsAdmited)
        //    {
        //        inHospital.AskUserForHospitalInfo();                         //prompts for additional questions to have more info on the medical facility
        //    }
        //    else
        //    {
        //        //Medical information for procedures at home
        //        inHome.ProceduresForPatientAtHome = "Informar " + FullName + " que será contactado na periodicidade indicada pelo médico e que deverá ter diversos cuidados";  //hardcoded for testing purpose
        //    }
        //}

        ///// <summary>
        ///// Method to add diseases to a list (adds several, for testing purpose)
        ///// </summary>
        //public void AddDisease()
        //{
        //    diseases.Add(new DiseaseHistory
        //    {
        //        //TypeOfDisease = "BIRD FLUE",
        //        //DiseaseSintoms = "Febre",
        //        DiagnosticDate = new DateTime(2009, 5, 27),
        //        IsCured = true
        //    });
        //    diseases.Add(new DiseaseHistory
        //    {
        //        TypeOfDisease = "COVID-19",
        //        DiseaseSintoms = "Febre e dificuldades respiratórias",
        //        DiagnosticDate = new DateTime(2020, 4, 2),
        //        IsCured = false

        //    });

        //}

        ///// <summary>
        ///// Lists all diseases record for this patient
        ///// </summary>
        //public void ListDiseases()
        //{
        //    foreach (DiseaseHistory disease in diseases)
        //    {
        //        Console.WriteLine("\tData: " + disease.DiagnosticDate.ToShortDateString());
        //        Console.WriteLine("\tDoença: " + disease.TypeOfDisease);
        //        Console.WriteLine("\tSintomas: " + disease.DiseaseSintoms);
        //        Console.WriteLine("\tEstado: " + (disease.IsCured ? "Recuperado":"Infetado"));
        //        Console.WriteLine("\t***************************************************************");
        //    }
        //}

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}