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

/// <summary>
/// Pandemic App Domain mainspace. This is the space where classes are "linked" together in a library
/// </summary>
namespace AF_IPCA.PandemicApp.Domain
{
    /// <summary>
    /// sickperson class. This class handles all information related to a person wich is infected.
    /// </summary>
    public class SickPerson : Person
    {
        #region ------- COMPOSITION -------

        private InHospital inHospital = new InHospital();
        private InHome inHome = new InHome();
        private EmergencyContactPerson emrContactPerson = new EmergencyContactPerson();

        private List<DiseaseHistory> diseases = new List<DiseaseHistory>();

        #endregion ------- COMPOSITION -------

        #region ------- MEMBER VARIABLES -------

        private bool isAdmited;                                                                    //defines if a patient is hospitalized
        private static int pId;                                                                    //id of the infected/sickPerson.

        #endregion ------- MEMBER VARIABLES -------

        #region ------- CONSTRUCTORS -------

        public SickPerson()
        {
        }

        /// <summary>
        /// constructor for a sickPerson, passing some data
        /// </summary>
        /// <param name="fN">first name</param>
        /// <param name="lN">last name</param>
        /// <param name="g">gender</param>
        public SickPerson(string fN, string lN, string g)
        {
            FirstName = fN;
            LastName = lN;
            FullName = fN + " " + lN;
            Gender = g;
            pId++;
        }

        #endregion ------- CONSTRUCTORS -------

        #region ------- PROPERTIES -------

        /// <summary>
        /// InHospital composition. This allows to relate the sickPerson object to the InHospital one.
        /// </summary>
        public InHospital InHospital
        {
            get => inHospital; set => inHospital = value;
        }

        /// <summary>
        /// InHome composition. This allows to relate the sickPerson object to the InHome one.
        /// </summary>
        public InHome InHome
        {
            get => inHome; set => inHome = value;
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

        #endregion ------- PROPERTIES -------

        #region ------- FUNCTIONS -------

        /// <summary>
        /// Method that prompts the user for basic data (contact information, general information)
        /// </summary>
        public void basicDataInsert()
        {
            //Console.Write("Qual o pais de origem do paciente? ");
            this.Country = "portugal";                                                  //hardcoded for testing purpose

            //Console.Write("Qual a nacionalidade? ");
            this.Citizenship = "portuguesa";                                            //hardcoded for testing purpose

            //Console.Write("Qual o idioma do paciente: ");
            this.Language = "português";                                                //hardcoded for testing purpose

            //Console.Write("Data de nascimento:  ");
            this.CheckDate("26-07-1986");                                                    //hardcoded for testing purpose

            //Console.Write("Contacto telefónico:  ");
            this.ContactInfo.PhoneNumber = "912123123";                                 //hardcoded for testing purpose

            //Console.Write("Email:  ");
            this.ContactInfo.Email = "a18865@alunos.ipca.pt";                           //hardcoded for testing purpose

            //Console.Write("Reside em que pais actualmente:  ");
            this.ContactInfo.AddressCountry = "Portugal";                               //hardcoded for testing purpose

            //Console.Write("Morada:  ");
            this.ContactInfo.AddressDesc = "Rua do estádio da luz demolido, 39";        //hardcoded for testing purpose

            //Console.Write("Codigo Postal:  ");
            this.ContactInfo.AddressZipCode = "4760-001";                               //hardcoded for testing purpose

            //Console.Write("Concelho:  ");
            this.ContactInfo.AddressCity = "Vila Nova de Famalicão";                    //hardcoded for testing purpose

            //Console.Write("Distrito:  ");
            this.ContactInfo.AddressDistrict = "Braga";                                 //hardcoded for testing purpose

            //Console.Write("Tem contacto de emergência:  ");
            this.emrContactPerson.HasEPC = true;                                             //hardcoded for testing purpose

            //Console.Write("Primeiro nome:  ");
            this.EmrContactPerson.FirstName = "Jorge";                                       //hardcoded for testing purpose

            //Console.Write("Apelido:  ");
            this.emrContactPerson.LastName = "Jesus";                                        //hardcoded for testing purpose
            this.emrContactPerson.FullName = emrContactPerson.FirstName + " " + emrContactPerson.LastName;

            //Console.Write("Contacto:  ");
            this.emrContactPerson.ContactInfo.PhoneNumber = "961231231";                     //hardcoded for testing purpose

            //Console.Write("email:  ");
            this.emrContactPerson.ContactInfo.Email = "Nao tenho";                           //hardcoded for testing purpose

            //Console.Write("Parentesco:  ");
            this.emrContactPerson.RelativeStatus = "Tio";                                    //hardcoded for testing purpose



        }

        /// <summary>
        /// Custom prompts to store aditional info, related to the recovery place.
        /// </summary>
        public void CheckHospitalStatus()
        {
            //Console.Write("Vai ficar internado?");
            IsAdmited = true;    //true for testing

            if (IsAdmited)
            {
                inHospital.AskUserForHospitalInfo();                         //prompts for additional questions to have more info on the medical facility
            }
            else
            {
                //Medical information for procedures at home
                inHome.ProceduresForPatientAtHome = "Informar " + FullName + " que será contactado na periodicidade indicada pelo médico e que deverá ter diversos cuidados";  //hardcoded for testing purpose        
            }
        }

        /// <summary>
        /// Method to add diseases to a list (adds several, for testing purpose)
        /// </summary>
        public void AddDisease()
        {
            diseases.Add(new DiseaseHistory
            {
                TypeOfDisease = "BIRD FLUE",
                DiseaseSintoms = "Febre",
                DiagnosticDate = new DateTime(2009, 5, 27),
                IsCured = true
            });
            diseases.Add(new DiseaseHistory
            {
                TypeOfDisease = "COVID-19",
                DiseaseSintoms = "Febre e dificuldades respiratórias",
                DiagnosticDate = new DateTime(2020, 4, 2),
                IsCured = false

            }); ;;

        }

        /// <summary>
        /// Lists all diseases record for this patient
        /// </summary>
        public void ListDiseases()
        {
            foreach (DiseaseHistory disease in diseases)
            {
                Console.WriteLine("\tData: " + disease.DiagnosticDate.ToShortDateString());
                Console.WriteLine("\tDoença: " + disease.TypeOfDisease);
                Console.WriteLine("\tSintomas: " + disease.DiseaseSintoms);
                Console.WriteLine("\tEstado: " + (disease.IsCured ? "Recuperado":"Infetado"));
                Console.WriteLine("\t***************************************************************");
            }
        }

        #endregion ------- FUNCTIONS -------

        #region ------- ENUMS -------

        #endregion ------- ENUMS -------
    }
}